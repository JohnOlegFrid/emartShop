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
using Backend;
using BL;
namespace PL
{
    /// <summary>
    /// Interaction logic for onlineStore.xaml
    /// </summary>
    public partial class onlineStore : Window
    {
        BL_Manager BL_manager;
        public onlineStore(BL_Manager BL_manager)
        {
            this.BL_manager=BL_manager;
            InitializeComponent();
        }

        private void loadTypes(object sender, RoutedEventArgs e)
        {
            foreach (string type in Enum.GetNames(typeof(Product.Type)))
            {
                types.Items.Add(type);
                Console.WriteLine(type);
            }
            types.Items.Add("All");
            types.SelectedItem = "All";
        }
        private void loadProductView(object sender, RoutedEventArgs e)
        {
            List<Product> selectedProducts = BL_manager.BL_product.getAllProductsList();
            Console.WriteLine(selectedProducts.First());
            foreach(Product p in selectedProducts)
            {
                Console.WriteLine(p.name);
                ProductView.Items.Add(p.name);
            }
            
        }
        private void closeClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void maximaizeB_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void minimaizeClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(types.SelectedValue);    
        }

    }
}
