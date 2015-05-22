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
using BL;

namespace PL
{
    /// <summary>
    /// Interaction logic for ProductsMenu.xaml
    /// </summary>
    public partial class ProductsMenu : Window
    {
        BL_Manager BL_manager;
        public ProductsMenu(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
        }

        private void printTest_Click(object sender, RoutedEventArgs e)
        {
            stcTest.Children.Clear();
            UserControl1 uc = new UserControl1(BL_manager);
            stcTest.Children.Add(uc);
        }

        

        

    }
}
