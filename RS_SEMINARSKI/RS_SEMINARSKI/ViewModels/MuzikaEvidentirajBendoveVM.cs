using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class MuzikaEvidentirajBendoveVM
    {
        public int MuzikaID { get; set; }
        public int BendID { get; set; }
        public int RolaID { get; set; }

        public  List<SelectListItem> MuzikaZanrovi { get; set; }
        public string NazivBenda { get; set; }
        public string OpisBenda { get; set; }
        public float SatnicaSviranja { get; set; }

        public string KorisnikID { get; set; }

        public IFormFile SlikaBenda { get; set; }
        public string PutanjaDoSlike { get; set; }


    }
}
