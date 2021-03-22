using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class StavkaEvidentirajVM
    {   
        public int StavkaID { get; set; }
        public int MeniID { get; set; }
        public List<SelectListItem> Meni { get; set; }
        public int StavkaUlazID { get; set; }
        public int KolicinaNarucenog { get; set; }
    }
}
