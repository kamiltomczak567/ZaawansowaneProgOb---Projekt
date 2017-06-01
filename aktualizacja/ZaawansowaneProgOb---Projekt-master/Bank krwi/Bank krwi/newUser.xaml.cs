﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;
using System.Text.RegularExpressions;

namespace Bank_krwi {
    /// <summary>
    /// Interaction logic for newUser.xaml
    /// </summary>
<<<<<<< HEAD
    public partial class NewUser : Window {
=======
    public partial class newUser : Window {
>>>>>>> 095e9f74102788fcb7d90c753b4243613454c1ef
        private SQLiteDataAdapter m_oDataAdapter = null;
        private DataSet m_oDataSet = null;
        private DataTable m_oDataTable = null;

        private IDonatorValidation donatorValidation = new DonatorValidationImplentation();

<<<<<<< HEAD
        public NewUser() {
            InitializeComponent();
            InitBinding();
        }
        // pobieranie danych z SQLLite
=======
        public newUser() {
            InitializeComponent();
            InitBinding();
        }

>>>>>>> 095e9f74102788fcb7d90c753b4243613454c1ef
        private void InitBinding() {
            SQLiteConnection oSQLiteConnection =
                new SQLiteConnection("Data Source=BazaDanych.s3db");
            SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
            oCommand.CommandText = "SELECT * FROM Person";
            m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                oSQLiteConnection);
            SQLiteCommandBuilder oCommandBuilder =
                new SQLiteCommandBuilder(m_oDataAdapter);
            m_oDataSet = new DataSet();
            m_oDataAdapter.Fill(m_oDataSet);
            m_oDataTable = m_oDataSet.Tables[0];
            lstItems.DataContext = m_oDataTable.DefaultView;
        }

<<<<<<< HEAD
        private void Btn_Add_Click(object sender, RoutedEventArgs e) {
            string Imie = ImieBox.Text;
            string Nazwisko = NazwiskoBox.Text;
            string Wiek = WiekBox.Text;
            string GrupaKrwi = ComboGr.Text;
            string Plec = PlecBox.Text;
            string Adres = AdresBox.Text;
            string Telefon = TelefonBox.Text;
            string OddanaKrew = OddanaKrewBox.Text;

            if(!OddanaKrew.All(char.IsDigit)) {
                throw new FormatException("Ilość musi być cyfrą całkowitą");
            }

            Donator donator = new Donator(Imie, Nazwisko, Int32.Parse(Wiek), GrupaKrwi, Plec, Adres, Int32.Parse(Telefon), OddanaKrew);
=======
        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            string imie = imieBox.Text;
            string nazwisko = nazwiskoBox.Text;
            string wiek = wiekBox.Text;
            string grupaKrwi = comboGr.Text;
            string plec = plecBox.Text;
            string adres = adresBox.Text;
            string telefon = telefonBox.Text;
            string oddanaKrew = oddanaKrewBox.Text;

            if(!oddanaKrew.All(char.IsDigit)) {
                throw new FormatException("Ilość musi być cyfrą całkowitą");
            }

            Donator donator = new Donator(imie, nazwisko, Int32.Parse(wiek), grupaKrwi, plec, adres, Int32.Parse(telefon), oddanaKrew);
>>>>>>> 095e9f74102788fcb7d90c753b4243613454c1ef
            AddDonator(donator);
        }

        private void AddDonator(Donator donator) {
            donatorValidation.AddDonatorValidate(donator);
<<<<<<< HEAD
=======

>>>>>>> 095e9f74102788fcb7d90c753b4243613454c1ef
            DataRow oDataRow = m_oDataTable.NewRow();
            oDataRow[0] = m_oDataTable.Rows.Count + 1; // id zlicz i powiększ o 1
            oDataRow[1] = donator.Imie;
            oDataRow[2] = donator.Nazwisko;
            oDataRow[3] = donator.Wiek;
            oDataRow[4] = donator.GrupaKrw;
            oDataRow[5] = donator.Plec;
            oDataRow[6] = donator.Adres;
            oDataRow[7] = donator.Telefon;
            oDataRow[8] = donator.IloscOddanejKrwi;
            m_oDataTable.Rows.Add(oDataRow);
            m_oDataAdapter.Update(m_oDataSet);
        }

        private void EditDonator(Donator donator) {
            donatorValidation.AddDonatorValidate(donator);
            DataRow oDataRow = m_oDataTable.NewRow();
            oDataRow[0] = m_oDataTable.Rows.Count + 1;// id zlicz i powiększ o 1
            oDataRow[1] = donator.Imie;
            oDataRow[2] = donator.Nazwisko;
            oDataRow[3] = donator.Wiek;
            oDataRow[4] = donator.GrupaKrw;
            oDataRow[5] = donator.Plec;
            oDataRow[6] = donator.Adres;
            oDataRow[7] = donator.Telefon;
            oDataRow.EndEdit();
            m_oDataAdapter.Update(m_oDataSet);
        }

<<<<<<< HEAD
        private void Btn_Edit_Click(object sender, RoutedEventArgs e) {
            string Imie = ImieBox.Text;
            string Nazwisko = NazwiskoBox.Text;
            string Wiek = WiekBox.Text;
            string GrupaKrwi = ComboGr.Text;
            string Plec = PlecBox.Text;
            string Adres = AdresBox.Text;
            string Telefon = TelefonBox.Text;
            string OddanaKrew = OddanaKrewBox.Text;

            if(!OddanaKrew.All(char.IsDigit)) {
=======
        private void btnEdit_Click(object sender, RoutedEventArgs e) {
            string imie = imieBox.Text;
            string nazwisko = nazwiskoBox.Text;
            string wiek = wiekBox.Text;
            string grupaKrwi = comboGr.Text;
            string plec = plecBox.Text;
            string adres = adresBox.Text;
            string telefon = telefonBox.Text;
            string oddanaKrew = oddanaKrewBox.Text;

            if(!oddanaKrew.All(char.IsDigit)) {
>>>>>>> 095e9f74102788fcb7d90c753b4243613454c1ef
                throw new FormatException("Ilość musi być cyfrą całkowitą");
            }

            if(0 == lstItems.SelectedItems.Count) {
<<<<<<< HEAD
                return; // Jeżeli nie wybrano zadnego dawcy - nie rob nic
            }
            DataRow oDataRow = ((DataRowView)lstItems.SelectedItem).Row;
            oDataRow.BeginEdit();
            oDataRow[1] = Imie;
            oDataRow[2] = Nazwisko;
            oDataRow[3] = Wiek;
            oDataRow[4] = GrupaKrwi;
            oDataRow[5] = Plec;
            oDataRow[6] = Adres;
            oDataRow[7] = Telefon;
            oDataRow[8] = OddanaKrew;
=======
                return;
            }
            DataRow oDataRow = ((DataRowView)lstItems.SelectedItem).Row;
            oDataRow.BeginEdit();
            oDataRow[1] = imie;
            oDataRow[2] = nazwisko;
            oDataRow[3] = wiek;
            oDataRow[4] = grupaKrwi;
            oDataRow[5] = plec;
            oDataRow[6] = adres;
            oDataRow[7] = telefon;
            oDataRow[8] = oddanaKrew;
>>>>>>> 095e9f74102788fcb7d90c753b4243613454c1ef
            oDataRow[9] = "BRAK";
            oDataRow.EndEdit();
            m_oDataAdapter.Update(m_oDataSet);
        }


<<<<<<< HEAD
        private void Btn_Delete_Click(object sender, RoutedEventArgs e) {
            if(0 == lstItems.SelectedItems.Count) { // Jeżeli nie wybrano zadnego dawcy - nie rob nic
=======
        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            if(0 == lstItems.SelectedItems.Count) {
>>>>>>> 095e9f74102788fcb7d90c753b4243613454c1ef
                return;
            }
            DataRow oDataRow = ((DataRowView)lstItems.SelectedItem).Row;
            oDataRow.Delete();
            m_oDataAdapter.Update(m_oDataSet);
        }

        private void Window_Closing(object sender,
            System.ComponentModel.CancelEventArgs e) {
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e) {
            List<string> data = new List<string>();
            data.Add("Wybierz");
            data.Add("0Rh-");
            data.Add("0Rh+");
            data.Add("ARh-");
            data.Add("ARh+");
            data.Add("BRh-");
            data.Add("BRh+");
            data.Add("ABRh-");
            data.Add("ABRh+");
            var combo = sender as ComboBox;
            combo.ItemsSource = data;
            combo.SelectedIndex = 0;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

<<<<<<< HEAD
        private void Btn_AddBloodClick(object sender, RoutedEventArgs e) {
=======
        private void addBloodBtn_Click(object sender, RoutedEventArgs e) {
>>>>>>> 095e9f74102788fcb7d90c753b4243613454c1ef
            string dodatkowaKrew = bloodToGive.Text;

            if(String.IsNullOrWhiteSpace(dodatkowaKrew) || dodatkowaKrew.All(char.IsDigit)) { // sprawdzamy, czy uzytkownik wpisal jakaś wartość i czy wszystkie znaki są cyfrą 
                if(0 == lstItems.SelectedItems.Count) { // Jeżeli nie wybrano zadnego dawcy - nie rob nic
                    return;
                }

                DataRow oDataRow = ((DataRowView)lstItems.SelectedItem).Row; //wybiera obiekt z listy i zamienia go na typ DataRowView
                oDataRow.BeginEdit();
                oDataRow[8] = Convert.ToInt32(oDataRow[8]) + Int32.Parse(dodatkowaKrew); // Dodaje wpisana ilosc do ogolnej wartosci krwi

                int iloscOddanejKrwi = Convert.ToInt32(oDataRow[8]);
                if(iloscOddanejKrwi >= 5800 && (string)oDataRow[9] == "BRAK") {
                    MessageBox.Show(oDataRow[1] + " " + oDataRow[2] + " uzyskał odznakę brązową!");
                    oDataRow[9] = "BRAZAWA";
                } else if(iloscOddanejKrwi >= 12000 && ((string)oDataRow[9] == "BRAZAWA" || (string)oDataRow[9] == "BRAK")) {
                    MessageBox.Show(oDataRow[1] + " " + oDataRow[2] + " uzyskał odznakę srebrną!");
                    oDataRow[9] = "SREBRNA";
                } else if(iloscOddanejKrwi >= 20000 && ((string)oDataRow[9] == "SREBRNA" || (string)oDataRow[9] == "BRAZAWA" || (string)oDataRow[9] == "BRAK")) {
                    MessageBox.Show(oDataRow[1] + " " + oDataRow[2] + " uzyskał odznakę złotą!");
                    oDataRow[9] = "ZLOTA";
                }

                oDataRow.EndEdit();
                m_oDataAdapter.Update(m_oDataSet); // zapisuje do bazy
                bloodToGive.Clear();
            } else {
                throw new FormatException("Ilość musi być cyfrą całkowitą");
            }
        }

        private void lstItems_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            DataRowView index = (DataRowView)lstItems.SelectedItem; //wybiera obiekt z listy i zamienia go na typ DataRowView
            if(index == null) { // Jeżeli nie znaleziono indeksu, to powróć(nie wykonuj reszty kodu)
                return;
            }

            object[] selectedItemData = index.Row.ItemArray; // pobiera wszystkie dane z danego wiersza i przypisuje je do tablicy obiektow

<<<<<<< HEAD
            ImieBox.Text = (string)selectedItemData[1];
            NazwiskoBox.Text = (string)selectedItemData[2];
            WiekBox.Text = (string)selectedItemData[3];
            ComboGr.SelectedItem = (string)selectedItemData[4];
            PlecBox.Text = (string)selectedItemData[5];
            AdresBox.Text = (string)selectedItemData[6];
            TelefonBox.Text = (string)selectedItemData[7];
            OddanaKrewBox.Text = ((long)selectedItemData[8]).ToString();
=======
            imieBox.Text = (string)selectedItemData[1];
            nazwiskoBox.Text = (string)selectedItemData[2];
            wiekBox.Text = (string)selectedItemData[3];
            comboGr.SelectedItem = (string)selectedItemData[4];
            plecBox.Text = (string)selectedItemData[5];
            adresBox.Text = (string)selectedItemData[6];
            telefonBox.Text = (string)selectedItemData[7];
            oddanaKrewBox.Text = ((long)selectedItemData[8]).ToString();
>>>>>>> 095e9f74102788fcb7d90c753b4243613454c1ef
        }
    }
}
