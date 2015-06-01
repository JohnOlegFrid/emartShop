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
using Backend;

namespace PL
{
    /// <summary>
    /// Interaction logic for EmployeePrintWindow.xaml
    /// </summary>
    public partial class PrintEmployeeWindow : Window
    {
        BL_Manager BL_manager;

        public PrintEmployeeWindow(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {

            List<Employee> listP = BL_manager.BL_employee.getAllEmployees();
            var grid = sender as DataGrid;
            grid.ItemsSource = listP;
        }

        private void closeClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void maximaizeB_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void minimaizeClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {

            List<Employee> listP = new List<Employee>();
            listP = BL_manager.BL_employee.getAllEmployees();
 
            dataGrid.ItemsSource = listP;
            
        }
    }
}
