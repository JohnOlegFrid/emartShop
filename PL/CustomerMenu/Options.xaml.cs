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

namespace PL.CustomerMenu
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : UserControl
    {
        BL_Manager BL_manager;
        public Options(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
        }



        private void PrintClick(object sender, RoutedEventArgs e)
        {
            Products.ProductBar p = new Products.ProductBar(BL_manager);
            p.Show();
        }
            
      
        private void SearchClick(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Products.Search(BL_manager));
        }
       
    }
}
