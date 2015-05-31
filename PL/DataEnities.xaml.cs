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

namespace PL
{
    /// <summary>
    /// Interaction logic for DataEnities.xaml
    /// </summary>
    public partial class DataEnities : Window
    {
        BL_Manager BL_manager;
        public DataEnities(BL_Manager BL_manager)
        {
            this.BL_manager=BL_manager;
            InitializeComponent();
        }

        private void productsClick(object sender, RoutedEventArgs e)
        {
            ProductsMenu pm = new ProductsMenu(BL_manager);
            pm.Show();
            this.Close();
        }


        

        
    }
}
