using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class KuharDodajJeloVM
    {
        public int KorisnikID { get; set; }
        public int KuharID { get; set; }
        public int JeloID { get; set; }
        public List<SelectListItem> Jela { get; set; }
    }
}
