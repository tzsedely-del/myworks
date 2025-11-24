using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EtrendApp.Modellek;
using EtrendApp.Formok;

namespace EtrendApp.Formok
{
    public partial class RendelesForm : Form
    {
        // A kosár lista, ahová a kiválasztott termékek kerülnek
        private List<Termek> kosarLista = new List<Termek>();
        private Vasarlo vasarlo;
        private string kapottAdat;

        public RendelesForm()
        {
            InitializeComponent();
            InicializalForm();
           

        }

        public RendelesForm(Vasarlo vasarlo)
        {
            InitializeComponent();
            InicializalForm();
           
        }

        public RendelesForm(string adat)
        {
            InitializeComponent();
            kapottAdat = adat;
            textBox1.Text = kapottAdat;  // Beállítjuk a TextBox értékét az átvett adat alapján
        }

        private void InicializalForm()
        {
            // Példa termékek hozzáadása a ComboBox-hoz
            comboBox1.Items.Add("Pizza");
            comboBox1.Items.Add("Gyros");
            comboBox1.Items.Add("Hamburger");

            // NumericUpDown beállítása (minimum és maximum érték)
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 10;

            // Gomb esemény
            button1.Click += new EventHandler(BtnKosarhozAd_Click);
        }

        private void BtnKosarhozAd_Click(object sender, EventArgs e)
        {
        }

        private void FrissitKosarMegjelenites(Termek termek)
        {
            // Label létrehozása a GroupBox-ban a kiválasztott termékhez
            Label termekLabel = new Label();
            termekLabel.Text = $"{termek.Nev} - {termek.Mennyiseg}x - {termek.Ar * termek.Mennyiseg} Ft";
            termekLabel.AutoSize = true;

            // Új sorban való megjelenítéshez beállítjuk a helyzetét
            termekLabel.Location = new System.Drawing.Point(10, listBox1.Controls.Count * 25); // 25 pixeles távolság a sorok között

            // Hozzáadjuk a label-t a GroupBox-hoz
            listBox1.Controls.Add(termekLabel);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            /*
            
                // ListBox elemek átadása a második formnak
           //     List<string> SelectedItems = null;
                List<string> selectedItems = new List<string>();

                foreach (var item in listBox1.SelectedItems)
                {
                    selectedItems.Add(item.ToString());
                }

               
                // Második form létrehozása és elemek átadása
                var veglegesitesForm = new VeglegesitesForm((selectedItems));
                veglegesitesForm.Show();
                this.Hide();
                // Vagy secondForm.ShowDialog(); ha modális ablakot szeretnél

            */

            List<string> rendelTetelek = new List<string>();
            foreach (var item in listBox1.Items)
            {
                rendelTetelek.Add(item.ToString());
            
            }
            var veglegesitesForm = new VeglegesitesForm(rendelTetelek);
            veglegesitesForm.Show();
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /*  var veglegesitesForm = new VeglegesitesForm(listBox1); // Kosár lista átadása a formnak
veglegesitesForm.Show();
this.Hide(); // Elrejtjük az aktuális formot
*/

    }
    }

   

    // A Termek osztály a termékek kezeléséhez
    public class Termek
    {
        public string Nev { get; set; }
        public decimal Ar { get; set; }
        public int Mennyiseg { get; set; }

        public Termek(string nev, decimal ar, int mennyiseg)
        {
            Nev = nev;
            Ar = ar;
            Mennyiseg = mennyiseg;
        }
    }



namespace EtrendApp.Formok
{
    public partial class RendelesForm : Form
    {
        /*
        private Vasarlo Vasarlo;*/
        private Rendeles Rendeles;


        List<Termek> termekLista = new List<Termek>();

            /*
 {
    new Termek("Pizza", 1500),
    new Termek("Gyros", 1800),
    new Termek("Hamburger", 1200)
 }

            */
            /*
};
        List<Termek> kosar = new List<Termek> { };

        public RendelesForm(Vasarlo vasarlo)
        {
            InitializeComponent();
            Vasarlo = vasarlo;
            Rendeles = new Rendeles();

            // Példa termékek betöltése
            BetoltEtlap();
        }

    private void BetoltEtlap()
    { }


            // Menüpontok hozzáadása

 /*lstEtlap.Items.Add(new Termek("Pizza", 1500));
 lstEtlap.Items.Add(new Termek("Gyros", 1800));
 lstEtlap.Items.Add(new Termek("Hamburger", 1200));/
        }

        */
        private void btnKosarhozAd_Click(object sender, EventArgs e)
        {
           
        }

        private void FrissitKosarMegjelenites()
        {
          //  groupBox1.Items.Add($"{Termek.Nev} - {Termek.Mennyiseg}x - {Termek.Ar * Termek.Mennyiseg} Ft");
        }


            /*
            lstKosar.Items.Clear();
            foreach (var termek in Rendeles.KosarElemek)
            {
                lstKosar.Items.Add($"{termek.Nev} - {termek.Mennyiseg}x - {termek.Ar * termek.Mennyiseg} Ft");
            }

            lblVegosszeg.Text = $"Végösszeg: {Rendeles.Vegosszeg} Ft";
        }
        */

        private void btnBefejez_Click(object sender, EventArgs e)
        {
            /*
            var veglegesitesForm = new VeglegesitesForm(kosarLista); // Kosár lista átadása a formnak
            veglegesitesForm.Show();
            this.Hide(); // Elrejtjük az aktuális formot
            */
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ellenőrzés, hogy van-e kiválasztott termék
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Kérlek, válassz egy terméket!");
                return;
            }

            // Termék adatok begyűjtése
            string termekNev = comboBox1.SelectedItem.ToString();
            int mennyiseg = (int)numericUpDown1.Value;

            // Példa árak
            decimal ar = 0;
            switch (termekNev)
            {
                case "Pizza":
                    ar = 1500;
                    break;
                case "Gyros":
                    ar = 1800;
                    break;
                case "Hamburger":
                    ar = 1200;
                    break;
                default:
                    MessageBox.Show("Ismeretlen termék!");
                    return;
            }

            // Új Termek objektum létrehozása és hozzáadása a kosarLista-hoz
            Termek ujTermek = new Termek(termekNev, ar, mennyiseg);
            kosarLista.Add(ujTermek);

            // Kosár GroupBox frissítése
            FrissitKosarMegjelenites(ujTermek);
        }
        }
    }
// A véglegesítés gomb eseménye a RendelesForm-on

