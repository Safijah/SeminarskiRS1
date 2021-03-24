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
    public class MuzikaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public MuzikaController(ApplicationDbContext dbContext, ILogger<HomeController> logger,
            IWebHostEnvironment webhostEnvironment)
        {
            _dbContext = dbContext;
            _logger = logger;
            WebHostEnvironment = webhostEnvironment;
        }

        public IActionResult PrikazBendova(string KorisnikID)
        {

          



            List<MuzikaPrikazMuzikeVM.Rows> MuzikaBendovi = _dbContext.Bendovi.Select(a => new MuzikaPrikazMuzikeVM.Rows
            {
                BendID = a.BendID,
                //MuzikaID = a.MuzikaID,
                NazivBenda = a.NazivBenda,
                OpisBenda = a.OpisBenda,
                Satnica_sviranja = a.SatnicaSviranja,
                PutanjaDoSlike = a.PutanjaDoSlikeBenda,
                //NazivZanra= a.NazivBenda

            }).ToList();


            Korisnik temp = _dbContext.Korisnici.Find(KorisnikID);
            MuzikaPrikazMuzikeVM d = new MuzikaPrikazMuzikeVM();
            d.Bendovi = MuzikaBendovi;
            d.KorisnikID = KorisnikID;
            if (temp.RolaID == 1)
            {
                d.RolaID = 1;
            }
            else
            {
                d.RolaID = 2;
            }

            return View("PrikazBendova", d);

        }


        public IActionResult EvidentirajBendove(string KorisnikID, int BendID = 0)
        {
            



            MuzikaEvidentirajBendoveVM muzika = new MuzikaEvidentirajBendoveVM();
            muzika.KorisnikID = KorisnikID;

            var RolaID = _dbContext.Korisnici.Find(KorisnikID).RolaID; 

            if (BendID == 0)
            {
                muzika = new MuzikaEvidentirajBendoveVM();
            }
            else
            {
                muzika = _dbContext.Bendovi
                    .Where(s => s.BendID == BendID)
                    .Select(c => new MuzikaEvidentirajBendoveVM
                    {
                        BendID = c.BendID,
                        NazivBenda = c.NazivBenda,
                        OpisBenda = c.OpisBenda,
                        SatnicaSviranja = c.SatnicaSviranja,
                        PutanjaDoSlike = c.PutanjaDoSlikeBenda

                        //PutanjaDoSlike = c.PutanjaDoSlikeDekoracije,


                    }).SingleOrDefault();
            }
            muzika.KorisnikID = KorisnikID;
            muzika.BendID = BendID;
            muzika.RolaID = RolaID;
            //muzika. = TipoviZanra;
            
            return View(muzika);


        }

        public IActionResult Snimi(MuzikaEvidentirajBendoveVM x)
        {
            
            Bend bendovi = new Bend();
            x.PutanjaDoSlike = UploadFile(x);
            if (x.BendID == 0)
            {
                _dbContext.Add(bendovi);
            }
            else
            {
                bendovi = _dbContext.Bendovi.Find(x.BendID);
            }

            bendovi.BendID = x.BendID;
            bendovi.SatnicaSviranja = x.SatnicaSviranja;
            if (!string.IsNullOrEmpty(x.PutanjaDoSlike))
                bendovi.PutanjaDoSlikeBenda = x.PutanjaDoSlike;

            bendovi.OpisBenda = x.OpisBenda;
            bendovi.NazivBenda = x.NazivBenda;




            _dbContext.SaveChanges();
            return Redirect("PrikazBendova?KorisnikID=" + x.KorisnikID);


        }

      


        private string UploadFile(MuzikaEvidentirajBendoveVM x)
        {
            string fileName = null;
            if (x.SlikaBenda != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Slike");
                fileName = Guid.NewGuid().ToString() + "-" + x.SlikaBenda.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    x.SlikaBenda.CopyTo(fileStream);
                }
            }
            return fileName;
        }


        public IActionResult DodajZanr(string KorisnikID, int BendID)
        {
            
            List<Muzika> vecOdabrani = new List<Muzika>();
            bool ocijenjen = false;

            foreach (var x in _dbContext.Muzika)
            {
                foreach (var y in _dbContext.MuzikaBendovi)
                {
                    if (x.MuzikaID == y.MuzikaID && y.BendID == BendID)
                    {
                        ocijenjen = true;
                        break;

                    }
                }
                if (!ocijenjen)
                    vecOdabrani.Add(x);
                else
                    ocijenjen = false;
            }
            List<SelectListItem> TipoviZanra = vecOdabrani.Select(a => new SelectListItem
            {
                Value = a.MuzikaID.ToString(),
                Text = a.NazivZanra
            }).ToList();

            MuzikaDodajZanrVM zanrovi = new MuzikaDodajZanrVM();
            zanrovi.KorisnikID = KorisnikID;


            



            if (BendID == 0)
            {
                _dbContext.Add(zanrovi);
            }
            else
            {
                zanrovi = _dbContext.Bendovi
                                .Where(a => a.BendID == BendID)
                                .Select(b => new MuzikaDodajZanrVM
                                {
                                    BendID = b.BendID,

                                }).SingleOrDefault();
            }


            zanrovi.KorisnikID = KorisnikID;
            zanrovi.TipoviZanra = TipoviZanra;
            zanrovi.MuzikaBendovi = vecOdabrani;

            return View("DodajZanr", zanrovi);
        }

        public IActionResult PrikaziZanrove(int BendID)
        {
            
            List<MuzikaPrikaziZanroveBendovaVM.Rows> BendoviZanrovi = _dbContext.MuzikaBendovi
                .Where(b => b.BendID == BendID)
                .Select(a => new MuzikaPrikaziZanroveBendovaVM.Rows
                {
                    BendID = a.BendID,
                    NazivZanra = a.Muzika.NazivZanra
                }).ToList();


            MuzikaPrikaziZanroveBendovaVM zanrovi = new MuzikaPrikaziZanroveBendovaVM();
            zanrovi.BendZanrovi = BendoviZanrovi;

            return View("PrikaziZanrove", zanrovi);
        }
        public IActionResult SnimiZanr(MuzikaDodajZanrVM x)
        {

            
            MuzikaBend novi = new MuzikaBend
            {
                MuzikaID = x.MuzikaID,
                BendID = x.BendID
            };

            _dbContext.MuzikaBendovi.Add(novi);
            _dbContext.SaveChanges();

            return Redirect("PrikaziZanrove?BendID=" + x.BendID);

        }




        public IActionResult ObrisiBend(string KorisnikID, int BendID)
        {
          
            Bend bend = _dbContext.Bendovi.Find(BendID);

            foreach (var x in _dbContext.MuzikaBendovi.Where(a => a.BendID == BendID))
            {
                _dbContext.MuzikaBendovi.Remove(x);
            }

            _dbContext.Remove(bend);

            _dbContext.SaveChanges();

            return Redirect("PrikazBendova?KorisnikID=" + KorisnikID);




        }

        public IActionResult DodajURezervaciju(string KorisnikID, int BendID)
        {

            var ima1 = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.KorisnikID == KorisnikID);
            var ima2 = _dbContext.Rezervacije.FirstOrDefault(a => a.RezervacijaID == ima1.RezervacijaID && a.BendID==BendID);
            if (ima2 != null)
            {
                return NoContent();
            }

            var ima = _dbContext.RezervacijaKorisnici.FirstOrDefault(a => a.KorisnikID == KorisnikID);
            if (ima == null)
            {
                var rezervacija = new Rezervacija();
                rezervacija.BendID= BendID;
                _dbContext.Add(rezervacija);
                _dbContext.SaveChanges();
                var rezkorisnici = new RezervacijaKorisnik()
                {
                    RezervacijaID = rezervacija.RezervacijaID,
                    KorisnikID = KorisnikID
                };
                _dbContext.Add(rezkorisnici);
                _dbContext.SaveChanges();


            }
            else
            {
                var rezervacija = _dbContext.Rezervacije.Find(ima.RezervacijaID);
                rezervacija.BendID = BendID;

                _dbContext.SaveChanges();
            }
            var vm = new StavkaKolicinaVM()
            {
                Kolicina = 0,
                Tip = "bendovi",
                KorisnikID = KorisnikID,
                StavkaID = BendID,
            };
            return NoContent();

        }


    }
}

