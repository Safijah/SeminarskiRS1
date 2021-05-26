using Data.EFModels;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
   public  interface IKonobarService
    {
        List<Konobar> GetKonobare();
        void DodajKonobara(KonobariEvidentirajVM vm);
        KonobariEvidentirajVM GetKonobara(int id);
        void EditKonobara(KonobariEvidentirajVM vm);
    }
}
