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

namespace PL.EmployeesManager
{
    /// <summary>
    /// Interaction logic for AddEmployeeControl.xaml
    /// </summary>
    [Serializable]
    public partial class AddEmployeeControl : UserControl
    {
        Employee emp;
        BL_Manager BL_manager;

        public AddEmployeeControl(BL_Manager BL_manager,Employee emp)
        {
            this.emp = emp;
            this.BL_manager = BL_manager;
            InitializeComponent();
            
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            String fname = firstNametxt.Text;
            String lname = lastNametxt.Text;
            String IDnumber = IDnumbertxt.Text;
            String salary = salarytxt.Text;
            String supervisorID = emp.ID;
            String departmentID = emp.departmentID;
            String gender = (gendertxt.SelectedValue as ComboBoxItem).Content.ToString();
            String type = "Worker";
            
            Boolean goodInput = false;
            
            if (MainWindow.isWord(fname) && MainWindow.isWord(lname) && MainWindow.isNumber(IDnumber) && MainWindow.isNumber(salary) && MainWindow.isNumber(supervisorID) && MainWindow.isNumber(departmentID))
                goodInput = true;
            if (goodInput && BL_manager.BL_employee.Add(IDnumber, fname, lname, gender, departmentID, salary, supervisorID,type))
            {
                MessageBox.Show("The employee " + fname + " " + lname + " added succefully", "Added succefully", MessageBoxButton.OK, MessageBoxImage.Information);
                User addedNow = new User(IDnumber, "0", IDnumber);
                BL_manager.BL_user.Add(addedNow);
                MessageBox.Show("User name : " + IDnumber + "\nPassword: '0', ", "User name and Password", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("There where a problem adding the employee to the dataBase.\n One or more from the fields is incorrect, please try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }





    }
}
