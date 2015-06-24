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

namespace PL.CustomerMenu
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : UserControl
    {
        Club_Member cm;
        BL_Manager BL_manager;
        public Edit(BL_Manager BL_manager,Club_Member cm)
        {
            this.cm = cm;
            this.BL_manager = BL_manager;
            InitializeComponent();
            firstNametxt.Text = cm.firstName;
            lastNametxt.Text = cm.lastName;
            dateOdBirthtxt.Text = cm.dateOfBirth;
            if (cm.gender.CompareTo("Man") == 0) gendertxt.SelectedIndex = 0;
            else gendertxt.SelectedIndex = 1;
        }

        private void updateClick(object sender, RoutedEventArgs e)
        {

            String fname = firstNametxt.Text;
            String lname = lastNametxt.Text;
            String IDnumber = cm.ID;
            String gender = (gendertxt.SelectedValue as ComboBoxItem).Content.ToString();
            String dateOfBirth = dateOdBirthtxt.Text;

            Boolean goodInput = false;
            Club_Member customer = new Club_Member(IDnumber, fname, lname, gender, IDnumber, dateOfBirth);

            if (MainWindow.isWord(fname) && MainWindow.isWord(lname) && MainWindow.isNumber(IDnumber))

                goodInput = true;
            if (goodInput && BL_manager.BL_clubMember.updateClubMember(IDnumber,fname,lname,gender,dateOfBirth))
            {
                MessageBox.Show("your profile updated succefully", "updated succefully", MessageBoxButton.OK, MessageBoxImage.Information);
    
            }
            else
            {
                MessageBox.Show("There where a problem updating your profile.\n One or more from the fields is incorrect, please try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
