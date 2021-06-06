using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class FotografPrikazVM
    {
    public class Row
    {
        public int FotografID { get; set; }
        public string Fotografija { get; set; }
        public string ImeFotografa { get; set; }
        public string PrezimeFotografa { get; set; }
        public float SatnicaSlikanja { get; set; }
       
        public IFormFile SlikaCvijeca { get; set; }
        public string PutanjaDoSlikeFotografa { get; set; }
            public int Rezervisano { get; set; }

        }
    public string pretraga { get; set; }
    public List<Row> fotografi { get; set; }

    public string KorisnikID { get; set; }
    public int RolaID { get; set; }
}
}
