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
           // onlineStore f = new onlineStore(BL_manager);
            //f.Show();

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            String userName = txtUserName.Text;
            String PassWord = txtPassWord.Password;
            String pass = txtPassWord.Password;

            User tmpUser = new User(userName, PassWord);

            if (BL_manager.BL_user.exist(tmpUser)) // check if the password and username exist
            {
                Person p=BL_manager.getPersonByUserName(userName);
                String type = BL_manager.getTypeByUserName(userName);
                switch (type)
                {
                    case "Manager":
                        Employee emp = (Employee)p;
                         Window w = new GeneralMenuManager(BL_manager,emp);
                         w.Show();
                         this.Close();
                         break;
                    case "Worker":

                         break;
                    case "Customer":
                         break;
                    case "Admin":
                        Window Gm= new GeneralMenu(BL_manager);
                        Gm.Show();
                        this.Close();
                         break;

                }
                
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

        public static Boolean isWord(String word)
        {
            Boolean ans=false;
            int i=0;
            if (word != null && word.CompareTo("")!=0)
            {
                while ((((int)word[i] <= (int)'z' && (int)word[i] >= (int)'a') || ((int)word[i] >= (int)'A' && (int)word[i] <= (int)'Z')|| word[i].CompareTo(' ')==0) && i < word.Length-1)
                    i++;
            }
            
            if (i == word.Length-1) ans = true;

            return ans;
        }

        public static Boolean isNumber(String number)
        {
            Boolean ans = true;
            int dot=0;
            if (number !=null && number.CompareTo("")!=0 && number[0].CompareTo('.') != 0 && number[number.Length - 1] != '.')
                {
                    for (int i = 0; i < number.Length; i++)
                    {
                        while(number[i].CompareTo('.')==0){
                            i++;
                            dot++;
                        }

                        if ((((int)number[i] < (int)'0' || (int)number[i] > (int)'9') || dot > 1)) ans = false;
                    }

                }
            else ans = false;
          
            return ans;
        }

        private void m(object sender, DependencyPropertyChangedEventArgs e)
        {
            incorrectTextBox.Text = "";
        }

        private void p(object sender, DependencyPropertyChangedEventArgs e)
        {
            incorrectTextBox.Text = "";
        }

       

      

        

        
        
    }
}
