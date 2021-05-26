using Data.EF;
using Data.EFModels;
using Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Data.ViewModels;

namespace Data.Service
{
    public class AdminService : IAdminService
    {
        private ApplicationDbContext _context;
        private readonly UserManager<Korisnik> _userManager;
        public AdminService(ApplicationDbContext context, UserManager<Korisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<Korisnik> GetAdmina()
        {
            return _context.Korisnici.Where(a => a.RolaID == 1).ToList();
        }
        public void DodajAdministratora(KorisnikEvidentirajVM vm)
        {
            Korisnik korisnik = new Korisnik()
            {
                ImeKorisnika = vm.ImeKorisnika,
                PrezimeKorisnika = vm.PrezimeKorisnika,
                Email = vm.Email,
                RolaID = 1

            };

            _context.Add(korisnik);
            _context.SaveChanges();
        }
        public KorisnikEvidentirajVM GetAdmin(string  id)
        {
           var vm= _context.Korisnici.Where(a => a.Id == id).Select(a => new KorisnikEvidentirajVM
            {
                ImeKorisnika = a.ImeKorisnika,
                PrezimeKorisnika = a.PrezimeKorisnika,
                Email = a.Email,
                KorisnikID=a.Id
            }).FirstOrDefault();
            return vm;
        }
        public void EditAdmina(KorisnikEvidentirajVM vm)
        {
            var korisnik = _context.Korisnici.Find(vm.KorisnikID);
            korisnik.ImeKorisnika = vm.ImeKorisnika;
            korisnik.PrezimeKorisnika = vm.PrezimeKorisnika;
            _context.SaveChanges();
            
        }
    }
}
