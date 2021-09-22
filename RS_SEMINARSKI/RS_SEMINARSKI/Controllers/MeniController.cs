using Data.EF;
using Data.EFModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RS_SEMINARSKI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.Controllers
{
    public class MeniController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public MeniController(ApplicationDbContext dbContext, ILogger<HomeController> logger,
            IWebHostEnvironment webhostEnvironment)
        {
            _dbContext = dbContext;
            _logger = logger;
            WebHostEnvironment = webhostEnvironment;
        }
        public IActionResult PrikazMenija(string KorisnikID)
        {
            List<MeniPrikazVM.Row> meniji = _dbContext.Meniji
                .Select(x => new MeniPrikazVM.Row
                {
                    MeniID = x.MeniID,
                    TipMenija=x.TipMenija.NazivTipaMenija,
                    NazivMenija=x.NazivMenija,
                    CijenaMenija=x.CijenaMenija,
                    PutanjaDoSlike=x.PutanjaDoSlikeMenija,
                }).ToList();
            Korisnik temp = _dbContext.Korisnici.Find(KorisnikID);
            MeniPrikazVM x = new MeniPrikazVM();
            foreach (var c in meniji)
            {
                var ima = _dbContext.Evidencije.FirstOrDefault(a => a.MeniID == c.MeniID);
                if (ima != null)
                {
                    c.Rezervisano = 1;
                }
                else
                    c.Rezervisano = 0;
            }
            if (temp.RolaID == 1)
                x.RolaID = 1;
            else
                x.RolaID = 2;
            x.meniji = meniji;
            x.KorisnikID = KorisnikID;
            return View(x);
        }
        public IActionResult EvidentirajMeni(string KorisnikID, int MeniID = 0)
        {
            List<SelectListItem> tipoviMenija = _dbContext.TipMenija
                .Select(
                c => new SelectListItem
                {
                    Value = c.TipMenijaID.ToString(),
                    Text = c.NazivTipaMenija

                }).ToList();
            MeniEvidentirajVM meni = new MeniEvidentirajVM();
            meni.KorisnikID = KorisnikID;
            if (MeniID == 0)
            {
                meni = new MeniEvidentirajVM();
            }
            else
            {
                meni = _dbContext.Meniji
                    .Where(s => s.MeniID == MeniID)
                    .Select(c => new MeniEvidentirajVM
                    {
                        MeniID = c.MeniID,
                        NazivMenija = c.NazivMenija,
                        CijenaMenija = c.CijenaMenija,
                        PutanjaDoSlike = c.PutanjaDoSlikeMenija,
                        IzSkladista = c.IzSkladista
                    }).SingleOrDefault();
            }
            meni.KorisnikID = KorisnikID;
            meni.TipMenija = tipoviMenija;
            meni.MeniID = MeniID;
            return View(meni);
        }

        public IActionResult Snimi(MeniEvidentirajVM x)
        {
            Meni meni = new Meni();
            x.PutanjaDoSlike = UploadFile(x);
            if (x.MeniID == 0)
            {
                _dbContext.Add(meni);
            }
            else
            {
                meni = _dbContext.Meniji.Find(x.MeniID);
            }
            meni.MeniID = x.MeniID;
            meni.NazivMenija = x.NazivMenija;
            meni.TipMenijaID = x.TipMenijaID;
            meni.CijenaMenija = x.CijenaMenija;
            if (!string.IsNullOrEmpty(x.PutanjaDoSlike))
                meni.PutanjaDoSlikeMenija = x.PutanjaDoSlike;
            meni.IzSkladista = x.IzSkladista;
            _dbContext.SaveChanges();
            return Redirect("PrikazMenija?KorisnikID=" + x.KorisnikID);
        }


        private string UploadFile(MeniEvidentirajVM x)
        {
            string fileName = null;
            if (x.SlikaMenija != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Slike");
                fileName = Guid.NewGuid().ToString() + "-" + x.SlikaMenija.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    x.SlikaMenija.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        public IActionResult ObrisiMeni(string KorisnikID, int MeniID)
        {
            Meni pronadjen = _dbContext.Meniji.Find(MeniID);
            foreach (var x in _dbContext.KuharMeni.Where(y => y.MeniID == MeniID))
            {
                _dbContext.KuharMeni.Remove(x);
            }
            _dbContext.Remove(pronadjen);
            _dbContext.SaveChanges();
            return Redirect("PrikazMenija?KorisnikID=" + KorisnikID);
        }

        public IActionResult DodajURezervaciju(string KorisnikID, int MeniId)
        {
            var ima1 = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.KorisnikID == KorisnikID);
            if (ima1 != null)
            {
                var ima2 = _dbContext.Evidencije.FirstOrDefault(a => a.RezervacijaID == ima1.RezervacijaID && a.MeniID == MeniId);
                if (ima2 != null)
                {
                    return NoContent();
                }

            }
            var ima = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.KorisnikID == KorisnikID);
            if (ima == null)
            {
                var rezervacija = new Rezervacija();
                _dbContext.Add(rezervacija);
                _dbContext.SaveChanges();
                var rezkorisnici = new RezervacijaKorisnik()
                {
                    RezervacijaID = rezervacija.RezervacijaID,
                    KorisnikID = KorisnikID
                };
                _dbContext.Add(rezkorisnici);
                _dbContext.SaveChanges();
                var x = new Evidencija();
                x.RezervacijaID = rezervacija.RezervacijaID;
                x.MeniID = MeniId;
                _dbContext.Add(x);
                _dbContext.SaveChanges();
            }
            else
            {
                var x = new Evidencija();
                x.RezervacijaID = ima.RezervacijaID;
                x.MeniID = MeniId;
                _dbContext.Add(x);
                _dbContext.SaveChanges();
            }
            var vm = new StavkaKolicinaVM()
            {
                Kolicina = 0,
                Tip = "meni",
                KorisnikID = KorisnikID,
                StavkaID = MeniId
            };
            return View("~/Views/Rezervacija/StavkaKolicina.cshtml", vm);
        }
    }

}
