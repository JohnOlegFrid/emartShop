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
    /// Interaction logic for AddProducts.xaml
    /// </summary>
    public partial class AddProducts : Page
    {
        BL_Manager BL_manager;
        Employee emp;
        public AddProducts(BL_Manager BL_manager,Employee emp)
        {
            this.emp = emp;
            this.BL_manager = BL_manager;
            InitializeComponent();

            typetxt.ItemsSource = Enum.GetValues(typeof(Backend.Product.Type));
            List<Department> list = BL_manager.BL_department.getAllDepartments();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            String name = nametxt.Text;
            String price = pricetxt.Text;
            String stock = stocktxt.Text;
            String type = (typetxt.SelectedValue as Enum).ToString();

            Boolean goodInput = false;

            if (MainWindow.isWord(name)&& MainWindow.isNumber(price) && MainWindow.isNumber(stock))
                goodInput = true;
           
            if (goodInput)
            {
                String productID = BL_manager.BL_product.Add(name, type, emp.departmentID, stock, price);
                MessageBox.Show("The product added successful.\nProduct ID num : "+productID, "Added succefully", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("There where a problem adding the product.\n One or more from the fields is incorrect, please try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

       
    }
}
