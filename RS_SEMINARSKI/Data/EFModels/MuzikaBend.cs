using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class MuzikaBend
    {
        public int MuzikaBendID { get; set; }
        public int MuzikaID { get; set; }
        public Muzika Muzika { get; set; }
        public int BendID { get; set; }
        public Bend Bend { get; set; }

    }
}
