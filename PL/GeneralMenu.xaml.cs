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
    /// Interaction logic for GeneralMenu.xaml
    /// </summary>
    public partial class GeneralMenu : Window
    {
        BL_Manager BL_manager;
        public GeneralMenu(BL_Manager BL_manager)
        {
            this.BL_manager=BL_manager;
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
           Employees.EmployeeOptionsWindow uc = new Employees.EmployeeOptionsWindow(BL_manager);
           generalMenuPanel.Children.Add(uc);
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

        private void productClick(object sender, RoutedEventArgs e)
        {
            Products.Options o = new Products.Options(BL_manager);
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(o);

        }

        private void transactionClick(object sender, RoutedEventArgs e)
        {
            Transactions.Options o = new Transactions.Options(BL_manager);
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(o);
        }

        private void customersClick(object sender, RoutedEventArgs e)
        {
            Customers.Options o = new Customers.Options(BL_manager);
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(o);
        }

        private void departmentClick(object sender, RoutedEventArgs e)
        {
            Departments.Options o = new Departments.Options(BL_manager);
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(o);

        }
        private void usersClick(object sender, RoutedEventArgs e)
        {
            Users.Options o = new Users.Options(BL_manager);
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(o);
        }

        private void storeClick(object sender, RoutedEventArgs e)
        {
           // onlineStore s = new onlineStore(BL_manager);
            //s.Show();
        }

        private void logoutClick(object sender, RoutedEventArgs e)
        {
           MainWindow m = new MainWindow(BL_manager);
            m.Show();
            this.Close();
        }

        private void Location_Click(object sender, RoutedEventArgs e)
        {
            Location.Options l = new Location.Options(BL_manager);
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(l);
        }

        
       

        

    }
}
