using Data.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS_SEMINARSKI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.Controllers
{
    public class KorisniciController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public KorisniciController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult PrikazKorisnika()
        {
            var korisnici = _dbContext.Korisnici.Where(a => a.RolaID == 2).Select(a => new PrikazKorisnikaVM.Row
            {
                ImeiPrezime = a.ImeKorisnika + " " + a.PrezimeKorisnika,
                KorisnikID = a.Id,
                StatusRezervacije= _dbContext.RezervacijaKorisnici.Include(b => b.Rezervacija).ThenInclude(b => b.StatusRezervacije).
                    Where(b => a.Id == b.KorisnikID && b.Rezervacija.StatusRezervacijeID>0).Select(b=>b.Rezervacija.StatusRezervacije).FirstOrDefault().Naziv
            }).ToList();
            var vm = new PrikazKorisnikaVM();
            vm.Korisnici = korisnici;
            return View(vm);
        }
        public IActionResult PrikazDetalja(string korisnikID)
        {
            var vm = new RezervacijaPrikazVM();
            vm.stavke = new List<RezervacijaPrikazVM.Rows>();
            var rez = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.KorisnikID == korisnikID);

            if (rez != null)
            {
                vm.RezervacijaID = rez.RezervacijaID;
                var rezervacija = _dbContext.Rezervacije.Find(vm.RezervacijaID);
                if (rezervacija.StatusRezervacijeID >0)
                {
                    vm.dtmDate = rezervacija.DatumVjencanja;

                    var pozivnica = _dbContext.Pozivnice.FirstOrDefault(a => a.PozivnicaID == rezervacija.PozivnicaID);
                    if (pozivnica != null)
                    {
                        var pozivnice = new RezervacijaPrikazVM.Rows
                        {
                            StavkaID = pozivnica.PozivnicaID,
                            Cijena = pozivnica.CijenaPozivnice,
                            Kolicina = rezervacija.KolicinaPozivnica,
                            UkupnaCijena = pozivnica.CijenaPozivnice,
                            Naziv = pozivnica.OpisPozivnice,
                            PutanjaDoSlike = pozivnica.PutanjaDoSlikePozivnice,
                            Tip = "pozivnica"
                        };
                        pozivnice.UkupnaCijena = rezervacija.KolicinaPozivnica * pozivnice.Cijena;
                        vm.CijenaNarudzbe += pozivnice.UkupnaCijena;
                        vm.stavke.Add(pozivnice);
                    }
                    var bendovi = _dbContext.MuzikaBendovi.Include(a => a.Muzika).Include(a => a.Bend).FirstOrDefault(a => a.BendID == rezervacija.BendID);
                    if (bendovi != null)
                    {
                        var bend = new RezervacijaPrikazVM.Rows
                        {
                            StavkaID = bendovi.BendID,
                            Cijena = bendovi.Bend.SatnicaSviranja,
                            Kolicina = 1,
                            UkupnaCijena = bendovi.Bend.SatnicaSviranja,
                            Naziv = bendovi.Muzika.NazivZanra,
                            PutanjaDoSlike = bendovi.Bend.PutanjaDoSlikeBenda,
                            Tip = "bendovi"
                        };
                        bend.UkupnaCijena = bend.Kolicina * bend.Cijena;
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
                        foreach (var x in cvijece)
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
                           Tip = "dekoracije"
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
                          Kolicina = 1,
                          UkupnaCijena = a.Fotograf.SatnicaSlikanja,
                          Naziv = a.Fotograf.ImeFotografa + " " + a.Fotograf.PrezimeFotografa,
                          PutanjaDoSlike = a.Fotograf.PutanjaDoSlikeFotografa,
                          Tip = "fotografi"
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
                          Tip = "sale"
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
                
                vm.KorisnikID = korisnikID;
            }
            var statusi = _dbContext.StatusRezervacije.Select(a => new SelectListItem
            {
                Text = a.Naziv,
                Value = a.StatusRezervacijeID.ToString()
            }).ToList();
            vm.StatusRezervacije = statusi;
            return View(vm);
        }
    }
}
