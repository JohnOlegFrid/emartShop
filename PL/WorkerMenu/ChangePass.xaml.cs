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
using Backend;
using BL;

namespace PL.WorkerMenu
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class ChangePass : UserControl
    {
        Employee emp;
        BL_Manager BL_manager;

        public ChangePass(BL_Manager BL_manager,Employee emp)
        {
            this.emp = emp;
            this.BL_manager = BL_manager;
            InitializeComponent();
        }

        private void updateClick(object sender, RoutedEventArgs e)
        {
            
            String currPass = currentPassxordtxt.Password;
            String newPass = newPassxordtxt.Password;
            String userName= BL_manager.BL_user.getUserByID(emp.ID);
            if(BL_manager.BL_user.Update(userName,currPass,newPass))
            {
                MessageBox.Show("Your password updated succefully.\nNew Pass : "+newPass, "updated succefully", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("There where a problem updating the password.\n One or more from the fields is incorrect, please try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }
    }
}
