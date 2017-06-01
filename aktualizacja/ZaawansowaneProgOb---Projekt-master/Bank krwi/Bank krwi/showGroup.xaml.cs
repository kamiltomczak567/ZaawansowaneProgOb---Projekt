using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Bank_krwi
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ShowGroup : Window
    {
        List<Donator> donators = new List<Donator>();

        public ShowGroup()
        {
            InitializeComponent();
        }

        private void Btn_Click_0Rh0(object sender, RoutedEventArgs e)
        {
            string a = "0Rh-";
            showUser showUser = new showUser(a);
            ReadDonators(showUser);
            showUser.Show();
        }

        private void Btn_Click_0Rh1(object sender, RoutedEventArgs e)
        {
            string a = "0Rh+";
            showUser showUser = new showUser(a);
            ReadDonators(showUser);
            showUser.Show();
        }

        private void Btn_Click_BRh1(object sender, RoutedEventArgs e)
        {
            string a = "BRh+";
            showUser showUser = new showUser(a);
            ReadDonators(showUser);
            showUser.Show();
        }

        private void Btn_Click_BRh0(object sender, RoutedEventArgs e)
        {
            string a = "BRh-";
            showUser showUser = new showUser(a);
            ReadDonators(showUser);
            showUser.Show();

        }

        private void Btn_Click_ARh1(object sender, RoutedEventArgs e)
        {
            string a = "ARh+";
            showUser showUser = new showUser(a);
            ReadDonators(showUser);
            showUser.Show();
        }

        private void Btn_Click_ARh0(object sender, RoutedEventArgs e)
        {
            string a = "ARh-";
            showUser showUser = new showUser(a);
            ReadDonators(showUser);
            showUser.Show();

        }

        private void Btn_Click_ABRh1(object sender, RoutedEventArgs e)
        {
            string a = "ABRh+";
            showUser showUser = new showUser(a);
            ReadDonators(showUser);
            showUser.Show();
        }

        private void Btn_Click_ABRh0(object sender, RoutedEventArgs e)
        {
            string a = "ABRh-";
            showUser showUser = new showUser(a);
            ReadDonators(showUser);
            showUser.Show();
        }

        /// <summary>
        /// Zapisuje wszystkich dawców krwi do listy
        /// </summary>
        /// <param name="showUser">dane o wybranych dawcach</param>
        private void ReadDonators(showUser showUser) {
            donators.Clear();
            //for po wszystkich kolumnach z showUser
            for(int i = 0; i < showUser.m_oDataTable.Rows.Count; i++) {
                //dane o konkretnym dawcy jako lista obiektów
                var ZawartoscTabeli = showUser.m_oDataTable.Rows[i].ItemArray;
                var Imie = ZawartoscTabeli[1].ToString();
                var Nazwisko = ZawartoscTabeli[2].ToString();

                //jeżeli podczas parsowania wystąpi błąd(np to nie jest liczba), to przypisuje wiek jako 0
                int wiek;
                try {
                    wiek = Int32.Parse(ZawartoscTabeli[3].ToString());
                } catch(System.FormatException) {
                    wiek = 0;
                }
                var GrupaKrw = ZawartoscTabeli[4].ToString();
                var Plec = ZawartoscTabeli[5].ToString();
                var Adres = ZawartoscTabeli[6].ToString();
                int Telefon;
                try {
                    Telefon = Int32.Parse(ZawartoscTabeli[7].ToString());
                } catch(System.FormatException) {
                    Telefon = 0;
                }
                var iloscKrwii = ZawartoscTabeli[8].ToString();

                Donator donator = new Donator(Imie, Nazwisko, wiek, GrupaKrw, Plec, Adres, Telefon,iloscKrwii); // stwórz donatora przypisujac mu wszystkie parametry
                donators.Add(donator);
            }
        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("grupy_krwi.pdf", FileMode.Create));
            doc.Open(); // otworz dokument
            //Zaawartosc dokumentu
            foreach(var donator in donators) {
                doc.Add(CreateParagraphFromDonator(donator)); // Dodaj zawartosc kadzego "donatora" do pdf
            }

            doc.Close(); // zamknij dokument
        }
       
        private Paragraph CreateParagraphFromDonator(Donator donator) {
            String paragraphText = "";
            paragraphText += donator.Imie + " ";
            paragraphText += donator.Nazwisko + " ";
            paragraphText += donator.Wiek + " ";
            paragraphText += donator.GrupaKrw + " ";
            paragraphText += donator.Plec + " ";
            paragraphText += donator.Adres + " ";
            paragraphText += donator.Telefon + " ";
            paragraphText += donator.IloscOddanejKrwi + " ";

            return new Paragraph(paragraphText);
        }
    }
}
