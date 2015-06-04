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
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        Employee emp;
        BL_Manager BL_manager;
        public EditEmployee(BL_Manager BL_manager,Employee emp)
        {
            this.emp = emp;
            this.BL_manager = BL_manager;
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
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
           
            if (goodInput && BL_manager.BL_employee.exist(IDnumber))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to change the details of this employee?","", MessageBoxButton.YesNo,MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    BL_manager.BL_employee.updateEmployee(IDnumber, fname, lname, gender, departmentID, salary, supervisorID, type);
                }
                MessageBox.Show("The employee " + fname + " " + lname + " updated succefully", "updated succefully", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("There where a problem updating the employee.\n One or more from the fields is incorrect, please try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }

    }
}
