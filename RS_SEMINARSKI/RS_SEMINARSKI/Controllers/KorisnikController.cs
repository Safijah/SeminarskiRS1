using Core.Interfaces;
using Data.EF;
using Data.EFModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RS_SEMINARSKI.ModelViews;
using RS_SEMINARSKI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.Controllers
{
    public class KorisnikController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<Korisnik> _userManager;
        private readonly IEmailService _emailService;
        public KorisnikController(ApplicationDbContext dbContext, UserManager<Korisnik> userManager, IEmailService emailService)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Evidentiraj(string KorisnikID)
        {

            KorisnikEvidentirajVM novi = new KorisnikEvidentirajVM();
            if (KorisnikID == null)
            {
                novi = new KorisnikEvidentirajVM();
            }
            else
            {
                novi = _dbContext.Korisnici
                    .Where(a => a.Id == KorisnikID)
                    .Select(s => new KorisnikEvidentirajVM
                    {

                        KorisnikID = s.Id,
                        KorisnickoIme = s.UserName,
                        ImeKorisnika = s.ImeKorisnika,
                        PrezimeKorisnika = s.PrezimeKorisnika,
                        AdresaStanovanja = s.AdresaStanovanja,
                        Email = s.Email,
                        Lozinka = s.PasswordHash

                    }).Single();

            }
            return View("Evidentiraj", novi);
        }

        public IActionResult Snimi(KorisnikEvidentirajVM k)
        {
            Korisnik novi = new Korisnik() { RolaID = 2 };



            if (k.KorisnikID == null)
            {
                _dbContext.Add(novi);
            }
            else
            {
                novi = _dbContext.Korisnici.Find(k.KorisnikID);
            }
            novi.ImeKorisnika = k.ImeKorisnika;
            novi.PrezimeKorisnika = k.PrezimeKorisnika;
            novi.UserName = k.KorisnickoIme;
            novi.PasswordHash = k.Lozinka;
            novi.Email = k.Email;
            novi.AdresaStanovanja = k.AdresaStanovanja;

            novi.Id = k.KorisnikID;

            _dbContext.SaveChanges();
            //return View("~/Views/Vjencanje/PrikazPocetne.cshtml", k); zato sto je prikaz pocetne slao cijeli model a nismo ga kako treba primili 
            return Redirect("/Autentifikacija/Prijava");
        }
        public IActionResult PrikazRacuna(string korisnikID)
        {

            KorisnikEvidentirajVM novikorisnik = _dbContext.Korisnici.Where(a => a.Id == korisnikID)
                .Select(k => new KorisnikEvidentirajVM
                {
                    KorisnikID = k.Id,
                    ImeKorisnika = k.ImeKorisnika,
                    PrezimeKorisnika = k.PrezimeKorisnika,
                    KorisnickoIme = k.UserName,
                    Lozinka = k.PasswordHash,
                    AdresaStanovanja = k.AdresaStanovanja,

                    Email = k.Email

                }).Single();

            return View(novikorisnik);
        }


        public IActionResult Obrisi(string KorisnikID)
        {


            Korisnik pronadjen = _dbContext.Korisnici.Find(KorisnikID);




            _dbContext.Remove(pronadjen);
            _dbContext.SaveChanges();



            return View("~/Views/Home/Index.cshtml");
        }
        public IActionResult UnosMaila()
        {
            return View();
        }
        public async Task<IActionResult> ZaboravljenaSifraAsync(string KorisnickoIme)
        {
            if (KorisnickoIme != null)
            {
                try
                {

                    var user = await _userManager.FindByNameAsync(KorisnickoIme);
                    if (user != null)
                    {
                        string url = $"https://localhost:44367/Korisnik/ResetSifre?Email={KorisnickoIme}";
                        await _emailService.SendEmailAsync(user.Email, "Reset Šifre", "<h1>Pratite instrukcije da resetujete Vašu šifru</h1>" +
                    $"<p>Da ponovo postavite Vašu šifru <a href='{url}'>Kliknite ovdje</a></p>");
                    }


                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return NoContent();
        }
        public IActionResult Poruka()
        {
            return View("Poruka");
        }
        public IActionResult ResetSifre(string Email, string NovaSifra)
        {
            ResetSifreVM vm = new ResetSifreVM();
            vm.Email = Email;
            return View(vm);
        }
        public async Task<string> PromjenaSifreAsync(ResetSifreVM vm)
        {
            var user = await _userManager.FindByNameAsync(vm.Email);
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetToken, vm.NovaSifra);
            if(result.Succeeded)
            {

            return ("Uspješno promjenjena šifra");
            }
            else
            {
                return ("Nešto je pošlo po zlu");
            }
        }
    }
}
