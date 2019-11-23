using System;
using System.Collections.Generic;
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
    /// Interaction logic for SongsList.xaml
    /// </summary>
    public partial class SongsList : Window
    {
        private FavoritueRadioListManager manager;
        public int selectionSongListId;
        public SongsList()
        {
            InitializeComponent();
            initBinding();
        }
        private void initBinding()
        {
            manager = new FavoritueRadioListManager();
            listBoxSong.ItemsSource = manager.readFromListSongs();
        }
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectionSongListId = listBoxSong.SelectedIndex;
        }
    }
}
