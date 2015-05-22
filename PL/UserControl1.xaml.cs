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

namespace PL
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        BL_Manager BL_manager;

        public UserControl1(BL_Manager BL_manager)
        {
            this.BL_manager=BL_manager;
            InitializeComponent();

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<Product> listP=BL_manager.BL_product.getAllProductsList();
            Product p = new Product("ball", (Product.Type)Enum.Parse(typeof(Product.Type), "cosmetics"), "1234", "999", true, 67, 300.49);
            listP.Add(p);
            var grid = sender as DataGrid;
            grid.ItemsSource = BL_manager.BL_user.getAllUsers();
        }

        
       
    }
}
