using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class Dekoracija
    {
        public int DekoracijaID { get; set; }
        public int TipDekoracijeID { get; set; }
        public TipDekoracije TipDekoracije { get; set; }

        public string  VrstaDekoracije { get; set; }
        public float  CijenaDekoracije { get; set; }
        public string? PutanjaDoSlikeDekoracije { get; set; }
    }
}
