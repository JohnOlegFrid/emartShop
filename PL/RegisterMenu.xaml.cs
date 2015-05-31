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
    /// Interaction logic for SignInMenu.xaml
    /// </summary>
    public partial class RegisterMenu : Window
    {
        BL_Manager BL_manager;
        public RegisterMenu(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome to Emart !");
            MainWindow mw = new MainWindow(BL_manager);
            mw.Show();
           
            this.Close();
            

        }

        
        
    }
}
