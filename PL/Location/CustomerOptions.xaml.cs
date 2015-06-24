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
    /// Interaction logic for CustomerOptions.xaml
    /// </summary>
    public partial class CustomerOptions : UserControl
    {
        BL_Manager BL_manager;
        public CustomerOptions(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
        }

        private void printClick(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Location.Map(BL_manager));
        }

        private void searchClick(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Location.Search(BL_manager));
        }
    }
}
