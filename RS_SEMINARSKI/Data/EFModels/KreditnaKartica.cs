using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class KreditnaKartica
    {
        public int KreditnaKarticaID { get; set; }
        public string BrojKreditneKartice { get; set; }
        public int MjesecIstekaKartice { get; set; }
        public int GodinaIstekaKartice { get; set; }
        public string CVC { get; set; }
        public string  KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        
    }
}
