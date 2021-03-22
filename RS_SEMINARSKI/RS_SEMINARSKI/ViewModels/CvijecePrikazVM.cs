using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class CvijecePrikazVM
    {
        public class Row
        {
            public int CvijeceID { get; set; }
            public string TipCvijeca { get; set; }
            public string VrstaCvijeca { get; set; }
            public float CijenaCvijeca { get; set; }
            public IFormFile SlikaCvijeca { get; set; }
            public string PutanjaDoSlike { get; set; }

        }
        public string pretraga { get; set; }
        public List<Row> cvijece { get; set; }

        public int KorisnikID { get; set; }
        public int RolaID { get; set; }
    }
}
