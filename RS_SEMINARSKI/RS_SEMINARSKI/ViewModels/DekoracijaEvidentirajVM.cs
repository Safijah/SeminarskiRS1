using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class DekoracijaEvidentirajVM
    {
        public int DekoracijaID { get; set; }
        public int TipDekoracijeID { get; set; }
        public List<SelectListItem> TipDekoracije { get; set; }
   
        public float CijenaDekoracije { get; set; }
        public IFormFile SlikaDekoracije { get; set; }
        public string PutanjaDoSlike { get; set; }
        public int KorisnikID { get; set; }
        public string  NazivDekoracije { get; set; }
    }
}
