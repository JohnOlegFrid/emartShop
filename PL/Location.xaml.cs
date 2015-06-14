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

namespace PL
{
    /// <summary>
    /// Interaction logic for Location.xaml
    /// </summary>
    public partial class Location : UserControl
    {
        public Location()
        {
            InitializeComponent();
        }

        private void webBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            this.webBrowser.Navigate("https://www.google.co.il/maps/@31.259262,34.7993325,15z?hl=en");
        }
    }
}
