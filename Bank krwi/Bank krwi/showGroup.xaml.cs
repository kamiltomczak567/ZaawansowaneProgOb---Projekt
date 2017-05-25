using System;
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
        //0Rh− 	0Rh+ 	BRh− 	BRh+ 	ARh− 	ARh+ 	ABRh− 	ABRh+
    }
}
