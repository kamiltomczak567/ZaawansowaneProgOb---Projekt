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
    public partial class showGroup : Window
    {
        public showGroup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string a = "0Rh-";
            showUser showUser = new showUser(a);
            showUser.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string a = "0Rh+";
            showUser showUser = new showUser(a);
            showUser.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string a = "BRh−";
            showUser showUser = new showUser(a);
            showUser.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string a = "BRh+";
            showUser showUser = new showUser(a);
            showUser.Show();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string a = "ARh−";
            showUser showUser = new showUser(a);
            showUser.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string a = "ARh+";
            showUser showUser = new showUser(a);
            showUser.Show();

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string a = "ABRh−";
            showUser showUser = new showUser(a);
            showUser.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            string a = "ABRh+";
            showUser showUser = new showUser(a);
            showUser.Show();
        }

        private void B_pdf_Click(object sender, RoutedEventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Test.pdf", FileMode.Create));
            doc.Open(); // otworz dokument
            //Zaawartosc dokumentu
            Paragraph paragraph = new Paragraph("Proba pdfa");
            doc.Add(paragraph);

            doc.Close();

        }
        //0Rh− 	0Rh+ 	BRh− 	BRh+ 	ARh− 	ARh+ 	ABRh− 	ABRh+
    }
}
