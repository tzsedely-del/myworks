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
    public partial class Form3 : Form
    {
        private Vasarlo _vasarlo;
        private List<Termek> _rendelesTermekek = new List<Termek>();

        public Form3(Vasarlo vasarlo)
        {
            InitializeComponent();
            _vasarlo = vasarlo;
        }

        private void btnKosarbaHozzaad_Click(object sender, EventArgs e)
        {
            /*
            var kivalasztottTermek = cboTermek.SelectedItem as Termek;
            if (kivalasztottTermek != null)
            {
                _rendelesTermekek.Add(kivalasztottTermek);
                lstKosar.Items.Add($"{kivalasztottTermek.Nev} - {kivalasztottTermek.Mennyiseg} db");
            }
            */
        }

        private void btnPenzunkentLezar_Click(object sender, EventArgs e)
        {
            var rendeles = new Rendeles
            {
                /*
                Vasarlo = _vasarlo,
                Termekek = _rendelesTermekek
                */
            };

            var form4 = new Form4(rendeles);
            form4.Show();
            this.Hide();
        }
    }
}
