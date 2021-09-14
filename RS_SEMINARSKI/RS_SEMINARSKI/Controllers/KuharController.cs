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
    public class KuharController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public KuharController(ApplicationDbContext dbContext, ILogger<HomeController> logger,
            IWebHostEnvironment webhostEnvironment)
        {
            _dbContext = dbContext;
            _logger = logger;
            WebHostEnvironment = webhostEnvironment;
        }
        public IActionResult PrikazKuhara(string KorisnikID)
        {
            List<KuharPrikazVM.Rows> kuhari = _dbContext.Kuhari.
                Select(a => new KuharPrikazVM.Rows
                {
                    KuharID = a.KuharID,
                    ImeKuhara = a.ImeKuhara,
                    PrezimeKuhara = a.PrezimeKuhara,
                    PlataKuhara = a.PlataKuhara
                }).ToList();
            Korisnik temp = _dbContext.Korisnici.Find(KorisnikID);
            KuharPrikazVM d = new KuharPrikazVM();
            d.kuhari = kuhari;
            d.KorisnikID = KorisnikID;
            if (temp.RolaID == 1)
            {
                d.RolaID = 1;
            }
            else
            {
                d.RolaID = 2;
            }
            return View(d);
        }
        public IActionResult EvidentirajKuhara(string KorisnikID, int KuharID = 0)
        {
            KuharEvidentirajVM kuhar = new KuharEvidentirajVM();
            kuhar.KorisnikID = KorisnikID;
            if (KuharID == 0)
            {
                kuhar = new KuharEvidentirajVM();
            }
            else
            {
                kuhar = _dbContext.Kuhari
                    .Where(x => x.KuharID == KuharID)
                    .Select(y => new KuharEvidentirajVM
                    {
                        KuharID = y.KuharID,
                        ImeKuhara = y.ImeKuhara,
                        PrezimeKuhara = y.PrezimeKuhara,
                        PlataKuhara = y.PlataKuhara
                    }).SingleOrDefault();
            }
            kuhar.KorisnikID = KorisnikID;
            kuhar.KuharID = KuharID;
            return View(kuhar);
        }

        public IActionResult Snimi(KuharEvidentirajVM x)
        {
            Kuhar kuhar = new Kuhar();
            if (x.KuharID == 0)
            {
                _dbContext.Add(kuhar);
            }
            else
            {
                kuhar = _dbContext.Kuhari.Find(x.KuharID);
            }
            kuhar.KuharID = x.KuharID;
            kuhar.ImeKuhara = x.ImeKuhara;
            kuhar.PrezimeKuhara = x.PrezimeKuhara;
            kuhar.PlataKuhara = x.PlataKuhara;
            _dbContext.SaveChanges();
            return Redirect("PrikazKuhara?KorisnikID=" + x.KorisnikID);
        }
        public IActionResult PrikaziJela(int KuharID)
        {
            List<KuharPrikaziJelaVM.Rows> KuharJela = _dbContext.KuharMeni
                .Where(x => x.KuharID == KuharID)
                .Select(a => new KuharPrikaziJelaVM.Rows
                {
                    JeloID = a.MeniID,
                    NazivJela = a.Meni.NazivMenija
                }).ToList();
            KuharPrikaziJelaVM jela = new KuharPrikaziJelaVM();
            jela.jela = KuharJela;
            return View("PrikaziJela", jela);
        }

        public IActionResult DodajJelo(string KorisnikID, int KuharID)
        {
            List<Meni> neodabranaJela = new List<Meni>();
            bool contains = false;
            foreach (var x in _dbContext.Meniji.Where(x => x.IzSkladista == false))
            {
                foreach (var y in _dbContext.KuharMeni)
                {
                    if (x.MeniID == y.MeniID && y.KuharID == KuharID)
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                        neodabranaJela.Add(x);
                else
                    contains = false;
            }
            List<SelectListItem> Jela = neodabranaJela
                .Select(a => new SelectListItem
                {
                    Value = a.MeniID.ToString(),
                    Text = a.NazivMenija
                }).ToList();
            KuharDodajJeloVM jela = new KuharDodajJeloVM();
            jela.KorisnikID = KorisnikID;
            if (KuharID == 0)
            {
                _dbContext.Add(jela);
            }
            else
            {
                jela = _dbContext.Kuhari.Where(a => a.KuharID == KuharID)
                    .Select(b => new KuharDodajJeloVM
                    {
                        KuharID = b.KuharID
                    }).SingleOrDefault();
            }
            jela.KorisnikID = KorisnikID;
            jela.Jela = Jela;
            return View("DodajJelo", jela);
        }
        public IActionResult SnimiJelo(KuharDodajJeloVM x)
        {
            KuharMeni novi = new KuharMeni
            {
                KuharID = x.KuharID,
                MeniID = x.JeloID
            };

            _dbContext.KuharMeni.Add(novi);
            _dbContext.SaveChanges();
            return Redirect("PrikaziJela?KuharID=" + x.KuharID);

        }

        public IActionResult ObrisiKuhara(string KorisnikID, int KuharID)
        {
            Kuhar kuhar = _dbContext.Kuhari.Find(KuharID);
            _dbContext.Remove(kuhar);
            _dbContext.SaveChanges();
            return Redirect("PrikazKuhara?KorisnikID=" + KorisnikID);
        }
    }
}
