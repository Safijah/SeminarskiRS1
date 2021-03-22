using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class Evidencija
    {
        public int EvidencijaID { get; set; }
        public int RezervacijaID { get; set; }
        public Rezervacija Rezervacija { get; set; }
        public int MeniID { get; set; }
        public Meni Meni { get; set; }

        public int Kolicina { get; set; }



    }
}
