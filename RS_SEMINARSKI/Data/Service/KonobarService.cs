using Data.EF;
using Data.EFModels;
using Data.Interface;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Service
{
    public class KonobarService : IKonobarService
    {
        private ApplicationDbContext _context;
        
        public KonobarService(ApplicationDbContext context)
        {
            _context = context;
           
        }
        public List<Konobar> GetKonobare()
        {
            return _context.Konobari.ToList();
        }
        public void DodajKonobara(KonobariEvidentirajVM vm)
        {
            Konobar konobar  = new Konobar()
            {
                ImeKonobara = vm.ImeKonobara,
                PrezimeKonobara = vm.PrezimeKonobara,
                PlataKonobara = vm.PlataKonobara


            };

            _context.Add(konobar);
            _context.SaveChanges();
        }
        public KonobariEvidentirajVM GetKonobara(int id)
        {
            var vm = _context.Konobari.Where(a => a.KonobarID == id).Select(a => new KonobariEvidentirajVM
            {
                ImeKonobara = a.ImeKonobara,
                PrezimeKonobara = a.PrezimeKonobara,
                PlataKonobara = a.PlataKonobara,
                KonobarID = a.KonobarID
            }).FirstOrDefault();
            return vm;
        }
        public void EditKonobara(KonobariEvidentirajVM vm)
        {
            var kuhar = new Konobar();
            if (vm.KonobarID != 0)
            {
            kuhar = _context.Konobari.Find(vm.KonobarID);
               
            }
            kuhar.ImeKonobara = vm.ImeKonobara;
            kuhar.PrezimeKonobara = vm.PrezimeKonobara;
            kuhar.PlataKonobara = vm.PlataKonobara;
            _context.SaveChanges();

        }
        public void DeleteKonobar(int id)
        {
            var konobar = _context.Konobari.Find(id);
            _context.Remove(konobar);
            _context.SaveChanges();
        }
    }
}
