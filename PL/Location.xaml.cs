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


namespace PL
{
    /// <summary>
    /// Interaction logic for Location.xaml
    /// </summary>
    public partial class Location : UserControl
    {
        LocationConverter locConverter = new LocationConverter();
        public Location()
        {
            InitializeComponent();
            String cord = "31.264372,34.802995,0.000";
            Microsoft.Maps.MapControl.WPF.Location center = (Microsoft.Maps.MapControl.WPF.Location)(locConverter.ConvertFrom(cord));
            double zoom = 17.0;
            myMap.SetView(center, zoom);
            Pushpin pin = new Pushpin();
            pin.Location = center;
            myMap.Children.Add(pin);
        }

        

       

       
    }
}