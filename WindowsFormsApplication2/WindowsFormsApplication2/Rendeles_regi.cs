using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


        namespace EtrendApp.Modellek
    {
        public class Rendeles
        {
            // Kosár elemei
            public List<Termek> KosarElemek { get; private set; }

            // Rendelés végösszege
            public decimal Vegosszeg
            {
                get
                {
                    return KosarElemek.Sum(termek => termek.Ar * termek.Mennyiseg);
                }
            }

            public Rendeles()
            {
                KosarElemek = new List<Termek>();
            }

            // Termék hozzáadása a kosárhoz
            public void TermekHozzaad(Termek termek)
            {
                var letezoTermek = KosarElemek.FirstOrDefault(t => t.Nev == termek.Nev);
                if (letezoTermek != null)
                {
                    letezoTermek.Mennyiseg += termek.Mennyiseg;
                }
                else
                {
                    KosarElemek.Add(termek);
                }
            }

            // Termék eltávolítása a kosárból
            public void TermekEltavolit(string termekNev)
            {
                var termek = KosarElemek.FirstOrDefault(t => t.Nev == termekNev);
                if (termek != null)
                {
                    KosarElemek.Remove(termek);
                }
            }

            // Kosár ürítése
            public void KosarUrit()
            {
                KosarElemek.Clear();
            }
        
    
    public Vasarlo Vasarlo { get; set; }
        public List<Termek> Termekek { get; set; } = new List<Termek>();
        public bool VanKupon { get; set; }
        public string KuponKod { get; set; }
        public string FizetesiMod { get; set; }
        public bool ElfogadottAdatvedelmiNyilatkozat { get; set; }
    }

}



