using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public  class StavkaUlaz
    {
        //ovo je račun sa svim stavkama.
        public int StavkaUlazID { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public List<Stavka> StavkeRacuna { get; set; }


    }
}
