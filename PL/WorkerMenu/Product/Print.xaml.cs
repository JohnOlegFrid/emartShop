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

namespace PL.WorkerMenu.Product
{
    /// <summary>
    /// Interaction logic for Print.xaml
    /// </summary>
    public partial class Print : Window
    {
        BL_Manager BL_manager;
        public Print(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
            List<Backend.Product> list = BL_manager.BL_product.getAllProductsList();
            Table table = new Table(list);
            panel.Children.Add(table);
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            panel.Children.Clear();
            List<Backend.Product> list = BL_manager.BL_product.getAllProductsList();
            Table table = new Table(list);
            panel.Children.Add(table);
        }
    }
    
}
