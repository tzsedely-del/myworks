using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtrendApp.Modellek
{
    public class Rendeles_uj
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

        public Rendeles_uj()
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
    }
}
    