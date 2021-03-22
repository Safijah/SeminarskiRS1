using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class RezervacijaDekoracija
    {
        public int RezervacijaID { get; set; }
        public Rezervacija  Rezervacija { get; set; }
        public int DekoracijaID { get; set; }
        public Dekoracija Dekoracija { get; set; }
        public int KolicinaNarucenihDekoracija { get; set; }
    }
}
