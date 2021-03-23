using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.ViewModels
{
    public class RacunVM
    {
        public int RacunID { get; set; }
        public int RezervacijaID { get; set; }
        public DateTime dtmDate { get; set; }
        public List<SelectListItem> nacinPlacanja { get; set; }
        public int nacinPlacanjaID { get; set; }
        public float UkupanIznos { get; set; }
        public string KreditnaKarticaBroj { get; set; }
        //public int KreditnaKarticaBroj { get; set; }
        public int MjesecIstekaKartice { get; set; }
        public int GodinaIstekaKartice { get; set; }
        public string CVC { get; set; }
    }
}
