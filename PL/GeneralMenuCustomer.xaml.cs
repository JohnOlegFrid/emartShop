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
    /// Interaction logic for GeneralMenuCustomer.xaml
    /// </summary>
    public partial class GeneralMenuCustomer : Window
    {
        Club_Member cm;
         BL_Manager BL_manager;
        public GeneralMenuCustomer(BL_Manager BL_manager,Club_Member cm)
        {
            this.cm = cm;
            this.BL_manager=BL_manager;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
            CustomerMenu.Options o = new CustomerMenu.Options(BL_manager);
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(o);

        }

        private void transactionClick(object sender, RoutedEventArgs e)
        {

        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
           
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(new CustomerMenu.Edit(BL_manager,cm));
        }


        private void changePassClick(object sender, RoutedEventArgs e)
        {
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(new CustomerMenu.ChangePass(BL_manager,cm));
        }

        private void storeClick(object sender, RoutedEventArgs e)
        {
            onlineStore s = new onlineStore(BL_manager,cm);
            s.Show();
        }

        private void logoutClick(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow(BL_manager);
            m.Show();
            this.Close();
        }

        private void locationClick(object sender, RoutedEventArgs e)
        {
            Location.CustomerOptions co = new Location.CustomerOptions(BL_manager);
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(co);
        }

    }
}
