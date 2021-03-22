using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class Fotograf
    {
        public int FotografID { get; set; }
        public int FotografijaID { get; set; }
        public Fotografija Fotografija { get; set; }

        public string ImeFotografa { get; set; }
        public string PrezimeFotografa { get; set; }

        public float SatnicaSlikanja { get; set; }
        public string? PutanjaDoSlikeFotografa { get; set; }

    }
}
