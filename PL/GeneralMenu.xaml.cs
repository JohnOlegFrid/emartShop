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
       

        

    }
}
