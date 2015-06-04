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

namespace PL.Transactions
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

        private void AddClick(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Products.AddProducts(BL_manager));
        }

        private void PrintClick(object sender, RoutedEventArgs e)
        {
            TransactionsBar p = new TransactionsBar(BL_manager);
            p.Show();
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {

        }
        private void SearchClick(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Search(BL_manager));
        }
        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Products.Remove(BL_manager));
        }
    }
}
