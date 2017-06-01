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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.CSharp;
using System.Data;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace Bank_krwi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_NewDonator(object sender, RoutedEventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();        
        }

        private void Btn_ShowPlaces(object sender, RoutedEventArgs e)
        {
            ShowPlaces showPlaces = new ShowPlaces();
            showPlaces.Show();
        }

        private void Btn_ShowBloodGroup(object sender, RoutedEventArgs e)
        {
            ShowGroup showGroup = new ShowGroup();
            showGroup.Show();
        }

        private void Btn_Facebook(object sender, RoutedEventArgs e)
        {
            string token = GetToken();
            var Request = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.9/wetbankkrwi/feed?access_token=" + token);
            var Response = (HttpWebResponse)Request.GetResponse();
            FacebookPost fbPost = GetFacebookPost(Response);
            facebookPosts facebookPost = new facebookPosts(fbPost);
            facebookPost.Show();
        }

        private string GetToken()
        {
            var TokenRequest = (HttpWebRequest)WebRequest.Create("https://graph.facebook.com/v2.9/oauth/access_token?client_id=1066391300160675&client_secret=529c6b46acc37b676b6bc438c7691291&grant_type=client_credentials");
            var TokenResponse = (HttpWebResponse)TokenRequest.GetResponse();
            var ResponseTokenString = new StreamReader(TokenResponse.GetResponseStream()).ReadToEnd();
            dynamic y = JsonConvert.DeserializeObject(ResponseTokenString);
            return y.access_token;
        }

        private FacebookPost GetFacebookPost(HttpWebResponse response)
        {
            var ResponseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            dynamic x = JsonConvert.DeserializeObject(ResponseString);
            var Data = x.data;
            string Message = Data[0].message;
            string Created_time = Data[0].created_time;
            string id = Data[0].id;
            FacebookPost fbPost = new FacebookPost(Created_time, Message, id);
            return fbPost;
        }

    }
}
