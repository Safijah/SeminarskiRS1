using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class DekoracijaPrikazDekoracijeVM
    {

        public class Rows
        {
            public int DekoracijaID { get; set; }
            public string TipDekoracije { get; set; }
            public float CijenaDekoracije { get; set; }
            public string  VrstaDekoracije { get; set; }
            public IFormFile SlikaDekoracije { get; set; }
            public string PutanjaDoSlike { get; set; }
            public string  NazivDekoracije { get; set; }



        }
        public string  pretraga { get; set; }
        public List<Rows> Dekoracije { get; set; }
        public int KorisnikID { get; set; }
        public int RolaID { get; set; }
    }
}
