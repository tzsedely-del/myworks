using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtrendApp.Modellek
{
    public class Vasarlo
    {
        internal string Utcahazszam;

        public string Nev { get; set; }
        public string Telefon { get; set; }
        public string Varos { get; set; }
        public string Cim { get; set; }
        public string FizetesiMod { get; set; } // Készpénz, Bankkártya
        public string Kartyaszam { get; set; } // Ha bankkártya
    }
    public class Cim
    {
        internal string Utca_Hazszam;

        public string Varos { get; set; }
        public string UtcaHazszam { get; set; }
    }
}

  

