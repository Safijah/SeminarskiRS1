 using Data.EF;
using Data.EFModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using RS_SEMINARSKI.notHub;
using RS_SEMINARSKI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.Controllers
{
    public class DekoracijaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment WebHostEnvironment;
        IHubContext<NotHub> _hubContext;

        public DekoracijaController(ApplicationDbContext dbContext, ILogger<HomeController> logger,
            IWebHostEnvironment webhostEnvironment, IHubContext<NotHub> hubContext)
        {
            _dbContext = dbContext;
            _logger = logger;
            WebHostEnvironment = webhostEnvironment;
            _hubContext = hubContext;
        }
        public IActionResult PrikazDekoracije(string KorisnikID)
        {

            List<DekoracijaPrikazDekoracijeVM.Rows> dekoracija = _dbContext.Dekoracije.Select(d => new DekoracijaPrikazDekoracijeVM.Rows
            {
                DekoracijaID = d.DekoracijaID,
                CijenaDekoracije = d.CijenaDekoracije,
                TipDekoracije = d.TipDekoracije.NazivTipaDekoracije,
                VrstaDekoracije = d.VrstaDekoracije, 
                PutanjaDoSlike=d.PutanjaDoSlikeDekoracije,
                NazivDekoracije = d.VrstaDekoracije

            }).ToList();

            Korisnik temp = _dbContext.Korisnici.Find(KorisnikID);
            DekoracijaPrikazDekoracijeVM d = new DekoracijaPrikazDekoracijeVM();
            d.Dekoracije = dekoracija;
            d.KorisnikID = KorisnikID;
            foreach(var x in dekoracija)
            {
                var ima = _dbContext.RezervacijaDekoracije.FirstOrDefault(a=>a.DekoracijaID==x.DekoracijaID);
                if (ima!=null)
                {
                    x.Rezervisano = 1;
                }
                else
                    x.Rezervisano = 0;
            }
            if (temp.RolaID == 1)
            {
                d.RolaID = 1;
            }
            else
            {
                d.RolaID = 2;
            }


            return View("PrikazDekoracije", d);
        }


        public IActionResult PrikaziBendove(string KorisnikID)
        {

            

            List<MuzikaMuzikaBendVM.Rows> MuzikaBendovi = _dbContext.MuzikaBendovi.Select(a => new MuzikaMuzikaBendVM.Rows
            {
                BendID = a.BendID,
                MuzikaID = a.MuzikaID,
                NazivBenda=a.Bend.NazivBenda
            }).ToList();


            Korisnik temp = _dbContext.Korisnici.Find(KorisnikID);
            MuzikaMuzikaBendVM d = new MuzikaMuzikaBendVM();
            d.MuzikaBendovi = MuzikaBendovi;
            d.KorisnikID = KorisnikID;
            if (temp.RolaID == 1)
            {
                d.RolaID = 1;
            }
            else
            {
                d.RolaID = 2;
            }

            return View("PrikazDekoracije", d);

        }
        public IActionResult EvidentirajDekoraciju(string KorisnikID, int DekoracijaID = 0)
        {
            
            List<SelectListItem> tipoviDekoracije = _dbContext.TipDekoracija.Select(
                c => new SelectListItem
                {
                    Value = c.TipDekoracijeID.ToString(),
                    Text = c.NazivTipaDekoracije

                }).ToList();
            DekoracijaEvidentirajVM dekoracija = new DekoracijaEvidentirajVM();
            dekoracija.KorisnikID = KorisnikID;
            if (DekoracijaID == 0)
            {
                dekoracija = new DekoracijaEvidentirajVM();
            }
            else
            {
                dekoracija = _dbContext.Dekoracije
                    .Where(s => s.DekoracijaID == DekoracijaID)
                    .Select(c => new DekoracijaEvidentirajVM
                    {
                        DekoracijaID = c.DekoracijaID,
                        CijenaDekoracije = c.CijenaDekoracije,
                        PutanjaDoSlike = c.PutanjaDoSlikeDekoracije,
                        NazivDekoracije=c.VrstaDekoracije,


                    }).SingleOrDefault();
            }
            dekoracija.KorisnikID = KorisnikID;
            dekoracija.DekoracijaID = DekoracijaID;
            dekoracija.TipDekoracije=tipoviDekoracije;
            return View(dekoracija);
        }

        public IActionResult Snimi(DekoracijaEvidentirajVM x)
        {
            
            Dekoracija dekoracija = new Dekoracija();
            x.PutanjaDoSlike = UploadFile(x);
            if (x.DekoracijaID == 0)
            {
                _dbContext.Add(dekoracija);
            }
            else
            {
                dekoracija = _dbContext.Dekoracije.Find(x.DekoracijaID);
            }

            dekoracija.DekoracijaID = x.DekoracijaID;
            dekoracija.CijenaDekoracije = x.CijenaDekoracije;
            if (!string.IsNullOrEmpty(x.PutanjaDoSlike))
                dekoracija.PutanjaDoSlikeDekoracije = x.PutanjaDoSlike;
            dekoracija.TipDekoracijeID = x.TipDekoracijeID;
            dekoracija.VrstaDekoracije = x.NazivDekoracije;
            _dbContext.SaveChanges();
            var nazivv = _dbContext.TipDekoracija.Where(a => a.TipDekoracijeID == dekoracija.TipDekoracijeID).FirstOrDefault().NazivTipaDekoracije;
            _hubContext.Clients.All.SendAsync("prijemDekoracije", dekoracija.CijenaDekoracije, nazivv, dekoracija.PutanjaDoSlikeDekoracije,x.NazivDekoracije,dekoracija.DekoracijaID);

            return Redirect("PrikazDekoracije?KorisnikID=" + x.KorisnikID);
        }

        private string UploadFile(DekoracijaEvidentirajVM x)
        {
            string fileName = null;
            if (x.SlikaDekoracije != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Slike");
                fileName = Guid.NewGuid().ToString() + "-" + x.SlikaDekoracije.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    x.SlikaDekoracije.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        public IActionResult ObrisiDekoraciju(string KorisnikID,int DekoracijaID) {


            
            Dekoracija Dekoracijabrisanje = _dbContext.Dekoracije.Find(DekoracijaID);


            _dbContext.Remove(Dekoracijabrisanje);


            _dbContext.SaveChanges();

            return Redirect("PrikazDekoracije?KorisnikID="+ KorisnikID);
        }


        public IActionResult DodajURezervaciju(string KorisnikID, int DekoracijaID)
        {
           
            var ima1 = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.KorisnikID == KorisnikID);
            if (ima1 != null)
            {
                var ima2 = _dbContext.RezervacijaDekoracije.FirstOrDefault(a => a.RezervacijaID == ima1.RezervacijaID && a.DekoracijaID == DekoracijaID);


                if (ima2 != null)
                {
                    return NoContent();                }
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
                var DekoracijaRezervacija = new RezervacijaDekoracija();
                DekoracijaRezervacija.RezervacijaID = rezervacija.RezervacijaID;
                DekoracijaRezervacija.DekoracijaID = DekoracijaID;
                _dbContext.Add(DekoracijaRezervacija);
                _dbContext.SaveChanges();

            }
            else
            {
                var DekoracijaRezervacija = new RezervacijaDekoracija();
                DekoracijaRezervacija.RezervacijaID = ima.RezervacijaID;
                DekoracijaRezervacija.DekoracijaID = DekoracijaID;
                _dbContext.Add(DekoracijaRezervacija);
                _dbContext.SaveChanges();
            }
            var vm = new StavkaKolicinaVM()
            {
                Kolicina = 0,
                Tip = "dekoracije",
                KorisnikID = KorisnikID,
                StavkaID = DekoracijaID
            };
            return View("~/Views/Rezervacija/StavkaKolicina.cshtml", vm);

            
        }








    }
}
