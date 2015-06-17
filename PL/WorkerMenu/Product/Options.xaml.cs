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
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : UserControl
    {
        BL_Manager BL_manager;
        Employee emp;
        public Options(BL_Manager BL_manager,Employee emp)
        {
            this.BL_manager = BL_manager;
            this.emp = emp;
            InitializeComponent();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new WorkerMenu.Product.AddProducts(BL_manager,emp));
        }

        private void PrintClick(object sender, RoutedEventArgs e)
        {
            WorkerMenu.Product.ProductBar p = new WorkerMenu.Product.ProductBar(BL_manager);
            p.Show();
        }
       
        private void SearchClick(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new WorkerMenu.Product.Search(BL_manager));
        }
        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new WorkerMenu.Product.Remove(BL_manager,emp));
        }
    }
}
