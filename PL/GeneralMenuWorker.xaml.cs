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
    public partial class GeneralMenuWorker : Window
    {
        BL_Manager BL_manager;
        Employee emp;

        public GeneralMenuWorker(BL_Manager BL_manager,Employee emp)
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
      
        private void productClick(object sender, RoutedEventArgs e)
        {
            WorkerMenu.Product.Options o = new WorkerMenu.Product.Options(BL_manager,emp);
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(o);

        }

        private void changePassClick(object sender, RoutedEventArgs e)
        {
            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(new WorkerMenu.ChangePass(BL_manager, emp));
        }

        private void customersClick(object sender, RoutedEventArgs e)
        {

        }

        private void EditClick(object sender, RoutedEventArgs e)
        {

            generalMenuPanel.Children.Clear();
            generalMenuPanel.Children.Add(new WorkerMenu.Edit(BL_manager, emp));
        }

        private void storeClick(object sender, RoutedEventArgs e)
        {
            onlineStore s = new onlineStore(BL_manager,emp);
            s.Show();
        }

        private void logoutClick(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow(BL_manager);
            m.Show();
            this.Close();
        }






    }
}
