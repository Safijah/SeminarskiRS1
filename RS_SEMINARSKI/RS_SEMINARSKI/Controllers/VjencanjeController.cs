using Data.EF;
using Microsoft.AspNetCore.Mvc;
using RS_SEMINARSKI.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.Controllers
{
    public class VjencanjeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public VjencanjeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //ovdje smo prvo slale cijeli model, al nam u zaglavlju nije kako terba link prikazivalo jer smo u prvu ruku
        //primale cijeli model pa nije moglo pojedinacne atribute primit
        public IActionResult PrikazPocetne(string KorisnikID)
        {
           
            var k = _dbContext.Korisnici.Where(a => a.Id == KorisnikID).SingleOrDefault();

            KorisnikEvidentirajVM novi = new KorisnikEvidentirajVM()
            {
                KorisnikID = k.Id,
                ImeKorisnika = k.ImeKorisnika,
                PrezimeKorisnika = k.PrezimeKorisnika,
                KorisnickoIme = k.UserName,
                Lozinka = k.PasswordHash,
                Email = k.Email,
                BrojTelefona = k.PhoneNumber,
                AdresaStanovanja = k.AdresaStanovanja
            };

            return View("PrikazPocetne", novi);
        }
    }
}
