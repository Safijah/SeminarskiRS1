using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class MeniPrikazVM
    {
        public class Row
        {
            public int MeniID { get; set; }
            public string TipMenija { get; set; }
            public string NazivMenija { get; set; }
            public float CijenaMenija { get; set; }
            public IFormFile SlikaMenija { get; set; }
            public string PutanjaDoSlike { get; set; }
        }
        public string pretraga { get; set; }
        public List<Row> meniji { get; set; }

        public string KorisnikID { get; set; }
        public int RolaID { get; set; }
    }
}

