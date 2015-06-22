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

namespace PL.Products
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        BL_Manager BL_manager;
        Product p;
        public Edit(BL_Manager BL_manager,Product p)
        {
            InitializeComponent();

            this.p = p;
            this.BL_manager = BL_manager;
            nametxt.Text = p.name;
            pricetxt.Text = "" + p.price;
            stocktxt.Text = "" + p.stockCount;
            List<Department> list = BL_manager.BL_department.getAllDepartments();
            departmentIDtxt.ItemsSource = list;
            for (int i = 0; i < list.Count(); i++)
            {
                Backend.Department temp = (Department)departmentIDtxt.Items[i];
                if ((temp.ID.CompareTo(p.departmentID) == 0))
                    departmentIDtxt.SelectedIndex = i;
            }
            typetxt.ItemsSource = Enum.GetValues(typeof(Product.Type));
            Array s = Enum.GetValues(typeof(Product.Type));
            for (int i = 0; i < s.Length; i++)
                if (p.type.ToString().CompareTo(s.GetValue(i).ToString()) == 0)
                    typetxt.SelectedIndex = i;
        }

        private void updateClick(object sender, RoutedEventArgs e)
        {
            String name = nametxt.Text;
            String price = pricetxt.Text;
            String stock = stocktxt.Text;
            Department d = (departmentIDtxt.SelectedValue as Department);
            String departmentID = (departmentIDtxt.SelectedValue as Department).ID.ToString();
            String type = (typetxt.SelectedValue as Enum).ToString();

            Boolean goodInput = false;

            if (MainWindow.isWord(name) && MainWindow.isNumber(price) && MainWindow.isNumber(stock))
                goodInput = true;

            if (goodInput)
            {
                String productID = p.inventoryID;
                BL_manager.BL_product.updateProduct(productID, name, type, departmentID, price,stock);
                MessageBox.Show("The product updated successfuly.", "Updated succefully", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("There where a problem updating the product.\n One or more from the fields is incorrect, please try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }
    }
}
