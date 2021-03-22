using Data.EF;
using Data.EFModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RS_SEMINARSKI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.Controllers
{
    public class KonobariController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public KonobariController(ApplicationDbContext dbContext, ILogger<HomeController> logger,
            IWebHostEnvironment webhostEnvironment)
        {
            _dbContext = dbContext;
            _logger = logger;
            WebHostEnvironment = webhostEnvironment;
        }
        public IActionResult PrikazKonobara(string KorisnikID)
        {
            

            List<KonobariPrikazKonobaraVM.Rows> konobari = _dbContext.Konobari
                .Select(k => new KonobariPrikazKonobaraVM.Rows
                {
                    KonobarID = k.KonobarID,
                    ImeKonobara = k.ImeKonobara,
                    PrezimeKonobara = k.PrezimeKonobara,
                    PlataKonobara = k.PlataKonobara
                }).ToList();

            KonobariPrikazKonobaraVM k = new KonobariPrikazKonobaraVM();
            k.Konobari = konobari;
            k.KorisnikID = KorisnikID;


            Korisnik temp = _dbContext.Korisnici.Find(KorisnikID); 
            if(temp.RolaID==1)
            {
                k.RolaID = 1;
            }
            else
            {
                k.RolaID = 2;
            }

            k.KorisnikID = KorisnikID;
            
            return View("PrikazKonobara",k);
        }




        public IActionResult EvidentirajKonobare(string KorisnikID, int KonobarID=0)
        {

            

            KonobariEvidentirajKonobareVM k = new KonobariEvidentirajKonobareVM(); 
           

            if(KonobarID==0)
            {
               
                k = new KonobariEvidentirajKonobareVM(); 
                
            }
            else
            {

                k = _dbContext.Konobari
                     .Where(s => s.KonobarID == KonobarID)
                     .Select(a => new KonobariEvidentirajKonobareVM
                     {
                         KonobarID = a.KonobarID,
                         ImeKonobara = a.ImeKonobara,
                         PrezimeKonobara = a.PrezimeKonobara,
                         PlataKonobara = a.PlataKonobara

                     }).SingleOrDefault();
            }

            k.KorisnikID = KorisnikID;         //Ovo smo dodali a i konobar ID cemo ponovo dodat jer kad otvorimo taj view mora nam prikazati postojeceg konobara

            return View("EvidentirajKonobare",k); 

        }
       
        public IActionResult Snimi(KonobariEvidentirajKonobareVM x)
        {

            
            Konobar novi = new Konobar();

            if(x.KonobarID==0)
            {
                _dbContext.Add(novi); 
            }
            else
            {
                novi = _dbContext.Konobari.Find(x.KonobarID);
            }
            novi.KonobarID = x.KonobarID;
            novi.ImeKonobara = x.ImeKonobara;
            novi.PrezimeKonobara = x.PrezimeKonobara;
            novi.PlataKonobara = x.PlataKonobara;

            _dbContext.SaveChanges(); 


            return Redirect("PrikazKonobara?KorisnikID=" + x.KorisnikID);
        }

        public IActionResult EvidentirajSalu(string KorisnikID, int KonobarID)
        {

           
            KonobariEvidentirajSaluVM s = new KonobariEvidentirajSaluVM();


          


            List<Sala> odabrane = new List<Sala>();
            bool JEodabrane = false; 

            foreach (var x in _dbContext.Sale)
            {
                foreach(var y in _dbContext.SalaKonobari)
                {
                    if(x.SalaID==y.SalaID && y.KonobarID==KonobarID)
                    {
                        JEodabrane = true;
                        break; 
                    }
                }

                if (!JEodabrane)
                    odabrane.Add(x); 
                else
                    JEodabrane = false; 
            }

            List<SelectListItem> sale = odabrane.Select(a => new SelectListItem
            {
                Value = a.SalaID.ToString(),
                Text = a.NazivSale
            }).ToList();


            s.sale = sale;
            s.KonobarID = KonobarID;
            s.KorisnikID = KorisnikID;

            return View("EvidentirajSalu", s); 
        }

       
        public IActionResult PrikazSalaKonobara(int KonobarID) // bio je prvi parametar KorisnikID
        {
            




            List<KonobariPrikazSalaKonobaraVM.Rows> konobariSale = _dbContext.SalaKonobari
                .Where(a=>a.KonobarID==KonobarID)
                .Select(s => new KonobariPrikazSalaKonobaraVM.Rows
                {

                    SalaID = s.SalaID,
                    NazivSale = s.Sala.NazivSale, 
                    
                }).ToList();

            KonobariPrikazSalaKonobaraVM m = new KonobariPrikazSalaKonobaraVM();
            m.SaleKonobari = konobariSale;
            //m.KorisnikID = KorisnikID;

           

            return View("PrikazSalaKonobara", m);
        }


        public IActionResult SnimiSalu(KonobariEvidentirajSaluVM x)
        {


            

            SalaKonobar nova = new SalaKonobar()
            {
                KonobarID = x.KonobarID,
                SalaID = x.SalaID
            };

            _dbContext.SalaKonobari.Add(nova);
            _dbContext.SaveChanges();


            //return Redirect("PrikazSalaKonobara?KorisnikID=" + x.KorisnikID);
            return Redirect("PrikazSalaKonobara?KonobarID=" + x.KonobarID);

        }
        public IActionResult ObrisiKonobara(int KorisnikID, int KonobarID)
        {


            

            
            Konobar k = _dbContext.Konobari.Find(KonobarID);

            foreach(var x in _dbContext.SalaKonobari.Where(sk=>sk.KonobarID==KonobarID))
            {
                _dbContext.SalaKonobari.Remove(x);
            }

            _dbContext.Remove(k);
            _dbContext.SaveChanges(); 

            return Redirect("PrikazKonobara?KorisnikID=" + KorisnikID); 
        }

    }
}
