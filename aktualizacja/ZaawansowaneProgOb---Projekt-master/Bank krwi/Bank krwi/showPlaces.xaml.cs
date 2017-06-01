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
    /// Interaction logic for showPlaces.xaml
    /// </summary>
    public partial class ShowPlaces : Window
    {
        public ShowPlaces()
        {
            InitializeComponent();
        }

        private void Btn_Gizycko_Click(object sender, RoutedEventArgs e)
        {

            TargetPlaces tarPlace = new TargetPlaces(3);
            tarPlace.Show();
        }

        private void Btn_Dzialdowo_Click(object sender, RoutedEventArgs e)
        {
            TargetPlaces tarPlace = new TargetPlaces(2);
            tarPlace.Show();
        }

        private void Btn_Olsztyn_Click(object sender, RoutedEventArgs e)
        {
            TargetPlaces tarPlace = new TargetPlaces(1);
            tarPlace.Show();
        }
    }
}
