using EtrendApp.Modellek;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form4 : Form
    {
        private Rendeles _rendeles;

        public Form4(Rendeles rendeles)
        {
            InitializeComponent();
            _rendeles = rendeles;
        }
    }

    /*
    private void btnRendelésKovetkezo_Click(object sender, EventArgs e)


         {
        // Kupon kód ellenőrzése
        if (!string.IsNullOrEmpty(txtKuponKod.Text))
        {
            _rendeles.KuponKod = txtKuponKod.Text;
            _rendeles.VanKupon = true;
        }

        // Adatvédelmi nyilatkozat elfogadása
        if (!chkAdatvedelmiNyilatkozat.Checked)
        {
            MessageBox.Show("Az adatvédelmi nyilatkozatot el kell fogadni.");
            return;
        }

        // Fizetési mód
        if (rdoKespenz.Checked)
            _rendeles.FizetesiMod = "Készpénz";
        else if (rdoBankkartya.Checked)
            _rendeles.FizetesiMod = "Bankkártya";

        // Rendelés véglegesítése
        MessageBox.Show("A rendelés sikeresen véglegesítve!");
        this.Close();
    }

*/
}

