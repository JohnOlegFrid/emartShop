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
    /// Interaction logic for GeneralMenuManager.xaml
    /// </summary>
    public partial class GeneralMenuManager : Window
    {
        BL_Manager BL_manager;
        Employee emp;

        public GeneralMenuManager(BL_Manager BL_manager,Employee emp)
        {
            this.emp = emp;
            this.BL_manager = BL_manager;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            Window Mw = new MainWindow(BL_manager);
            Mw.Show();
            this.Close();
        }

        private void employeeClick(object sender, RoutedEventArgs e)
        {
            //mainFrame.NavigationService.Navigate(new Page1());
            //mainFrame.NavigationService.Navigate(new Uri("Page1.xaml", UriKind.Relative));

            generalMenuPanel.Children.Clear();
            EmployeesManager.EmployeeOptionsWindow uc = new EmployeesManager.EmployeeOptionsWindow(BL_manager,emp);
            generalMenuPanel.Children.Add(uc);
        }

        
        private void productClick(object sender, RoutedEventArgs e)
        {
            Products.Options o = new Products.Options(BL_manager);
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(o);

        }

        private void transactionClick(object sender, RoutedEventArgs e)
        {

        }

        private void customersClick(object sender, RoutedEventArgs e)
        {

        }

        private void departmentClick(object sender, RoutedEventArgs e)
        {
            Departments.Options o = new Departments.Options(BL_manager);
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(o);

        }
        private void usersClick(object sender, RoutedEventArgs e)
        {

        }

        private void storeClick(object sender, RoutedEventArgs e)
        {
            //onlineStore s = new onlineStore(BL_manager);
            //s.Show();
        }

        private void logoutClick(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow(BL_manager);
            m.Show();
            this.Close();
        }






    }
}
