using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class MuzikaPrikazMuzikeVM
    {
        public class Rows
        {
            //public int MuzikaID { get; set; }
            public int BendID { get; set; }
            public string NazivZanra { get; set; }
            public string  NazivBenda { get; set; }
            public string  OpisBenda { get; set; }
            public float  Satnica_sviranja { get; set; }
            public IFormFile SlikaBenda { get; set; }
            public string PutanjaDoSlike { get; set; }
            public int Rezervisano { get; set; }
        }
        public List<Rows> Bendovi { get; set; }
        public string KorisnikID { get; set; }
        public string pretraga { get; set; }
        public int RolaID { get; set; }


    }
}
