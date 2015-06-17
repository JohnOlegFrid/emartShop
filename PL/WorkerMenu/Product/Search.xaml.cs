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

namespace PL.WorkerMenu.Product
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        List<Backend.Product> currList;
        BL_Manager BL_manager;
        public Search(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
            typeCombo.ItemsSource = Enum.GetValues(typeof(Backend.Product.Type));
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            String search = searchtxt.Text;
            
            if (byNameradio.IsChecked == true)
            {
                
                if (MainWindow.isWord(search))
                {
                    Backend.Product p = BL_manager.BL_product.getProductsInStockByName(search);
                    if (p != null)
                    {
                        List<Backend.Product> list = new List<Backend.Product>();
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
                    Backend.Product p = BL_manager.BL_product.getProductsInStockByID(search);
                    if (p != null)
                    {
                        List<Backend.Product> list = new List<Backend.Product>();
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
            List<Backend.Product> list = new List<Backend.Product>();
            String type = (typeCombo.SelectedItem as Enum).ToString();
            foreach (Backend.Product p in currList)
            {
                if (p.type.ToString() == type) list.Add(p);
            }
            searchResult.ItemsSource = list;
        }

        

        

      

        



        
    }
}
