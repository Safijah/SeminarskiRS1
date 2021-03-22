using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class SalaKonobar
    {

        public int SalaKonobarID { get; set; }
        public int SalaID { get; set; }
        public Sala Sala { get; set; }
        public int KonobarID { get; set; }
        public Konobar Konobar { get; set; }

    }
}
