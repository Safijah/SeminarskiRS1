using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class Bend
    {
        public int BendID { get; set; }
        public string NazivBenda { get; set; }
        public float SatnicaSviranja { get; set; }
        public string  OpisBenda { get; set; } //napisemo koje instrumente sviraju i koje repertoar sviraju
        public string? PutanjaDoSlikeBenda { get; set; }

    }
}
