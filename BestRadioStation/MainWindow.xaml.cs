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

        Scrapper Scrap = new Scrapper();
        private string bindList(string url)
        {

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
            var url = "https://www.internet-radio.com/stations/psytrance/";
            bindList(url);
        }

        private void BtDeep_House_Click(object sender, RoutedEventArgs e)
        {
            var url = "https://www.internet-radio.com/stations/deep%20house/";
            bindList(url);
        }

        private void BtClassic_Rock_Click(object sender, RoutedEventArgs e)
        {
            var url = "https://www.internet-radio.com/stations/classic%20rock/";
            bindList(url);
        }

        private void BtInstrumental_Click(object sender, RoutedEventArgs e)
        {
            var url = "https://www.internet-radio.com/stations/instrumental/";
            bindList(url);
        }

        private void BtDance_Click(object sender, RoutedEventArgs e)
        {
            var url = "https://www.internet-radio.com/stations/dance/";
            bindList(url);
        }

        private void BtChristmas_Click(object sender, RoutedEventArgs e)
        {
            var url = "https://www.internet-radio.com/stations/christmas/";
            bindList(url);
        }

        private void BtClassical_Click(object sender, RoutedEventArgs e)
        {
            var url = "https://www.internet-radio.com/stations/classical/";
            bindList(url);
        }

        private void BtHipHop_Click(object sender, RoutedEventArgs e)
        {
            var url = "https://www.internet-radio.com/stations/hip%20hop/";
            bindList(url);
        }

        private void BtKpop_Click(object sender, RoutedEventArgs e)
        {
            var url = "https://www.internet-radio.com/stations/soundtracks/";
            bindList(url);
        }

        private void ListRadioStat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            int element = (ListRadioStat.SelectedIndex);
            string xd = Scrap.WhichElement(element).ToString();   /// crash po wejsciu w inny rodzaj muzyki 
            MessageBox.Show(xd);
        }
    }
}
