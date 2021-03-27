using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class PrikazKorisnikaVM
    {
        public class Row
        {

        public string KorisnikID { get; set; }
        public string ImeiPrezime { get; set; }
        }
        public List<Row> Korisnici { get; set; }
    }
}
