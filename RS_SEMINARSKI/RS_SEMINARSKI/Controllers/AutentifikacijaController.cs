using Microsoft.AspNetCore.Mvc;
using RS_SEMINARSKI.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.EF;
using Data.EFModels;
using RS_SEMINARSKI.ViewModels;
using RS_SEMINARSKI.Helper;
using Microsoft.AspNetCore.Identity;

namespace RS_SEMINARSKI.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private readonly UserManager<Korisnik> _userManager;
        private readonly ApplicationDbContext _dbContext;
        public AutentifikacijaController(UserManager<Korisnik> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }
        public IActionResult Prijava()
        {

            return View("Prijava");
        }
        

        public async Task<IActionResult> SnimiAsync(AutentifikacijaPrijavaVM m)
        {


            var korisnik = await _userManager.FindByNameAsync(m.KorisnickoIme);

            if(korisnik == null)
            {
                TempData["Poruka"] = "Nisu ispravni podaci za prijavu !"; 
                return Redirect("Prijava");
            }
            //var logiranikorisnik = _dbContext.Korisnici.FirstOrDefault(a => a.Id == korisnik.Id);
            //Get_Set.SetLogiraniKorisnik(HttpContext, logiranikorisnik);
            m.KorisnikID = korisnik.Id;

            KorisnikEvidentirajVM k = new KorisnikEvidentirajVM()
            {
                KorisnickoIme = korisnik.UserName,
                Lozinka = korisnik.PasswordHash,
                ImeKorisnika = korisnik.ImeKorisnika,
                PrezimeKorisnika = korisnik.PrezimeKorisnika,
                BrojTelefona = korisnik.PhoneNumber,
                AdresaStanovanja = korisnik.AdresaStanovanja,
                Email = korisnik.Email,
                KorisnikID = korisnik.Id

              
            };

  
            return Redirect("/Vjencanje/PrikazPocetne?KorisnikID=" + k.KorisnikID);
            //View("~/Views/Vjencanje/PrikazPocetne.cshtml");  jer smo slale model a nismo ga kako terba primile
        }

        public IActionResult Poruka()
        {
            return View("Poruka");
        }

        public IActionResult LogOut()
        {
            
            return Redirect("/"); 
        }
    }
}
