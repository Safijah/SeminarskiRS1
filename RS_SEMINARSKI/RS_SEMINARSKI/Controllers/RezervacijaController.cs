using Data.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RS_SEMINARSKI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.Controllers
{
    public class RezervacijaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public RezervacijaController(ApplicationDbContext dbContext, ILogger<HomeController> logger,
            IWebHostEnvironment webhostEnvironment)
        {
            _dbContext = dbContext;
            _logger = logger;
            WebHostEnvironment = webhostEnvironment;
        }
        public IActionResult Prikaz(string korisnikID)
        {
            var vm = new RezervacijaPrikazVM();
            var rez = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.KorisnikID == korisnikID);
            if (rez != null)
            {
                vm.RezervacijaID = rez.RezervacijaID;
                var rezervacija = _dbContext.Rezervacije.Find(vm.RezervacijaID);
                var pozivnica = _dbContext.Pozivnice.FirstOrDefault(a=>a.PozivnicaID==rezervacija.PozivnicaID);
                if(pozivnica!=null)
                {
                    var pozivnice = new RezervacijaPrikazVM.Rows
                    {
                        StavkaID = pozivnica.PozivnicaID,
                        Cijena = pozivnica.CijenaPozivnice,
                        Kolicina = 1,
                        UkupnaCijena = pozivnica.CijenaPozivnice,
                        Naziv = pozivnica.OpisPozivnice,
                        PutanjaDoSlike = pozivnica.PutanjaDoSlikePozivnice
                    };
                    pozivnice.UkupnaCijena = pozivnice.Kolicina * pozivnice.Cijena;
                    vm.stavke = new List<RezervacijaPrikazVM.Rows>();
                    vm.stavke.Add(pozivnice);
                }
                var muzika = _dbContext.MuzikaBendovi.Include(a=>a.Bend).Include(a=>a.Muzika).FirstOrDefault(a => a.MuzikaID == rezervacija.MuzikaID);
                if (muzika != null)
                {
                    var muzike = new RezervacijaPrikazVM.Rows
                    {
                        StavkaID = muzika.MuzikaID,
                        Cijena = muzika.Bend.SatnicaSviranja,
                        Kolicina = 1,
                        UkupnaCijena = muzika.Bend.SatnicaSviranja ,
                        Naziv = muzika.Muzika.NazivZanra,
                        PutanjaDoSlike = muzika.Bend.PutanjaDoSlikeBenda
                    };
                    muzike.UkupnaCijena = muzike.Kolicina*muzike.Cijena;
                    vm.stavke.Add(muzike);
                }
                var cvijece = _dbContext.RezervacijaCvijece.Include(a => a.Cvijece).ThenInclude(a=>a.TipCvijeca).Where(a => a.RezervacijaID == rezervacija.RezervacijaID)
                    .Select(a=>new RezervacijaPrikazVM.Rows 
                    {
                        StavkaID = a.CvijeceID,
                        Cijena = a.Cvijece.CijenaCvijeca,
                        Kolicina = 10,
                        UkupnaCijena = a.Cvijece.CijenaCvijeca,
                        Naziv = a.Cvijece.VrstaCvijeca+ " "+a.Cvijece.TipCvijeca.NazivTipaCvijeca,
                        PutanjaDoSlike = a.Cvijece.PutanjaDoSlikeCvijeca
                    }).ToList();
                if (cvijece != null)
                {

                foreach(var x in cvijece)
                {
                        x.UkupnaCijena = x.Kolicina * x.Cijena;
                        vm.stavke.Add(x);
                }
                }
                var dekoracije = _dbContext.RezervacijaDekoracije.Include(a => a.Dekoracija).ThenInclude(a => a.TipDekoracije).Where(a => a.RezervacijaID == rezervacija.RezervacijaID)
                   .Select(a => new RezervacijaPrikazVM.Rows
                   {
                       StavkaID = a.DekoracijaID,
                       Cijena = a.Dekoracija.CijenaDekoracije,
                       Kolicina = 10,
                       UkupnaCijena = a.Dekoracija.CijenaDekoracije,
                       Naziv = a.Dekoracija.VrstaDekoracije + " " + a.Dekoracija.TipDekoracije.NazivTipaDekoracije,
                       PutanjaDoSlike = a.Dekoracija.PutanjaDoSlikeDekoracije
                   }).ToList();
                if (dekoracije != null)
                {

                    foreach (var x in dekoracije)
                    {
                        x.UkupnaCijena = x.Kolicina * x.Cijena;
                        vm.stavke.Add(x);
                    }
                }
                var fotografi = _dbContext.RezervacijaFotografi.Include(a => a.Fotograf).ThenInclude(a => a.Fotografija).Where(a => a.RezervacijaID == rezervacija.RezervacijaID)
                  .Select(a => new RezervacijaPrikazVM.Rows
                  {
                      StavkaID = a.FotografID,
                      Cijena = a.Fotograf.SatnicaSlikanja,
                      Kolicina = 10,
                      UkupnaCijena = a.Fotograf.SatnicaSlikanja,
                      Naziv = a.Fotograf.ImeFotografa + " " + a.Fotograf.PrezimeFotografa,
                      PutanjaDoSlike = a.Fotograf.PutanjaDoSlikeFotografa
                  }).ToList();
                if (fotografi != null)
                {

                    foreach (var x in fotografi)
                    {
                        x.UkupnaCijena = x.Kolicina * x.Cijena;
                        vm.stavke.Add(x);
                    }
                }
                var sale = _dbContext.RezervacijaSale.Include(a => a.Sala).Where(a => a.RezervacijaID == rezervacija.RezervacijaID)
                  .Select(a => new RezervacijaPrikazVM.Rows
                  {
                      StavkaID = a.SalaID,
                      Cijena = a.Sala.CijenaIznajmljivanjaSale,
                      Kolicina = a.Sala.KapacitetSale,
                      UkupnaCijena = a.Sala.CijenaIznajmljivanjaSale,
                      Naziv = a.Sala.NazivSale,
                      PutanjaDoSlike = a.Sala.PutanjaDoSlikeSale
                  }).ToList();
                if (sale != null)
                {

                    foreach (var x in sale)
                    {
                        
                        vm.stavke.Add(x);
                    }
                }
            }
            return View(vm);
        }

    }
}
