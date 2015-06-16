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
using DAL;

namespace PL.Location
{
    /// <summary>
    /// Interaction logic for Remove.xaml
    /// </summary>
    public partial class Remove : Page
    {
        BL_Manager BL_manager;
        public Remove(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
            List<StoreLocation> list = BL_manager.BL_location.getAll();
            locationsBox.ItemsSource = list;
        }

        private void removeClick(object sender, RoutedEventArgs e)
        {
            StoreLocation sl=(locationsBox.SelectedItem as StoreLocation);
            String latitude =sl.latitude;
            String longitude = sl.longitude;
            if (BL_manager.BL_location.Remove(latitude, longitude))
            {
                MessageBox.Show("The location Removed succefully.", "Removed succefully", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Location with that cordinate doesn't exist, please try other cordinate.", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            List<StoreLocation> list = BL_manager.BL_location.getAll();
            locationsBox.ItemsSource = list;
        }
    }
}
