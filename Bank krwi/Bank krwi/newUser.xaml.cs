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

namespace Bank_krwi
{
    /// <summary>
    /// Interaction logic for newUser.xaml
    /// </summary>
    public partial class newUser : Window
    {
        private SQLiteDataAdapter m_oDataAdapter = null;
        private DataSet m_oDataSet = null;
        private DataTable m_oDataTable = null;

        private IDonatorValidation donatorValidation = new DonatorValidationImplentation();

        public newUser()
        {
            InitializeComponent();
            InitBinding();
        }

        private void InitBinding()
        {
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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string imie = imieBox.Text;
            string nazwisko = nazwiskoBox.Text;
            string wiek = wiekBox.Text;
            string grupaKrwi = comboGr.Text;
            string plec = plecBox.Text;
            string adres = adresBox.Text;
            string telefon = telefonBox.Text;

            Donator donator = new Donator(imie, nazwisko, Int32.Parse(wiek), grupaKrwi, plec, adres, Int32.Parse(telefon));
            AddDonator(donator);
        }

        private void AddDonator(Donator donator) {
            donatorValidation.AddDonatorValidate(donator);

            /*   SQLiteDataAdapter m_oDataAdapter = null;
              DataSet m_oDataSet = null;
              DataTable m_oDataTable = null;

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
             lstItems.DataContext = m_oDataTable.DefaultView;*/

            DataRow oDataRow = m_oDataTable.NewRow();
            oDataRow[0] = m_oDataTable.Rows.Count + 1;
            oDataRow[1] = donator.Imie;
            oDataRow[2] = donator.Nazwisko;
            oDataRow[3] = donator.Wiek;
            oDataRow[4] = donator.GrupaKrw;
            oDataRow[5] = donator.Plec;
            oDataRow[6] = donator.Adres;
            oDataRow[7] = donator.Telefon;
            m_oDataTable.Rows.Add(oDataRow);
            m_oDataAdapter.Update(m_oDataSet);
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            /*  SQLiteDataAdapter m_oDataAdapter = null;
              DataSet m_oDataSet = null;

              SQLiteConnection oSQLiteConnection =
                  new SQLiteConnection("Data Source=BazaDanych.s3db");
              SQLiteCommand oCommand = oSQLiteConnection.CreateCommand();
              oCommand.CommandText = "SELECT * FROM Person";
              m_oDataAdapter = new SQLiteDataAdapter(oCommand.CommandText,
                  oSQLiteConnection);
              SQLiteCommandBuilder oCommandBuilder =
                  new SQLiteCommandBuilder(m_oDataAdapter);
              m_oDataSet = new DataSet();
              m_oDataAdapter.Fill(m_oDataSet);*/


            if (0 == lstItems.SelectedItems.Count)
            {
                return;
            }
            DataRow oDataRow = ((DataRowView)lstItems.SelectedItem).Row;
            oDataRow.Delete();
            m_oDataAdapter.Update(m_oDataSet);
        }

        private void Window_Closing(object sender,
            System.ComponentModel.CancelEventArgs e)
        {
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
