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
        List<Transaction> currList;
        BL_Manager BL_manager;
        public Search(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            String search = searchtxt.Text;
            
            if (byCusIDradio.IsChecked == true)
            {
                
                if (MainWindow.isNumber(search))
                {
                    List<Transaction> t =BL_manager.BL_transaction.getTransactionsByCustomerID(search);
                    searchResult.ItemsSource = t;
                }

            }
            if (byIDradio.IsChecked == true)
            {
                
                if (MainWindow.isNumber(search))
                {
                    List<Transaction> t = BL_manager.BL_transaction.getTransactionsByID(search);
                    searchResult.ItemsSource = t;
                }
            }
        }

        private void showAllClick(object sender, RoutedEventArgs e)
        {
            currList = BL_manager.BL_transaction.getAllTransactionsList();
            searchResult.ItemsSource = currList;
        }

        
        

        

      

        



        
    }
}
