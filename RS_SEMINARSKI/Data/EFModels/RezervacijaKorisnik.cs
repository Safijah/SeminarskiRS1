using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class RezervacijaKorisnik
    {
        public string  KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }

        public int  RezervacijaID { get; set; }
        public Rezervacija Rezervacija { get; set; }
    }
}
