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
using System.Globalization;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
using BL;
using DAL;
namespace PL.Location
{
    /// <summary>
    /// Interaction logic for Location.xaml
    /// </summary>
    public partial class Map : Page
    {
        LocationConverter locConverter = new LocationConverter();
        BL_Manager BL_manager;

        public Map(BL_Manager BL_manager)
        {
            InitializeComponent();
            this.BL_manager = BL_manager;

            List<StoreLocation> sl = BL_manager.BL_location.getAll();
            locationsBox.ItemsSource = sl;
            locationsBox.SelectedIndex = 0;
            StoreLocation selected=(locationsBox.SelectedValue as StoreLocation);
            String cord = selected.latitude + "," + selected.longitude + "," + "0.000";
            //String cord = "31.264372,34.802995,0.000";
            Microsoft.Maps.MapControl.WPF.Location center = (Microsoft.Maps.MapControl.WPF.Location)(locConverter.ConvertFrom(cord));
            double zoom = 12.0;
            myMap.SetView(center, zoom);
            Pushpin pin = new Pushpin();
            pin.Location = center;
            myMap.Children.Add(pin);
            
        }

        private void locationsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myMap.Children.Clear();
            StoreLocation selected = (locationsBox.SelectedValue as StoreLocation);
            String cord = selected.latitude + "," + selected.longitude + "," + "0.000";
            //String cord = "31.264372,34.802995,0.000";
            Microsoft.Maps.MapControl.WPF.Location center = (Microsoft.Maps.MapControl.WPF.Location)(locConverter.ConvertFrom(cord));
            double zoom = 14.0;
            myMap.SetView(center, zoom);
            Pushpin pin = new Pushpin();
            pin.Location = center;
            myMap.Children.Add(pin);
        }

    }
}