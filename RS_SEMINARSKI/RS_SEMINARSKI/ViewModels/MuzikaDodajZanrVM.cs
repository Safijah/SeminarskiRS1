using Data.EFModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class MuzikaDodajZanrVM
    {
        public string KorisnikID { get; set; }
        public int BendID { get; set; }
        public int MuzikaID { get; set; }
        public List<SelectListItem> TipoviZanra { get; set; }
        public List<Muzika> MuzikaBendovi { get; set; }
    }
}
