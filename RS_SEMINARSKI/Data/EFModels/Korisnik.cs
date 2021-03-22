using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class Korisnik : IdentityUser
    {
       
        public string AdresaStanovanja { get; set; }

        public string ImeKorisnika { get; set; }
        public string PrezimeKorisnika { get; set; }

        public int RolaID { get; set; }
        public Rola Rola { get; set; }


    }
}
