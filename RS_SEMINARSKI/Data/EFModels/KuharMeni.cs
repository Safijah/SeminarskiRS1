using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.EFModels
{
    public class KuharMeni
    {
        
        public int MeniID { get; set; }
        public Meni Meni { get; set; }
        
        public int KuharID { get; set; }
        public Kuhar Kuhar { get; set; }


    }
}
