using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class Meni
    {
        public int MeniID { get; set; }

        public int TipMenijaID { get; set; }
        public TipMenija TipMenija { get; set; }
        public string? PutanjaDoSlikeMenija { get; set; }

        public string NazivMenija { get; set; }
        public float CijenaMenija { get; set; }
        public bool IzSkladista { get; set; }


    }
}
