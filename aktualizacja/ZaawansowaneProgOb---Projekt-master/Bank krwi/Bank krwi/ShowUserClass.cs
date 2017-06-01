using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_krwi
{
    class ShowUserClass
    {
        private int id;
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public string DataUrodzenia { get; private set; }
        public string GrupaKrwii { get; private set; }
        public string Plec { get; private set; }
        public string Adres { get; private set; }
        public string NumerTelefonu { get; private set; }

        public ShowUserClass(string imie, string nazwisko, string dataUrodzenia, string grupaKrwii, string plec, string adres, string numerTelefonu) {

            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.DataUrodzenia = dataUrodzenia;
            this.GrupaKrwii = grupaKrwii;
            this.Plec = plec;
            this.Adres = adres;
            this.NumerTelefonu = numerTelefonu;
        }



        public string GetName()
        {
            return this.Imie;
        }

        public string GetSurname()
        {
            return this.Nazwisko;
        }

        public string GetDataborn()
        {
            return this.DataUrodzenia;
        }

        public string GetBloodGroup()
        {
            return this.GrupaKrwii;
        }

        public string GetSex()
        {
            return this.Plec;
        }

        public string GetAddres()
        {
            return this.Adres;
        }

        public string GetPhoneNumber()
        {
            return this.NumerTelefonu;
        }

    }
}
