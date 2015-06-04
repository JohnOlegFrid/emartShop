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

namespace PL.Users
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        BL_Manager BL_manager;
        public Edit(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
        }

        private void updateClick(object sender, RoutedEventArgs e)
        {
            String name = userNametxt.Text;
            String currPass = currentPassxordtxt.Password;
            String newPass = newPassxordtxt.Password;

            if(BL_manager.BL_user.Update(name,currPass,newPass))
            {
                MessageBox.Show("The User " + name +" updated succefully.\nNew Pass : "+newPass, "updated succefully", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("There where a problem updating the User.\n One or more from the fields is incorrect, please try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }
    }
}
