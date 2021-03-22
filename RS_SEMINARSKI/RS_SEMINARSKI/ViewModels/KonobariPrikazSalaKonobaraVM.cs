using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class KonobariPrikazSalaKonobaraVM
    {
        public class Rows
        {
            public int SalaID { get; set; }
            public string NazivSale { get; set; }
        }
        public List<Rows> SaleKonobari { get; set; }
        public string KorisnikID { get; set; }
    }
}
