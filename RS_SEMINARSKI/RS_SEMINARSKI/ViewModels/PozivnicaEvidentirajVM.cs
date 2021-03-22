using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class PozivnicaEvidentirajVM
    {
        public int PozivnicaID { get; set; }
        public float CijenaPozivnice { get; set; }
        public string OpisPozivnice { get; set; }
        public string PutanjaDoSlikePozivnice { get; set; }
        public int KorisnikID { get; set; }
        public IFormFile SlikaPozivnice { get; set; }
        
    }
}
