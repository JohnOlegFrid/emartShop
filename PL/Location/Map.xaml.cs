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

            txt.Text = "";
            temptxt.Text = "";
            sign.Text = "";

            List<StoreLocation> sl = BL_manager.BL_location.getAll();
            locationsBox.ItemsSource = sl;
            
            
        }

        private void locationsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // myMap.Children.Clear();
            StoreLocation selected = (locationsBox.SelectedValue as StoreLocation);
            String cord = selected.latitude + "," + selected.longitude + "," + "0.000";
            browser.NavigateToString("<html><body><script type='text/javascript' src='http://maps.google.com/maps/api/js?sensor=false'></script><div style='overflow:hidden;height:500px;width:600px;'><div id='gmap_canvas' style='height:500px;width:600px;'></div><style>#gmap_canvas img{max-width:none!important;background:none!important}</style><a class='google-map-code' href='http://wptiger.com' id='get-map-data'>premium wordpress themes</a></div><script type='text/javascript'> function init_map(){var myOptions = {zoom:17,center:new google.maps.LatLng("+selected.latitude+","+selected.longitude+"),mapTypeId: google.maps.MapTypeId.ROADMAP};map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions);marker = new google.maps.Marker({map: map,position: new google.maps.LatLng("+selected.latitude+", "+selected.longitude+")});}google.maps.event.addDomListener(window, 'load', init_map);</script></body></html>");

            //String cord = "31.264372,34.802995,0.000";
            //Microsoft.Maps.MapControl.WPF.Location center = (Microsoft.Maps.MapControl.WPF.Location)(locConverter.ConvertFrom(cord));
            //double zoom = 14.0;
            //myMap.SetView(center, zoom);
            //Pushpin pin = new Pushpin();
            //pin.Location = center;
            //myMap.Children.Add(pin);
            txt.Text = "Current temperature\nnear the store";
            sign.Text = "0";
            String temp= Weather.get(selected.city).Substring(0, 2) + " Celsius";
            if (temp != null) temptxt.Text = temp;
            else
                MessageBox.Show("There where an Internet Error.Could not get the weather information.", "Connection problem", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}