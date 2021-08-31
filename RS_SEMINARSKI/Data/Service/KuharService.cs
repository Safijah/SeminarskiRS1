using Data.EF;
using Data.EFModels;
using Data.Interface;
using Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Service
{
    public class KuharService : IKuharService
    {
        private ApplicationDbContext _context;
        private readonly UserManager<Korisnik> _userManager;
        public KuharService(ApplicationDbContext context, UserManager<Korisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<Kuhar> GetKuhara()
        {
            return _context.Kuhari.ToList();
        }
        public void DodajKuhara(KuharEvidentirajVM vm)
        {
            Kuhar kuhar = new Kuhar()
            {
                ImeKuhara = vm.ImeKuhara,
                PrezimeKuhara = vm.PrezimeKuhara,
                PlataKuhara = vm.PlataKuhara
              

            };

            _context.Add(kuhar);
            _context.SaveChanges();
        }
        public KuharEvidentirajVM GetKuhara(int  id)
        {
            var vm = _context.Kuhari.Where(a => a.KuharID == id).Select(a => new KuharEvidentirajVM
            {
                ImeKuhara = a.ImeKuhara,
                PrezimeKuhara = a.PrezimeKuhara,
                PlataKuhara = a.PlataKuhara,
                KuharID = a.KuharID
            }).FirstOrDefault();
            return vm;
        }
        public void EditKuhara(KuharEvidentirajVM vm)
        {
            var kuhar = _context.Kuhari.Find(vm.KuharID);
            kuhar.ImeKuhara = vm.ImeKuhara;
            kuhar.PrezimeKuhara = vm.PrezimeKuhara;
            kuhar.PlataKuhara = vm.PlataKuhara;
            _context.SaveChanges();

        }

        public void DeleteKuhar(int id)
        {
            var kuhar = _context.Kuhari.Find(id);
            _context.Remove(kuhar);
            _context.SaveChanges();
        }
    }
}
