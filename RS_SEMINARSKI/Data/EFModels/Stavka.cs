using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class Stavka
    {
        //ovo je jedna stavka narudžbe.
        public int StavkaID { get; set; }
        public int MeniID { get; set; }
        public Meni Meni { get; set; }

        public int StavkaUlazID { get; set; }
        public StavkaUlaz StavkaUlaz { get; set; }
        public int KolicinaNarucenog { get; set; }

    }
}
