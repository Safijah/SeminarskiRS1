using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class Pozivnica
    {
        public int PozivnicaID { get; set; }
        //public string NazivPozivnice { get; set; }
        public float CijenaPozivnice { get; set; }
        public string OpisPozivnice { get; set; }
        public string? PutanjaDoSlikePozivnice { get; set; }

    }
}
