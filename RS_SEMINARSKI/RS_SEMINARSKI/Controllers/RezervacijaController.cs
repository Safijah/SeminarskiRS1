using Data.EF;
using Data.EFModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            vm.stavke = new List<RezervacijaPrikazVM.Rows>();
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
                        Kolicina = rezervacija.KolicinaPozivnica,
                        UkupnaCijena = pozivnica.CijenaPozivnice,
                        Naziv = pozivnica.OpisPozivnice,
                        PutanjaDoSlike = pozivnica.PutanjaDoSlikePozivnice,
                        Tip="pozivnica" 
                    };
                    pozivnice.UkupnaCijena = rezervacija.KolicinaPozivnica * pozivnice.Cijena;
                    vm.CijenaNarudzbe += pozivnice.UkupnaCijena; 
                    vm.stavke.Add(pozivnice);
                }
                var bendovi = _dbContext.MuzikaBendovi.Include(a=>a.Muzika).Include(a=>a.Bend).FirstOrDefault(a => a.BendID == rezervacija.BendID);
                if (bendovi != null)
                {
                    var bend = new RezervacijaPrikazVM.Rows
                    {
                        StavkaID = bendovi.BendID,
                        Cijena = bendovi.Bend.SatnicaSviranja,
                        Kolicina = 1,
                        UkupnaCijena = bendovi.Bend.SatnicaSviranja ,
                        Naziv = bendovi.Muzika.NazivZanra,
                        PutanjaDoSlike = bendovi.Bend.PutanjaDoSlikeBenda,
                        Tip="bendovi"
                    };
                    bend.UkupnaCijena = bend.Kolicina* bend.Cijena;
                    vm.CijenaNarudzbe += bend.UkupnaCijena;
                    vm.stavke.Add(bend);
                }
                var cvijece = _dbContext.RezervacijaCvijece.Include(a => a.Cvijece).ThenInclude(a => a.TipCvijeca).Where(a => a.RezervacijaID == rezervacija.RezervacijaID)
                    .Select(a => new RezervacijaPrikazVM.Rows
                    {
                        StavkaID = a.CvijeceID,
                        Cijena = a.Cvijece.CijenaCvijeca,
                        Kolicina = 10,
                        UkupnaCijena = a.Cvijece.CijenaCvijeca,
                        Naziv = a.Cvijece.VrstaCvijeca + " " + a.Cvijece.TipCvijeca.NazivTipaCvijeca,
                        PutanjaDoSlike = a.Cvijece.PutanjaDoSlikeCvijeca,
                        Tip = "cvijece"
                    }).ToList();
                if (cvijece != null)
                {
                    foreach(var x in cvijece)
                    {
                        x.UkupnaCijena = x.Kolicina * x.Cijena;
                        vm.CijenaNarudzbe += x.UkupnaCijena;
                        vm.stavke.Add(x);
                    }
                }

                var dekoracije = _dbContext.RezervacijaDekoracije.Include(a => a.Dekoracija).ThenInclude(a => a.TipDekoracije).Where(a => a.RezervacijaID == rezervacija.RezervacijaID)
                   .Select(a => new RezervacijaPrikazVM.Rows
                   {
                       StavkaID = a.DekoracijaID,
                       Cijena = a.Dekoracija.CijenaDekoracije,
                       Kolicina = a.KolicinaNarucenihDekoracija,
                       UkupnaCijena = a.Dekoracija.CijenaDekoracije,
                       Naziv = a.Dekoracija.VrstaDekoracije + " " + a.Dekoracija.TipDekoracije.NazivTipaDekoracije,
                       PutanjaDoSlike = a.Dekoracija.PutanjaDoSlikeDekoracije,
                       Tip="dekoracije"
                   }).ToList();

                if (dekoracije != null)
                {

                    foreach (var x in dekoracije)
                    {
                        x.UkupnaCijena = x.Kolicina * x.Cijena;
                        vm.CijenaNarudzbe += x.UkupnaCijena;
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
                      PutanjaDoSlike = a.Fotograf.PutanjaDoSlikeFotografa,
                      Tip="fotografi"
                  }).ToList();
                if (fotografi != null)
                {

                    foreach (var x in fotografi)
                    {
                        x.UkupnaCijena = x.Kolicina * x.Cijena;
                        vm.CijenaNarudzbe += x.UkupnaCijena;
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
                      PutanjaDoSlike = a.Sala.PutanjaDoSlikeSale,
                      Tip="sale"
                  }).ToList();
                if (sale != null)
                {

                    foreach (var x in sale)
                    {
                        vm.CijenaNarudzbe += x.UkupnaCijena;
                        vm.stavke.Add(x);
                    }
                }

                var meni = _dbContext.Evidencije.Include(a => a.Meni).Where(a => a.RezervacijaID == rezervacija.RezervacijaID)
                  .Select(a => new RezervacijaPrikazVM.Rows
                  {
                      StavkaID = a.MeniID,
                      Cijena = a.Meni.CijenaMenija,
                      Kolicina = 10,
                      Naziv = a.Meni.NazivMenija,
                      PutanjaDoSlike = a.Meni.PutanjaDoSlikeMenija,
                      Tip = "meni"
                  }).ToList();
                if (meni != null)
                {

                    foreach (var x in meni)
                    {
                        x.UkupnaCijena = x.Kolicina * x.Cijena;
                        vm.CijenaNarudzbe += x.UkupnaCijena;
                        vm.stavke.Add(x);
                    }
                }
            }
            vm.dtmDate = DateTime.Now;
            vm.KorisnikID = korisnikID;
            return View(vm);
        }
        public IActionResult ObrisiStavku(string KorisnikID, int StavkaID, string Tip)
        {
            var RezervacijaID = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.KorisnikID == KorisnikID).RezervacijaID;
            switch (Tip)
            {
                case "cvijece" : var Cvijece = _dbContext.RezervacijaCvijece.Where(a => a.RezervacijaID == RezervacijaID && a.CvijeceID == StavkaID).FirstOrDefault();
                    _dbContext.RezervacijaCvijece.Remove(Cvijece);
                    break;
                case "dekoracije":
                    var Dekoracije = _dbContext.RezervacijaDekoracije.Where(a => a.RezervacijaID == RezervacijaID && a.DekoracijaID == StavkaID).FirstOrDefault();
                    _dbContext.RezervacijaDekoracije.Remove(Dekoracije);
                    break;
                case "fotografi":
                    var Fotografi = _dbContext.RezervacijaFotografi.Where(a => a.RezervacijaID == RezervacijaID && a.FotografID == StavkaID).FirstOrDefault();
                    _dbContext.RezervacijaFotografi.Remove(Fotografi);
                    break;
                case "sale":
                    var Sale = _dbContext.RezervacijaSale.Where(a => a.RezervacijaID == RezervacijaID && a.SalaID == StavkaID).FirstOrDefault();
                    _dbContext.RezervacijaSale.Remove(Sale);
                    break;
                case "pozivnica": var RezervacijaPozivnica = _dbContext.Rezervacije.FirstOrDefault(a => a.RezervacijaID == RezervacijaID);
                    RezervacijaPozivnica.PozivnicaID = null;
                    RezervacijaPozivnica.KolicinaPozivnica = 0;
                    break;
                case "bendovi":
                    var RezervacijaBend = _dbContext.Rezervacije.FirstOrDefault(a => a.RezervacijaID == RezervacijaID);
                    RezervacijaBend.BendID = null;
                    break;
                case "meni":
                    var meni = _dbContext.Evidencije.Where(a => a.RezervacijaID == RezervacijaID && a.MeniID == StavkaID).FirstOrDefault();
                    _dbContext.Evidencije.Remove(meni);
                    break;

            }
            _dbContext.SaveChanges();
            return Redirect("/Rezervacija/Prikaz?korisnikID="+KorisnikID);
        }
        //public IActionResult StavkaKolicina(StavkaKolicinaVM vm )
        //{
        //    return View(vm);
        //}
        public IActionResult DodajKolicinu(StavkaKolicinaVM vm)
        {
            var RezervacijaID = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.KorisnikID == vm.KorisnikID).RezervacijaID;
            switch (vm.Tip)
            {
                case "cvijece":
                    var Cvijece = _dbContext.RezervacijaCvijece.Where(a => a.RezervacijaID == RezervacijaID && a.CvijeceID == vm.StavkaID).FirstOrDefault();
                    _dbContext.RezervacijaCvijece.Remove(Cvijece);
                    return Redirect("/Cvijece/PrikazCvijeca?KorisnikID=" + vm.KorisnikID);

                case "dekoracije":
                    var Dekoracije = _dbContext.RezervacijaDekoracije.Where(a => a.RezervacijaID == RezervacijaID && a.DekoracijaID == vm.StavkaID).FirstOrDefault();
                    Dekoracije.KolicinaNarucenihDekoracija = vm.Kolicina;
                    _dbContext.SaveChanges();
                    return Redirect("/Dekoracija/PrikazDekoracije?KorisnikID=" + vm.KorisnikID);
                  
                case "fotografi":
                    var Fotografi = _dbContext.RezervacijaFotografi.Where(a => a.RezervacijaID == RezervacijaID && a.FotografID == vm.StavkaID).FirstOrDefault();
                    _dbContext.RezervacijaFotografi.Remove(Fotografi);
                    break;

                case "sale":
                    var Sale = _dbContext.RezervacijaSale.Where(a => a.RezervacijaID == RezervacijaID && a.SalaID == vm.StavkaID).FirstOrDefault();
                    _dbContext.RezervacijaSale.Remove(Sale);
                    break;
                   
                case "pozivnica":
                    var RezervacijaPozivnica = _dbContext.Rezervacije.FirstOrDefault(a => a.RezervacijaID == RezervacijaID);
                    RezervacijaPozivnica.KolicinaPozivnica = vm.Kolicina;
                    _dbContext.SaveChanges();
                    return Redirect("/Pozivnica/PrikazPozivnica?KorisnikID=" + vm.KorisnikID);

                case "bendovi":
                    var RezervacijaBend = _dbContext.Rezervacije.FirstOrDefault(a => a.RezervacijaID == RezervacijaID);
                    RezervacijaBend.BendID = null;
                    break;

                case "meni":
                    var meni = _dbContext.Evidencije.Where(a => a.RezervacijaID == RezervacijaID && a.MeniID == vm.StavkaID).FirstOrDefault();
                    _dbContext.Evidencije.Remove(meni);
                    return Redirect("/Meni/PrikazMenija?KorisnikID=" + vm.KorisnikID);
            }
            return NoContent();
        }

        public IActionResult KreirajRacun(RezervacijaPrikazVM x)
        {

            List<SelectListItem> n = _dbContext.NacinPlacanja.Select(d => new SelectListItem
            {
                Value = d.NacinPlacanjaID.ToString(),
                Text = d.NacinPlacanjaNaziv
            }).ToList();


            RacunVM novi = new RacunVM()
            {
                RacunID = 0,
                RezervacijaID = x.RezervacijaID,
                dtmDate = x.dtmDate,
                UkupanIznos = x.CijenaNarudzbe
            };
            novi.nacinPlacanja = n;


            return View("PrikazRacuna", novi);
        }

    }
}
