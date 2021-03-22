using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class MeniEvidentirajVM
    {
        public int MeniID { get; set; }
        public int TipMenijaID { get; set; }
        public List<SelectListItem> TipMenija { get; set; }
        public string NazivMenija { get; set; }
        public bool IzSkladista { get; set; }
        public float CijenaMenija { get; set; }
        public IFormFile SlikaMenija { get; set; }
        public string PutanjaDoSlike { get; set; }
        public int KorisnikID { get; set; }
    }
}
