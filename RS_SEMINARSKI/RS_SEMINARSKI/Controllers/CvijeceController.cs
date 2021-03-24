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
    public class CvijeceController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public CvijeceController(ApplicationDbContext dbContext, ILogger<HomeController> logger,
            IWebHostEnvironment webhostEnvironment)
        {
            _dbContext = dbContext;
            _logger = logger;
            WebHostEnvironment = webhostEnvironment;
        }
        public IActionResult PrikazCvijeca(string KorisnikID)
        {
            List<CvijecePrikazVM.Row> cvijece = _dbContext.Cvijece
                .Select(x => new CvijecePrikazVM.Row
                {
                    CvijeceID = x.CvijeceID,
                    TipCvijeca = x.TipCvijeca.NazivTipaCvijeca,
                    VrstaCvijeca = x.VrstaCvijeca,
                    CijenaCvijeca = x.CijenaCvijeca,
                    PutanjaDoSlike = x.PutanjaDoSlikeCvijeca
                }).ToList();
            Korisnik temp = _dbContext.Korisnici.Find(KorisnikID);
            CvijecePrikazVM x = new CvijecePrikazVM();
            if (temp.RolaID == 1)
                x.RolaID = 1;
            else
                x.RolaID = 2;
            x.cvijece = cvijece;
            x.KorisnikID = KorisnikID;
            return View(x);
        }
        public IActionResult EvidentirajCvijece(string KorisnikID, int CvijeceID = 0)
        {
            List<SelectListItem> tipoviCvijeca = _dbContext.TipCvijeca.Select(
                c => new SelectListItem
                {
                    Value = c.TipCvijecaID.ToString(),
                    Text = c.NazivTipaCvijeca

                }).ToList();
            CvijeceEvidentirajVM cvijet = new CvijeceEvidentirajVM();
            cvijet.KorisnikID = KorisnikID;
            if (CvijeceID == 0)
            {
                cvijet = new CvijeceEvidentirajVM();
            }
            else
            {
                cvijet = _dbContext.Cvijece
                    .Where(s => s.CvijeceID == CvijeceID)
                    .Select(c => new CvijeceEvidentirajVM
                    {
                        CvijeceID = c.CvijeceID,
                        CijenaCvijeca = c.CijenaCvijeca,
                        VrstaCvijeca = c.VrstaCvijeca,
                        PutanjaDoSlike = c.PutanjaDoSlikeCvijeca

                    }).SingleOrDefault();
            }
            cvijet.KorisnikID = KorisnikID;
            cvijet.TipCvijeca = tipoviCvijeca;
            cvijet.CvijeceID = CvijeceID;
            
            return View(cvijet);
        }
        public IActionResult Snimi(CvijeceEvidentirajVM x)
        {
            Cvijece cvijece = new Cvijece();
            x.PutanjaDoSlike = UploadFile(x);
            if(x.CvijeceID==0)
            {
                _dbContext.Add(cvijece);
            }
            else
            {
                cvijece = _dbContext.Cvijece.Find(x.CvijeceID);
            }
            cvijece.CvijeceID = x.CvijeceID;
            cvijece.VrstaCvijeca = x.VrstaCvijeca;
            cvijece.TipCvijecaID = x.TipCvijecaID;
            cvijece.CijenaCvijeca = x.CijenaCvijeca;
            if(!string.IsNullOrEmpty(x.PutanjaDoSlike))
                cvijece.PutanjaDoSlikeCvijeca = x.PutanjaDoSlike;
            _dbContext.SaveChanges();
            return Redirect("PrikazCvijeca?KorisnikID="+x.KorisnikID);
        }

        private string UploadFile(CvijeceEvidentirajVM x)
        {
            string fileName = null;
            if (x.SlikaCvijeca != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Slike");
                fileName = Guid.NewGuid().ToString() + "-" + x.SlikaCvijeca.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    x.SlikaCvijeca.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        public IActionResult ObrisiCvijece(string KorisnikID, int CvijeceID)
        {
            Cvijece pronadjen = _dbContext.Cvijece.Find(CvijeceID);
            _dbContext.Remove(pronadjen);
            _dbContext.SaveChanges();
            return Redirect("PrikazCvijeca?KorisnikID=" + KorisnikID);
        }

        public IActionResult DodajURezervaciju(string KorisnikID, int CvijeceId)
        {
            var ima1 = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.KorisnikID == KorisnikID);
            if (ima1 != null)
            {
                var ima2 = _dbContext.RezervacijaCvijece.FirstOrDefault(a => a.RezervacijaID == ima1.RezervacijaID && a.CvijeceID == CvijeceId);
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
                var x = new RezervacijaCvijece();
                x.RezervacijaID = rezervacija.RezervacijaID;
                x.CvijeceID = CvijeceId;
                _dbContext.Add(x);
                _dbContext.SaveChanges();
            }
            else
            {
                var x = new RezervacijaCvijece();
                x.RezervacijaID = ima.RezervacijaID;
                x.CvijeceID = CvijeceId;
                _dbContext.Add(x);
                _dbContext.SaveChanges();
            }
            var vm = new StavkaKolicinaVM()
            {
                Kolicina = 0,
                Tip = "cvijece",
                KorisnikID = KorisnikID,
                StavkaID = CvijeceId
            };
            return View("~/Views/Rezervacija/StavkaKolicina.cshtml", vm);
        }
    }
}
