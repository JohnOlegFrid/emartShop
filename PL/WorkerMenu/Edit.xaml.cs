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
    public partial class Edit : UserControl
    {
        Employee emp;
        BL_Manager BL_manager;
        public Edit(BL_Manager BL_manager,Employee emp)
        {
            this.emp = emp;
            this.BL_manager = BL_manager;
            InitializeComponent();
            firstNametxt.Text = emp.firstName;
            lastNametxt.Text = emp.lastName;
            if (emp.gender.CompareTo("Man") == 0) gendertxt.SelectedIndex = 0;
            else gendertxt.SelectedIndex = 1;
        }

        private void updateClick(object sender, RoutedEventArgs e)
        {

            String fname = firstNametxt.Text;
            String lname = lastNametxt.Text;
            String gender = (gendertxt.SelectedValue as ComboBoxItem).Content.ToString();


            Boolean goodInput = false;

            if (MainWindow.isWord(fname) && MainWindow.isWord(lname)) goodInput = true;
            if (goodInput && BL_manager.BL_employee.updateEmployee(emp.ID,fname,lname,gender,emp.departmentID,emp.salary.ToString(),emp.supervisorID,emp.type))
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
