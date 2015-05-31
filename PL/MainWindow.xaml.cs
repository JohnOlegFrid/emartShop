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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using Backend;
using PL;
using System.Threading;


namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL_Manager BL_manager;
        public MainWindow(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            String userName = txtUserName.Text;
            String PassWord = txtPassWord.Password;
            String pass = txtPassWord.Password;

            User tmpUser = new User(userName, PassWord);

            if (BL_manager.BL_user.exist(tmpUser)) // check if the password and username exist
            {
               
                Window Gm = new GeneralMenu(BL_manager);
                Gm.Show();
                this.Close();
            }
            else
            {
                //MessageBox.Show("Wrong password or Username.");
                incorrectTextBox.Text = "Wrong password or username,try again.";
                txtUserName.Clear();
                txtPassWord.Clear();
            }

        }
        private void newUser(object sender, RoutedEventArgs e)
        {
           
            Window register = new RegisterMenu(BL_manager);
            register.Show();
            this.Close();
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
