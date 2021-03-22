using Data.EFModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class MuzikaMuzikaBendVM
    {
        public class Rows
        {
            public int BendID { get; set; }
            public Bend Bendovi { get; set; }


            public string NazivBenda { get; set; }
            public string OpisBenda { get; set; }
            public float  SatnicaBenda { get; set; }
            public string  NazivZanra { get; set; }
            public List<SelectListItem> TipoviZanra { get; set; }
            
            public int MuzikaID { get; set; }
            public Muzika Muzika { get; set; }
            public IFormFile SlikaBenda { get; set; }
            public string PutanjaDoSlike { get; set; }
        }

        public List<Rows> MuzikaBendovi { get; set; }
        public int KorisnikID { get; set; }
        public int RolaID { get; set; }
    }
}
