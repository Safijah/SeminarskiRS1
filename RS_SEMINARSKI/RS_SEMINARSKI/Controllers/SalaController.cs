using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS_SEMINARSKI.ViewModels;
using Data.EF;
using Data.EFModels;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;


namespace RS_SEMINARSKI.Controllers
{
    public class SalaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment WebHostEnvironment;
      
        public SalaController(ApplicationDbContext dbContext, ILogger<HomeController> logger, 
            IWebHostEnvironment webhostEnvironment)
        {
            _dbContext = dbContext;
            _logger = logger;
            WebHostEnvironment = webhostEnvironment;
        }
        public IActionResult PrikazSala(string KorisnikID)
        {
           
            List<SalaPrikazVM.Row> sale = _dbContext.Sale
                .Select(x => new SalaPrikazVM.Row
                {
                    SalaID = x.SalaID,
                    KapacitetSale = x.KapacitetSale,
                    OpisSale = x.OpisSale,
                    NazivSale = x.NazivSale,
                    CijenaIznajmljivanjaSale = x.CijenaIznajmljivanjaSale,
                    PutanjaDoSlike = x.PutanjaDoSlikeSale
                }).ToList();
            Korisnik temp = _dbContext.Korisnici.Find(KorisnikID);
            SalaPrikazVM x = new SalaPrikazVM();
            if (temp.RolaID == 1)
                x.RolaID = 1;
            else
                x.RolaID = 2;
            x.sale = sale;
            x.KorisnikID = KorisnikID;
            return View(x);
        }

        public IActionResult EvidentirajSalu(string KorisnikID, int SalaID = 0)
        {
           

            SalaEvidentirajVM sala = new SalaEvidentirajVM();
            sala.KorisnikID = KorisnikID;
            if (SalaID == 0)
            {
                sala = new SalaEvidentirajVM();
            }
            else
            {
                sala = _dbContext.Sale
                    .Where(s => s.SalaID == SalaID)
                    .Select(c => new SalaEvidentirajVM
                    {
                        SalaID = c.SalaID,
                        NazivSale = c.NazivSale,
                        KapacitetSale = c.KapacitetSale,
                        PutanjaDoSlike = c.PutanjaDoSlikeSale,
                        CijenaIznajmljivanjaSale = c.CijenaIznajmljivanjaSale,
                        OpisSale = c.OpisSale

                    }).SingleOrDefault();
            }
            sala.KorisnikID = KorisnikID;

            sala.SalaID = SalaID;
            return View(sala);
        }
        public IActionResult Snimi(SalaEvidentirajVM x)
        {
           
            Sala sale = new Sala();
            x.PutanjaDoSlike = UploadFile(x);
            if (x.SalaID == 0)
            {
                _dbContext.Add(sale);
            }
            else
            {
                sale = _dbContext.Sale.Find(x.SalaID);
            }
            sale.SalaID = x.SalaID;
            sale.NazivSale = x.NazivSale;
            sale.OpisSale = x.OpisSale;
            sale.KapacitetSale = x.KapacitetSale;
            if (!string.IsNullOrEmpty(x.PutanjaDoSlike))
                sale.PutanjaDoSlikeSale = x.PutanjaDoSlike;
            sale.CijenaIznajmljivanjaSale = x.CijenaIznajmljivanjaSale;
            _dbContext.SaveChanges();
            return Redirect("PrikazSala?KorisnikID=" + x.KorisnikID);
        }
        


        private string UploadFile(SalaEvidentirajVM x)
        {
            string fileName = null;
            if (x.SlikaSale != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Slike");
                fileName = Guid.NewGuid().ToString() + "-" + x.SlikaSale.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    x.SlikaSale.CopyTo(fileStream);
                }
            }
            return fileName;
        }
        public IActionResult ObrisiSalu(int KorisnikID, int SalaID)
        {

           

            Sala pronadjen = _dbContext.Sale.Find(SalaID);




            _dbContext.Remove(pronadjen);
            _dbContext.SaveChanges();




            return Redirect("PrikazSala?KorisnikID="+ KorisnikID);
        }
        public  string  DodajURezervaciju (string KorisnikID, int SalaID)
        {
            var ima1 = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.KorisnikID == KorisnikID);
            var ima2 = _dbContext.RezervacijaSale.FirstOrDefault(a => a.RezervacijaID == ima1.RezervacijaID && a.SalaID == SalaID);
            if(ima2!=null)
            {
                 return("Već ste odabrali ovu salu");
            }
      
            var ima = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.KorisnikID == KorisnikID);
            if(ima==null)
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
                var SalaRezervacija = new RezervacijaSala();
                SalaRezervacija.RezervacijaID = rezervacija.RezervacijaID;
                SalaRezervacija.SalaID = SalaID;
                _dbContext.Add(SalaRezervacija);
                _dbContext.SaveChanges();
              
            }
            else
            {
                var SalaRezervacija = new RezervacijaSala();
                SalaRezervacija.RezervacijaID = ima.RezervacijaID;
                SalaRezervacija.SalaID = SalaID;
                _dbContext.Add(SalaRezervacija);
                _dbContext.SaveChanges();
            }
            
            return ("Uspješno ste odabrali salu");
        }
    }
}

