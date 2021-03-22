using Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class KuharPrikazVM
    {
        public class Rows
        {
            public int KuharID { get; set; }
            public string ImeKuhara { get; set; }
            public string PrezimeKuhara { get; set; }
            public float PlataKuhara { get; set; }
            //public List<Meni> meniji { get; set; }
        }
        public List<Rows> kuhari;
        public string KorisnikID { get; set; }
        public int RolaID { get; set; }
    }
}
