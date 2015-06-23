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
using BL;
using Backend;

namespace PL.Location
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        BL_Manager BL_manager;
        public Search(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
        }

        private void showAllClick(object sender, RoutedEventArgs e)
        {
            searchResult.ItemsSource = BL_manager.BL_location.getAll();
        }

        private void searchClick(object sender, RoutedEventArgs e)
        {
            List<StoreLocation> list = new List<StoreLocation>();
            
            if (byCityradio.IsChecked == true)
            {
                String city = searchtxt.Text;
                if (MainWindow.isWord(city))
                {
                    list = BL_manager.BL_location.getByCityName(city);
                    searchResult.ItemsSource = list;

                }
            }
            else if (byCountryradio.IsChecked == true)
            {
                String country = searchtxt.Text;
                if (MainWindow.isWord(country))
                {
                    list = BL_manager.BL_location.getByCountryName(country);
                    searchResult.ItemsSource = list;

                }
            }
        }

        private void showOnMapClick(object sender, RoutedEventArgs e)
        {
            StoreLocation s= (searchResult.SelectedItem as StoreLocation);
            if (s!=null)
            {
                Location.ShowMap sm=new Location.ShowMap(s);
                sm.Show();
            }
                
        }


    }
}
