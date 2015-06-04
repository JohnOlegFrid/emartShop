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

namespace PL.EmployeesManager
{
    /// <summary>
    /// Interaction logic for SearchEmployee.xaml
    /// </summary>
    public partial class SearchEmployee : Window
    {
        BL_Manager BL_manager;

        public SearchEmployee(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
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

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> list = new List<Employee>();
            if (byIDradio.IsChecked==true)
            {
                String id = searchtxt.Text;
                if (MainWindow.isNumber(id))
                {
                    list = BL_manager.BL_employee.getEmployeeByID(id);
                    searchResult.ItemsSource = list;
                    
                }  
            }
            else if (byNameradio.IsChecked == true)
            {
                String name = searchtxt.Text;
                if (MainWindow.isWord(name))
                {
                    list = BL_manager.BL_employee.getEmployeesByFirstName(name);
                    searchResult.ItemsSource = list;

                }
            }
            else if (byLastNameradio.IsChecked == true)
            {
                String lastName = searchtxt.Text;
                if (MainWindow.isWord(lastName))
                {
                    list = BL_manager.BL_employee.getEmployeesByLastName(lastName);
                    searchResult.ItemsSource = list;

                }
            }
        }

        

       
    }
}
