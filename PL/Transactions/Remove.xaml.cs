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

namespace PL.Products
{
    /// <summary>
    /// Interaction logic for Remove.xaml
    /// </summary>
    public partial class Remove : Page
    {
        BL_Manager BL_manager;
        public Remove(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
            List<Department> list = BL_manager.BL_department.getAllDepartments();
            departmentIDtxt.ItemsSource = list;
        }

        

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            String ID = (producttxt.SelectedValue as Product).inventoryID;
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
            String IDd = (departmentIDtxt.SelectedValue as Department).ID.ToString();
            List<Product> p = BL_manager.BL_product.getAllProductsListByDepartmentID(IDd);
            producttxt.ItemsSource = p;
            producttxt.SelectedIndex = 0;

        }


        private void DepartmentClick(object sender, SelectionChangedEventArgs e)
        {
            String ID = (departmentIDtxt.SelectedValue as Department).ID.ToString();
            List<Product> p = BL_manager.BL_product.getAllProductsListByDepartmentID(ID);
            producttxt.ItemsSource = p;
            producttxt.SelectedIndex = 0;
        }
    }
}
