using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class RezervacijaFotograf
    {
        public int RezervacijaID { get; set; }
        public Rezervacija Rezervacija { get; set; }

        public int FotografID { get; set; }
        public Fotograf Fotograf { get; set; }
    }
}
