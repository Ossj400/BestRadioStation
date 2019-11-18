using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BestRadioStation
{
    /// <summary>
    /// Interaction logic for WindowFavoritueRadiosList.xaml
    /// </summary>
    public partial class WindowFavoritueRadiosList : Window
    {
        private FavoritueRadioListManager manager;
        public WindowFavoritueRadiosList()
        {
            InitializeComponent();
            InitBinding();
        }
        string[] fullArray;
        string[] names;
        string[] urls;
        static int count;
        public int selectionFavListId;


        private void listBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            // ??? InitBinding();
        }
        private void InitBinding()
        {
            manager = new FavoritueRadioListManager();
            array(); 
            listBox.ItemsSource = names;
        }

        private void array()
        {
            fullArray = manager.readFromList();
            count = fullArray.Length;
            names = new string[count];
            urls = new string[count];
            int i = 0;
            foreach (string line in fullArray)
            {
                if (((i + 1) % 2) != 0)
                {
                    names[i] = line;
                }

                if (((i + 1) % 2) == 0)
                {
                    urls[i] = line;
                }
             
             i = i + 1;
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectionFavListId = listBox.SelectedIndex;
        }

        public string giveUrlFavList(int selectionFav)
        {
            return urls[selectionFav+1];
        }
    }
}
