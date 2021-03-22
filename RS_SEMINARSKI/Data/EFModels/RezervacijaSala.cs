using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class RezervacijaSala
    {
        public int RezervacijaID { get; set; }
        public Rezervacija Rezervacija { get; set; }

        public int SalaID { get; set; }
        public Sala Sala { get; set; }
    }
}
