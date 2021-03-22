﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class Rezervacija
    {
        public int RezervacijaID { get; set; }
        public int? BendID { get; set; }
        public Bend Bend { get; set; }

        public int ? PozivnicaID { get; set; }
        public Pozivnica Pozivnica { get; set; }
        public DateTime DatumVjencanja { get; set; }
        public float VremenskoTrajanjeVjencanja { get; set; }
        public int ? RacunID { get; set; }
        public Racun  Racun { get; set; }
        public string StatusRezervacije { get; set; }
        public string NacinPlacanjaRacuna { get; set; }
        public int KolicinaPozivnica { get; set; }
    }
}
