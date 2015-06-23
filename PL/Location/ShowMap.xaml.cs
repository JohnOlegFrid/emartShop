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
using System.Windows.Shapes;
using BL;
using Backend;

namespace PL.Location
{
    /// <summary>
    /// Interaction logic for ShowMap.xaml
    /// </summary>
    public partial class ShowMap : Window
    {
        public ShowMap(StoreLocation selected)
        {
            InitializeComponent();
            String cord = selected.latitude + "," + selected.longitude + "," + "0.000";
            browser.NavigateToString("<html><body><script type='text/javascript' src='http://maps.google.com/maps/api/js?sensor=false'></script><div style='overflow:hidden;height:500px;width:600px;'><div id='gmap_canvas' style='height:500px;width:600px;'></div><style>#gmap_canvas img{max-width:none!important;background:none!important}</style><a class='google-map-code' href='http://wptiger.com' id='get-map-data'>premium wordpress themes</a></div><script type='text/javascript'> function init_map(){var myOptions = {zoom:17,center:new google.maps.LatLng(" + selected.latitude + "," + selected.longitude + "),mapTypeId: google.maps.MapTypeId.ROADMAP};map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions);marker = new google.maps.Marker({map: map,position: new google.maps.LatLng(" + selected.latitude + ", " + selected.longitude + ")});}google.maps.event.addDomListener(window, 'load', init_map);</script></body></html>");
            String temp = Weather.get(selected.city).Substring(0, 2) + " Celsius";
            if (temp != null) temptxt.Text = temp;
            else
                MessageBox.Show("There where an Internet Error.Could not get the weather information.", "Connection problem", MessageBoxButton.OK, MessageBoxImage.Information);
   
        }
    }
}
