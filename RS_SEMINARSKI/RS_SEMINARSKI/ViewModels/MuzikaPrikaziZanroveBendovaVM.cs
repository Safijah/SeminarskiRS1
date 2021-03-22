using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class MuzikaPrikaziZanroveBendovaVM
    {
        public class Rows
        {
            public int BendID { get; set; }
            public string NazivZanra { get; set; }
        }
        public List<Rows> BendZanrovi { get; set; }
    }
}
