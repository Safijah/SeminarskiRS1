using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class KonobariPrikazKonobaraVM
    {
        public class Rows
        {
            public int KonobarID { get; set; }
            public string ImeKonobara { get; set; }
            public string PrezimeKonobara { get; set; }
            public float PlataKonobara { get; set; }
           
        }
        public List<Rows> Konobari { get; set; }
        public string
            KorisnikID { get; set; }

        public int RolaID { get; set; }
    }
}
