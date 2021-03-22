using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class KonobariEvidentirajSaluVM
    {
        public int SalaID { get; set; }
        public List<SelectListItem> sale { get; set; }
        public int KonobarID { get; set; }
        public string KorisnikID { get; set; }


    }
}
