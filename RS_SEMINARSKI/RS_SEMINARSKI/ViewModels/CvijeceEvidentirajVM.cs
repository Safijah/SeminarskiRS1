using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class CvijeceEvidentirajVM
    {
        public int CvijeceID { get; set; }
        public int TipCvijecaID { get; set; }
        public List<SelectListItem> TipCvijeca { get; set; }
        public string VrstaCvijeca { get; set; }
        public float CijenaCvijeca { get; set; }
        public IFormFile SlikaCvijeca { get; set; }
        public string PutanjaDoSlike { get; set; }
        public string KorisnikID { get; set; }
    }
}
