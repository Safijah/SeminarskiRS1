using Data.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS_SEMINARSKI.ViewModels;
using Data.EFModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Data.Migrations;

namespace RS_SEMINARSKI.Controllers
{
    
    public class FotografController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public FotografController(ApplicationDbContext dbContext, ILogger<HomeController> logger,
            IWebHostEnvironment webhostEnvironment)
        {
            _dbContext = dbContext;
            _logger = logger;
            WebHostEnvironment = webhostEnvironment;
        }
     
        public IActionResult PrikazFotografa(string KorisnikID)
        {

            
            List<FotografPrikazVM.Row> fotograf = _dbContext.Fotografi.Select(d => new FotografPrikazVM.Row
            {
                FotografID = d.FotografID,
                SatnicaSlikanja = d.SatnicaSlikanja,
                Fotografija = d.Fotografija.NazivStilaFotografije,
                PutanjaDoSlikeFotografa = d.PutanjaDoSlikeFotografa,
                ImeFotografa = d.ImeFotografa,
                PrezimeFotografa=d.PrezimeFotografa


            }).ToList();

            Korisnik temp = _dbContext.Korisnici.Find(KorisnikID);
            FotografPrikazVM d = new FotografPrikazVM();
             d.fotografi= fotograf;
            d.KorisnikID = KorisnikID;
            if (temp.RolaID == 1)
            {
                d.RolaID = 1;
            }
            else
            {
                d.RolaID = 2;
            }


            return View("PrikazFotografa", d);
        }
  
        public IActionResult EvidentirajFotografa(string KorisnikID, int FotografID = 0)
        {
           
            List<SelectListItem> vrstefotografije = _dbContext.Fotografije.Select(
                c => new SelectListItem
                {
                    Value = c.FotografijaID.ToString(),
                    Text = c.NazivStilaFotografije

                }).ToList();
            FotografEvidentirajVM fotograf = new FotografEvidentirajVM();
            fotograf.KorisnikID = KorisnikID;
            if (FotografID == 0)
            {
                fotograf = new FotografEvidentirajVM();
            }
            else
            {
                fotograf = _dbContext.Fotografi
                    .Where(s => s.FotografID == FotografID)
                    .Select(c => new FotografEvidentirajVM
                    {
                        FotografID = c.FotografID,
                        SatnicaSlikanja = c.SatnicaSlikanja,
                        PutanjaDoSlikeFotografa = c.PutanjaDoSlikeFotografa,
                        ImeFotografa = c.ImeFotografa,
                        PrezimeFotografa=c.PrezimeFotografa,
                        


                    }).SingleOrDefault();
            }
            fotograf.KorisnikID = KorisnikID;
            fotograf.FotografID = FotografID;
           fotograf.Fotografija = vrstefotografije;
            return View(fotograf);
        }
        [Authorize]
        public IActionResult Snimi(FotografEvidentirajVM x)
        {
           
            Fotograf fotograf = new Fotograf();
            x.PutanjaDoSlikeFotografa = UploadFile(x);
            if (x.FotografID == 0)
            {
                _dbContext.Add(fotograf);
            }
            else
            {
                fotograf = _dbContext.Fotografi.Find(x.FotografID);
            }

            fotograf.FotografID = x.FotografID;
            fotograf.SatnicaSlikanja = x.SatnicaSlikanja;
            if (!string.IsNullOrEmpty(x.PutanjaDoSlikeFotografa))
                fotograf.PutanjaDoSlikeFotografa = x.PutanjaDoSlikeFotografa;
            fotograf.FotografijaID = x.FotografijaID;
            fotograf.ImeFotografa = x.ImeFotografa;
            fotograf.PrezimeFotografa = x.PrezimeFotografa;
            _dbContext.SaveChanges();
            return Redirect("PrikazFotografa?KorisnikID=" + x.KorisnikID);
        }
       
        private string UploadFile(FotografEvidentirajVM x)
        {
            string fileName = null;
            if  (x.SlikaFotografa!= null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Slike");
                fileName = Guid.NewGuid().ToString() + "-" + x.SlikaFotografa.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    x.SlikaFotografa.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        public IActionResult ObrisiFotografa(string  KorisnikID, int FotografID)
        {

           

            Fotograf pronadjen = _dbContext.Fotografi.Find(FotografID);
            _dbContext.Remove(pronadjen);
            _dbContext.SaveChanges();
            return Redirect("PrikazFotografa?KorisnikID=" + KorisnikID);
        }
        public string DodajURezervaciju(string KorisnikID, int FotografID)
        {
            var ima1 = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.KorisnikID == KorisnikID);
            if (ima1 != null)
            {
                var ima2 = _dbContext.RezervacijaFotografi.FirstOrDefault(a => a.RezervacijaID == ima1.RezervacijaID && a.FotografID == FotografID);

                if (ima2 != null)
                {
                    return ("Već ste odabrali ovog fotografa");
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
                var SalaFotograf = new RezervacijaFotograf();
                SalaFotograf.RezervacijaID = rezervacija.RezervacijaID;
                SalaFotograf.FotografID = FotografID;
                _dbContext.Add(SalaFotograf);
                _dbContext.SaveChanges();

            }
            else
            {
                var SalaFotograf = new RezervacijaFotograf();
                SalaFotograf.RezervacijaID = ima.RezervacijaID;
                SalaFotograf.FotografID = FotografID;
                _dbContext.Add(SalaFotograf);
                _dbContext.SaveChanges();
            }

            return ("Uspješno ste odabrali fotografa");
        }
    }
}
