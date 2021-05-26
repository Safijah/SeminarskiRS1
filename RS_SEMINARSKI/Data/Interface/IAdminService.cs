using Data.EFModels;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
  public   interface IAdminService
    {
        List<Korisnik> GetAdmina();
        void DodajAdministratora(KorisnikEvidentirajVM vm);
        public KorisnikEvidentirajVM GetAdmin(string id);
        void EditAdmina(KorisnikEvidentirajVM vm);
    }
}
