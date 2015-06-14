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

namespace PL.Transactions
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        List<Product> currList;
        BL_Manager BL_manager;
        public Search(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
            typeCombo.ItemsSource = Enum.GetValues(typeof(Product.Type));
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            String search = searchtxt.Text;
            
            if (byNameradio.IsChecked == true)
            {
                
                if (MainWindow.isWord(search))
                {
                    Product p = BL_manager.BL_product.getProductsInStockByName(search);
                    if (p != null)
                    {
                        List<Product> list = new List<Product>();
                        list.Add(p);
                        searchResult.ItemsSource = list;
                        currList = list;
                    }
                    else
                    {
                        searchResult.ItemsSource = null;
                    }
                }
            }
            if (byIDradio.IsChecked == true)
            {
                
                if (MainWindow.isNumber(search))
                {
                    Product p = BL_manager.BL_product.getProductsInStockByID(search);
                    if (p != null)
                    {
                        List<Product> list = new List<Product>();
                        list.Add(p);
                        searchResult.ItemsSource = list;
                        currList = list;
                    }
                    else
                    {
                        searchResult.ItemsSource = null;
                    }
                }
            }
        }

        private void showAllClick(object sender, RoutedEventArgs e)
        {
            currList = BL_manager.BL_product.getAllProductsList();
            searchResult.ItemsSource = currList;
        }

        private void typeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Product> list = new List<Product>();
            String type = (typeCombo.SelectedItem as Enum).ToString();
            foreach (Product p in currList)
            {
                if (p.type.ToString() == type) list.Add(p);
            }
            searchResult.ItemsSource = list;
        }

        

        

      

        



        
    }
}
