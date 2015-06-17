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
    /// Interaction logic for Remove.xaml
    /// </summary>
    public partial class Remove : Page
    {
        BL_Manager BL_manager;
        Employee emp;
        public Remove(BL_Manager BL_manager,Employee emp)
        {
            this.emp = emp;
            this.BL_manager = BL_manager;
            InitializeComponent();
            String ID = emp.departmentID;
            List<Backend.Product> p = BL_manager.BL_product.getAllProductsListByDepartmentID(ID);
            producttxt.ItemsSource = p;
            producttxt.SelectedIndex = 0;
        }

        

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            String ID = (producttxt.SelectedValue as Backend.Product).inventoryID;
            if (MainWindow.isNumber(ID))
            {
                if (BL_manager.BL_product.Remove(ID))
                {
                    MessageBox.Show("The product deleted succefully", "Deleted succefully", MessageBoxButton.OK, MessageBoxImage.Information);
                   
                }
                else
                {
                    MessageBox.Show("The ID number doesn't exist.\nPlease try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            else
            {
                MessageBox.Show("The ID number is inccorect.\nPlease try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        
            List<Backend.Product> p = BL_manager.BL_product.getAllProductsListByDepartmentID(emp.departmentID);
            producttxt.ItemsSource = p;
            producttxt.SelectedIndex = 0;

        }

    }
}
