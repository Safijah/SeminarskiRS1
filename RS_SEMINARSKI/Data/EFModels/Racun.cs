using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class Racun
    {
        public int RacunID { get; set; }

        //public int RezervacijaID { get; set; }
        //public Rezervacija Rezervacija { get; set; }
        public float IznosRacuna { get; set; }
        public int ? KreditnaKarticaID { get; set; }
        public KreditnaKartica KreditnaKartica { get; set; }
    }
}
