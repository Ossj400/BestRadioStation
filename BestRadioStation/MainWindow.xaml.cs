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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using HtmlAgilityPack;
using System.Media;


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

        private void Sound()
        {
            new SoundPlayer(@"C:\Users\Artur\source\repos\BestRadioStation\button11.wav").Play();
        }
        private string bindList(string url)
        {

            Scrap.GetHtmlNotAsync(url);
            ListRadioStat.ItemsSource = Scrap.GetRadioName();
            return null;
        }
        private void BtAmbient_Click(object sender, RoutedEventArgs e)
        {
            Sound();
            var url_Ambient = "https://www.internet-radio.com/stations/ambient/?sortby=listeners";
            bindList(url_Ambient);
        }


        private void BtPsytrance_Click(object sender, RoutedEventArgs e)
        {
            Sound();
            var url = "https://www.internet-radio.com/stations/psytrance/?sortby=listeners";
            bindList(url);

        }

        private void BtDeep_House_Click(object sender, RoutedEventArgs e)
        {
            Sound();
            var url = "https://www.internet-radio.com/stations/deep%20house/?sortby=listeners";
            bindList(url);
        }

        private void BtClassic_Rock_Click(object sender, RoutedEventArgs e)
        {
            Sound();
            var url = "https://www.internet-radio.com/stations/classic%20rock/?sortby=listeners";
            bindList(url);
        }

        private void BtInstrumental_Click(object sender, RoutedEventArgs e)
        {
            Sound();
            var url = "https://www.internet-radio.com/stations/instrumental/?sortby=listeners";
            bindList(url);
        }

        private void BtDance_Click(object sender, RoutedEventArgs e)
        {
            Sound();
            var url = "https://www.internet-radio.com/stations/dance/?sortby=listeners";
            bindList(url);
        }

        private void BtChristmas_Click(object sender, RoutedEventArgs e)
        {
            Sound();
            var url = "https://www.internet-radio.com/stations/christmas/?sortby=listeners";
            bindList(url);
        }

        private void BtClassical_Click(object sender, RoutedEventArgs e)
        {
            Sound();
            var url = "https://www.internet-radio.com/stations/classical/?sortby=listeners";
            bindList(url);
        }

        private void BtHipHop_Click(object sender, RoutedEventArgs e)
        {
            Sound();
            var url = "https://www.internet-radio.com/stations/hip%20hop/?sortby=listeners";
            bindList(url);
        }

        private void BtKpop_Click(object sender, RoutedEventArgs e)
        {
            Sound();
            var url = "https://www.internet-radio.com/stations/soundtracks/?sortby=listeners";
            bindList(url);

        }

        private void ListRadioStat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int element = (ListRadioStat.SelectedIndex);
            if (element >= 0)
            {
                string uri = Scrap.WhichElement(element).ToString();
                MessageBox.Show("Let's listen to this server: "+uri);
                mediaElement.Source = new Uri(uri);
                mediaElement.Play();
             
            }
           
        }

        private void BtStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
        }

        private void BtStart_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement.Volume = slider.Value;
            VolumeLbl.Content = Convert.ToInt32(slider.Value*100).ToString() + " %";
        }
        
    }
}
