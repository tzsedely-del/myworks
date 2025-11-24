using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtrendApp.Modellek
{
    public class Termek
    {
        public string Nev { get; set; }
        public decimal Ar { get; set; }
        public int Mennyiseg { get; set; }

        public Termek(string nev, decimal ar)
        {
            Nev = nev;
            Ar = ar;
            Mennyiseg = 1;
        }
    }
}
    
