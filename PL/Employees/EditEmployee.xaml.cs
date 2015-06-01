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

namespace PL.Employees
{
    /// <summary>
    /// Interaction logic for EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        BL_Manager BL_manager;
        public EditEmployee(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            String fname = firstNametxt.Text;
            String lname = lastNametxt.Text;
            String IDnumber = IDnumbertxt.Text;
            String salary = salarytxt.Text;
            String supervisorID = supervisorIDtxt.Text;
            String departmentID = departmentIDtxt.Text;
            String gender = (gendertxt.SelectedValue as ComboBoxItem).Content.ToString();
            Boolean goodInput = false;
          
            if (MainWindow.isWord(fname) && MainWindow.isWord(lname) && MainWindow.isNumber(IDnumber) && MainWindow.isNumber(salary) && MainWindow.isNumber(supervisorID) && MainWindow.isNumber(departmentID))
                goodInput = true;
           
            if (goodInput && BL_manager.BL_employee.exist(IDnumber))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to change the details of this employee?","", MessageBoxButton.YesNo,MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    BL_manager.BL_employee.updateEmployee(IDnumber, fname, lname, gender, departmentID, salary, supervisorID);
                }
                MessageBox.Show("The employee " + fname + " " + lname + " updated succefully", "updated succefully", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("There where a problem updating the employee.\n One or more from the fields is incorrect, please try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


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
