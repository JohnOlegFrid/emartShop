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

namespace PL.Customers
{
    /// <summary>
    /// Interaction logic for Remove.xaml
    /// </summary>
    public partial class Remove : Page
    {
        BL_Manager BL_manager;
        public Remove(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
        }

        private void removeClick(object sender, RoutedEventArgs e)
        {
            String ID = IDtxt.Text;
            if (MainWindow.isNumber(ID))
            {
                if (BL_manager.BL_clubMember.getClubMemberByID(ID)!=null)
                {
                    BL_manager.BL_clubMember.Remove(ID);
                    MessageBox.Show("The customer with the ID : " + ID + " Removed succefully.", "Removed succefully", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Customer with that ID doesn't exist, please try again.", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Incorrect input, please try again.", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        
    }
}
