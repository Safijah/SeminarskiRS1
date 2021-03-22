using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class KuharEvidentirajVM
    {
        public int KuharID { get; set; }
        public string KorisnikID { get; set; }
        public string ImeKuhara { get; set; }
        public string PrezimeKuhara { get; set; }
        public float PlataKuhara { get; set; }
    }
}
