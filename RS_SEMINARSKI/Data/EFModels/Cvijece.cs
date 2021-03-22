using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class Cvijece
    {
        public int CvijeceID { get; set; }
        public TipCvijeca TipCvijeca { get; set; }
        public int TipCvijecaID { get; set; }

        public string VrstaCvijeca { get; set; }
        public float CijenaCvijeca  { get; set; }
        public string? PutanjaDoSlikeCvijeca { get; set; }

    }
}
