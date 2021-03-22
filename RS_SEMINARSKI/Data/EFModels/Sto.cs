using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EFModels
{
    public class Sto
    {
        public int StoID { get; set; }

        public int SalaID { get; set; }
        public Sala Sala { get; set; }
       
        public int KapacitetStola { get; set; }
        public string OpisStola { get; set; }
    }
}
