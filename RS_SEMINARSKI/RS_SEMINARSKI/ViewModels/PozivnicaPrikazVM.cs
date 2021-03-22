using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class PozivnicaPrikazVM
    {
        public class Row
        {
            public int PozivnicaID { get; set; }
            public float CijenaPozivnice { get; set; }
            public string OpisPozivnice { get; set; }
            public string PutanjaDoSlikePozivnice { get; set; }
            public IFormFile SlikaPozivnice { get; set; }
          

        }
        public string pretraga { get; set; }
        public List<Row> pozivnice  { get; set; }

        public int KorisnikID { get; set; }
        public int RolaID { get; set; }
    }
}

