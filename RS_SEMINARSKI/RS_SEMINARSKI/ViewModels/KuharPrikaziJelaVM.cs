using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class KuharPrikaziJelaVM
    {
        public class Rows
        {
            public int JeloID { get; set; }
            public string NazivJela { get; set; }
        }
        public List<Rows> jela { get; set; }
    }
}
