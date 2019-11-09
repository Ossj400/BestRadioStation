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
using System.Net.Http;
using HtmlAgilityPack;

namespace BestRadioStation
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

        
        private string bindList(string url)
        {
            Scrapper Scrap = new Scrapper();
            Scrap.GetHtmlNotAsync(url);
            ListRadioStat.ItemsSource = Scrap.GetRadioName();
            return null;
        }
        private void BtAmbient_Click(object sender, RoutedEventArgs e)
        {
            var url_Ambient = "https://www.internet-radio.com/stations/ambient/";
            bindList(url_Ambient);
        }


        

        private void BtPsytrance_Click(object sender, RoutedEventArgs e)
        {
            var url_Psytrance = "https://www.internet-radio.com/stations/psytrance/";
            bindList(url_Psytrance);
        }
    }
}
