using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class RezervacijaCvijece
    {
        public int CvijeceID { get; set; }
        public Cvijece Cvijece { get; set; }

        public int RezervacijaID { get; set; }
        public Rezervacija Rezervacija { get; set; }
        public int KolicinaNarucenogCvijeca { get; set; }

    }
}
