using Data.EFModels;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
    public interface IKuharService
    {
        List<Kuhar> GetKuhara();
        void DodajKuhara(KuharEvidentirajVM vm);
         KuharEvidentirajVM GetKuhara(int id);
        void EditKuhara(KuharEvidentirajVM vm);
        void DeleteKuhar(int id);

    }
}
