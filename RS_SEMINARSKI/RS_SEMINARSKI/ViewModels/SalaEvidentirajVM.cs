using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class SalaEvidentirajVM
    {
        public int SalaID { get; set; }
        public int KapacitetSale { get; set; }
        public string OpisSale { get; set; }
        public string NazivSale { get; set; }
        public float CijenaIznajmljivanjaSale { get; set; }
        public IFormFile SlikaSale { get; set; }
        public string PutanjaDoSlike { get; set; }
        public string KorisnikID { get; set; }
    }
}
