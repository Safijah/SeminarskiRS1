using Data.EF;
using Data.EFModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RS_SEMINARSKI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.Controllers
{
    public class PozivnicaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public PozivnicaController(ApplicationDbContext dbContext, ILogger<HomeController> logger,
            IWebHostEnvironment webhostEnvironment)
        {
            _dbContext = dbContext;
            _logger = logger;
            WebHostEnvironment = webhostEnvironment;
        }
        public IActionResult PrikazPozivnica(int KorisnikID)
        {
            
            List<PozivnicaPrikazVM.Row> pozivnice = _dbContext.Pozivnice
                .Select(x => new PozivnicaPrikazVM.Row
                {
                    PozivnicaID = x.PozivnicaID,
                    CijenaPozivnice = x.CijenaPozivnice,
                    OpisPozivnice = x.OpisPozivnice,
                    PutanjaDoSlikePozivnice = x.PutanjaDoSlikePozivnice
                }).ToList();
            Korisnik temp = _dbContext.Korisnici.Find(KorisnikID);
            PozivnicaPrikazVM x = new PozivnicaPrikazVM();
            if (temp.RolaID == 1)
                x.RolaID = 1;
            else
                x.RolaID = 2;
            x.pozivnice = pozivnice;
            x.KorisnikID = KorisnikID;
            return View(x);
        }

        public IActionResult EvidentirajPozivnicu(int KorisnikID, int PozivnicaID = 0)
        {
           

            PozivnicaEvidentirajVM pozivnica = new PozivnicaEvidentirajVM();
            pozivnica.KorisnikID = KorisnikID;
            if (PozivnicaID == 0)
            {
                pozivnica = new PozivnicaEvidentirajVM();
            }
            else
            {
                pozivnica = _dbContext.Pozivnice
                    .Where(s => s.PozivnicaID == PozivnicaID)
                    .Select(c => new PozivnicaEvidentirajVM
                    {
                        PozivnicaID = c.PozivnicaID,
                        OpisPozivnice = c.OpisPozivnice,
                        CijenaPozivnice= c.CijenaPozivnice,
                        PutanjaDoSlikePozivnice = c.PutanjaDoSlikePozivnice
                        

                    }).SingleOrDefault();
            }
            pozivnica.KorisnikID = KorisnikID;

            pozivnica.PozivnicaID = PozivnicaID;
            return View(pozivnica);
        }
        public IActionResult Snimi(PozivnicaEvidentirajVM x)
        {
          
            Pozivnica pozivnica = new Pozivnica();
            x.PutanjaDoSlikePozivnice = UploadFile(x);
            if (x.PozivnicaID == 0)
            {
                _dbContext.Add(pozivnica);
            }
            else
            {
                pozivnica = _dbContext.Pozivnice.Find(x.PozivnicaID);
            }
            pozivnica.PozivnicaID = x.PozivnicaID;
            pozivnica.OpisPozivnice = x.OpisPozivnice;
            pozivnica.CijenaPozivnice = x.CijenaPozivnice;
            if (!string.IsNullOrEmpty(x.PutanjaDoSlikePozivnice))
                pozivnica.PutanjaDoSlikePozivnice = x.PutanjaDoSlikePozivnice;
            _dbContext.SaveChanges();
            return Redirect("PrikazPozivnica?KorisnikID=" + x.KorisnikID);
        }
       


        private string UploadFile(PozivnicaEvidentirajVM x)
        {
            string fileName = null;
            if (x.SlikaPozivnice != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Slike");
                fileName = Guid.NewGuid().ToString() + "-" + x.SlikaPozivnice.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    x.SlikaPozivnice.CopyTo(fileStream);
                }
            }
            return fileName;
        }
        public IActionResult ObrisiPozivnicu(int KorisnikID, int PozivnicaID)
        {

           

            Pozivnica pronadjen = _dbContext.Pozivnice.Find(PozivnicaID);




            _dbContext.Remove(pronadjen);
            _dbContext.SaveChanges();




            return Redirect("PrikazPozivnica?KorisnikID=" + KorisnikID);
        }
    }
}
