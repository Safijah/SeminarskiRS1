using Data.EF;
using Data.EFModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RS_SEMINARSKI.ViewModels;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.Controllers
{
    public class RacunController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public RacunController(ApplicationDbContext dbContext, ILogger<HomeController> logger,
            IWebHostEnvironment webhostEnvironment)
        {
            _dbContext = dbContext;
            _logger = logger;
            WebHostEnvironment = webhostEnvironment;
        }
        public async Task<IActionResult> PlatiAsync(RacunVM x)
        {
            var KorisnikID = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.RezervacijaID == x.RezervacijaID).KorisnikID;
            Racun novi = new Racun()
            {
                IznosRacuna = x.UkupanIznos
            };

            _dbContext.Add(novi);
            _dbContext.SaveChanges();
            if (x.nacinPlacanjaID == 1)
            {
                try
                {
                    StripeConfiguration.ApiKey = "sk_test_51IYDuMFF8QkBScNHXFHqiScdbz9rVOVrTC1qcBGfOAa9PcpJnyOu2vo4dwDGKwTyjsPqXV2R5xNHOZATHyDn6xMl001rwGzwGG";
                    var optionsToken = new TokenCreateOptions
                    {
                        Card = new CreditCardOptions
                        {
                            Number = x.KreditnaKarticaBroj,
                            ExpMonth = x.MjesecIstekaKartice,
                            ExpYear = x.GodinaIstekaKartice,
                            Cvc = x.CVC
                        }
                    };
                    var serviceToken = new TokenService();
                    Token stripeToken = await serviceToken.CreateAsync(optionsToken);
                    var options = new ChargeCreateOptions
                    {
                        Amount = (int)x.UkupanIznos,
                        Currency = "usd",
                        Description = "test",
                        Source = stripeToken.Id
                    };
                    var service = new ChargeService();
                    Charge charge = await service.CreateAsync(options);
                    if (charge.Paid)
                    {

                        var ima = _dbContext.KreditnaKartica.Where(d => d.KorisnikID == KorisnikID && d.BrojKreditneKartice == x.KreditnaKarticaBroj).FirstOrDefault();

                        if (ima == null)
                        {
                            var kartica = new KreditnaKartica()
                            {
                                BrojKreditneKartice = x.KreditnaKarticaBroj,
                                CVC = x.CVC,
                                MjesecIstekaKartice = x.MjesecIstekaKartice,
                                GodinaIstekaKartice = x.GodinaIstekaKartice,
                                KorisnikID = KorisnikID

                            };
                            _dbContext.Add(kartica);
                            _dbContext.SaveChanges();
                            novi.KreditnaKarticaID = kartica.KreditnaKarticaID;

                            _dbContext.SaveChanges();
                        }
                       
                    }
                   

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            var rezervacija = _dbContext.Rezervacije.FirstOrDefault(a => a.RezervacijaID == x.RezervacijaID);
            rezervacija.RacunID = novi.RacunID;
            rezervacija.NacinPlacanjaID = x.nacinPlacanjaID;
            rezervacija.DatumVjencanja = x.dtmDate;
            rezervacija.StatusRezervacijeID = 1;
            _dbContext.SaveChanges();
            return View("Plati");

        }
    }
}
