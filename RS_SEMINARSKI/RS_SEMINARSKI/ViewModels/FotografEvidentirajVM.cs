using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class FotografEvidentirajVM
    {
        public int FotografID { get; set; }
        public int FotografijaID { get; set; }
        public List<SelectListItem> Fotografija { get; set; }

       
        public IFormFile SlikaFotografa { get; set; }
        public string PutanjaDoSlikeFotografa { get; set; }
        public int KorisnikID { get; set; }
        public string ImeFotografa { get; set; }
        public string PrezimeFotografa { get; set; }
        public float SatnicaSlikanja { get; set; }
    }
}
