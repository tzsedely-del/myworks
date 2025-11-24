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
using System.IO;

namespace EtrendApp.Formok
{
    public partial class FoForm : Form
    {
        private List<UserData> users = new List<UserData>();
        private object varos;

        private string userDataFilePath = "user_data.txt"; // Felhasználói adatokat tartalmazó fájl
        private string recipeFilePath = "recipe.txt";      // A recept adatokat tartalmazó fájl

        public Vasarlo Vasarlo { get; private set; }

        public FoForm()
        {
            InitializeComponent();
            Vasarlo = new Vasarlo();
            LoadCities(); // Városok betöltése
        }



        private void btnTovabb_Click(object sender, EventArgs e)
        { }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           /* if (textBox1.Text != null && textBox2.Text != null && comboBox1.SelectedItem.ToString() != null && textBox3.Text != null)
            { bt_Form1_tovabb.Visible = true; }
            */
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void bt_Form1_tovabb_Click(object sender, EventArgs e)
        /*   {


                   Vasarlo.Nev = textBox1.Text;
                   Vasarlo.Telefon = textBox2.Text;
                   Vasarlo.Varos = comboBox1.SelectedItem.ToString();
                   Vasarlo.Utcahazszam = textBox3.Text;

                   var rendelesForm = new RendelesForm(Vasarlo);
                   rendelesForm.Show();
                   this.Hide();

            //   else { MessageBox.Show("HIBA! Nem töltött ki minden mezőt!"); }

           }
          */

        {
            string newName = textBox1.Text;
            string newPhone = textBox2.Text;
            string newCity = comboBox1.SelectedItem?.ToString();
            string newCim = textBox3.Text;

            // Ellenőrizzük, hogy minden mező ki van töltve
            if (!string.IsNullOrEmpty(newName) && !string.IsNullOrEmpty(newPhone) && !string.IsNullOrEmpty(newCity) && !string.IsNullOrEmpty(newCim))
            {
                // Új sorszám: a listában lévő felhasználók száma + 1
                int newSorszam = users.Count + 1;

                // Új felhasználó létrehozása
                UserData newUser = new UserData
                {
                    Sorszam = newSorszam,
                    Nev = newName,
                    Telefon = newPhone,
                    Varos = newCity,
                    Cim = newCim,
                };

                // Hozzáadjuk az új felhasználót a listához
                users.Add(newUser);

                // Hozzáadjuk a felhasználót a user_data.txt fájlhoz
                AppendUserDataToFile(newUser);

                // Kiírjuk az adatokat a recipe.txt első sorába
                WriteToRecipeFile(newUser);

                // A felhasználó sorszámát átadjuk a következő formnak
                PassUserIndexToNextForm(newUser.Sorszam);

                // A felhasználó megjelenítése a ListBox-ban
                listBox1.Items.Add($"{newUser.Nev} ({newUser.Cim})");

                // Hozzáadjuk a város nevét a város ComboBox-hoz, ha még nincs benne
                if (!comboBox2.Items.Contains(newSorszam))
                {
                    comboBox2.Items.Add(newSorszam);
                }

                // Üzenet az új felhasználó sikeres hozzáadásáról
                MessageBox.Show("Új felhasználó sikeresen hozzáadva!");
            }
            else
            {
                MessageBox.Show("Kérem, töltse ki az összes mezőt.");
            }
        }
        private void AppendUserDataToFile(UserData newUser)
        {
            // A felhasználói adatokat hozzáadjuk a user_data.txt fájlhoz
            string userData = $"{newUser.Nev}, {newUser.Telefon}, {newUser.Varos}, {newUser.Cim}";
            File.AppendAllText(userDataFilePath, userData + Environment.NewLine);
        }

        private void WriteToRecipeFile(UserData newUser)
        {
            // Kiírjuk az adatokat a recipe.txt első sorába
            if (File.Exists(recipeFilePath))
            {
                var lines = File.ReadAllLines(recipeFilePath);
                if (lines.Length > 0)
                {
                    // Módosítjuk az első sort
                    lines[0] = $"{newUser.Nev} ({newUser.Cim})";
                    File.WriteAllLines(recipeFilePath, lines); // Felülírjuk a file-t
                }
                else
                {
                    // Ha üres a recipe.txt fájl, hozzáadjuk az adatokat
                    File.WriteAllText(recipeFilePath, $"{newUser.Nev} ({newUser.Cim})" + Environment.NewLine);
                }
            }
            else
            {
                // Ha nem létezik a fájl, létrehozzuk és beleírjuk az adatokat
                File.WriteAllText(recipeFilePath, $"{newUser.Nev} ({newUser.Cim})" + Environment.NewLine);
            }
        }

        private void PassUserIndexToNextForm(int userIndex)
        {
            // A felhasználó sorszámát átadjuk a következő formnak
       //     var nextForm = new RendelesForm(userIndex);
            var rendelesForm = new RendelesForm(Vasarlo);
            rendelesForm.Show();
            this.Hide();
            //nextForm.Show();
        }




        // Fájl beolvasása és feldolgozása
        //  private void LoadUserDataFromFile()

        //   {
        //       string filePath = "user_data.txt";

        private void LoadUserData()
        {
            // Ellenőrizzük, hogy létezik-e a user_data.txt fájl
            if (File.Exists(userDataFilePath))
            {
                // Beolvassuk a fájl tartalmát
                var lines = File.ReadAllLines(userDataFilePath);

                foreach (var line in lines)
                {
                    // Az adatok splitelése a megfelelő karakterek mentén (pl. ',')
                    var data = line.Split(',');

                    // Hozzáadjuk a listához a felhasználókat
                    if (data.Length == 4)
                    {
                        users.Add(new UserData
                        {
                            Sorszam = users.Count + 1,  // A sorszámot itt számoljuk ki
                            Nev = data[0],
                            Telefon = data[1],
                            Varos = data[2],
                            Cim = data[3]
                        });
                    }
                }
            }
        }

                    /*
                    if (File.Exists(filePath))
                    {


                        try
                        {
                            using (StreamReader reader = new StreamReader(filePath))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    // Az egyes sorokban található adatokat feldolgozzuk
                                    string[] parts = line.Split(new string[] { ", " }, StringSplitOptions.None);

                                    if (parts.Length == 4)
                                    {
                                        // A fájlból való beolvasás után a sorszám, név, cím, telefon szétválasztása
                                        int sorszam = int.Parse(parts[0].Split(':')[1].Trim());
                                        string nev = parts[1].Split(':')[1].Trim();
                                        string cim = parts[2].Split(':')[1].Trim();
                                        string telefon = parts[3].Split(':')[1].Trim();

                                        UserData user = new UserData
                                        {
                                            Sorszam = sorszam,
                                            Nev = nev,
                                            Varos = varos,
                                            Cim = cim,
                                            Telefon = telefon
                                        };

                                        // Felhasználó hozzáadása a listához
                                        users.Add(user);

                                        // Feltöltjük a ComboBox-ot a felhasználók nevével
                                        comboBox2.Items.Add(nev);
                                    }
                                }
                            }
                        }




                        catch (Exception ex)
                        {

                            //      MessageBox.Show("Hiba történt a fájl beolvasásakor: " + ex.Message);
                        }

                    }
                    */


                    /*
                    else
                    {
                        MessageBox.Show("A fájl nem található.");
                    }
                    */
                

        // ComboBox kiválasztásának kezelése (felhasználó adatainak betöltése)
        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        // ComboBox kiválasztásának kezelése

        private void DisplayUserData()
        {
            listBox1.Items.Clear();

            foreach (var user in users)
            {
                listBox1.Items.Add($"Sorszám: {user.Sorszam}, Név: {user.Nev}, Cím: {user.Cim}, Telefon: {user.Telefon}");
            }
        }

        public class UserData
        {
            public int Sorszam { get; set; }
            public string Nev { get; set; }
            public string Cim { get; set; }
            public string Telefon { get; set; }
            public object Varos { get; internal set; }
        }

        private void LoadCities()
        {
            try
            {
                // Fájl beolvasása
                string[] varosok = File.ReadAllLines("cities.txt");

                // Városok hozzáadása a ComboBox-hoz
                foreach (string varos in varosok)
                {
                    comboBox1.Items.Add(varos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a fájl beolvasásakor: " + ex.Message);
            }


            // Lépés a következő formra



        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newName = textBox1.Text;
            string newPhone = textBox2.Text;
            string newCity = comboBox1.SelectedItem.ToString();
            string newCim = textBox3.Text;

            if (!string.IsNullOrEmpty(newName) && !string.IsNullOrEmpty(newPhone) && !string.IsNullOrEmpty(newCity) && !string.IsNullOrEmpty(newCim))
            {
                int newSorszam = users.Count + 1; // Új sorszám
                UserData newUser = new UserData
                {
                    Sorszam = newSorszam,
                    Nev = newName,
                    Telefon = newPhone,
                    Varos = newCity,
                    Cim = newCity,
                };

                // Hozzáadjuk az új felhasználót a listához
                users.Add(newUser);

                // Új felhasználó megjelenítése a ListBox-ban
                listBox1.Items.Add($"{newUser.Nev} ({newUser.Cim})");

                // Hozzáadjuk a város nevét a város ComboBox-hoz, ha még nincs benne
                if (!comboBox2.Items.Contains(newSorszam))
                {
                    comboBox2.Items.Add(newSorszam);
                }

                // Üzenet az új felhasználó sikeres hozzáadásáról
                MessageBox.Show("Új felhasználó sikeresen hozzáadva!");
            }
            else
            {
                MessageBox.Show("Kérem, töltse ki az összes mezőt.");
            }

        

            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // A kiválasztott név alapján keresünk a listában
            string selectedName = comboBox2.SelectedItem.ToString();
            UserData selectedUser = users.Find(user => user.Nev == selectedName);

            // Kitöltjük a megfelelő mezőket
            if (selectedUser != null)
            {
                textBox1.Text = selectedUser.Nev;
                textBox2.Text = selectedUser.Cim;
                textBox3.Text = selectedUser.Telefon;

                // Város ComboBox beállítása a sorszám alapján
                comboBox1.SelectedItem = selectedUser.Varos;
            }
        }
        }
    }


    
    


