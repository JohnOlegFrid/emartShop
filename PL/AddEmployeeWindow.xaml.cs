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

namespace PL
{
    /// <summary>
    /// Interaction logic for AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        BL_Manager BL_manager;
        public AddEmployeeWindow(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
            
            SimpleProgressBar sb = new SimpleProgressBar();
            //sb.Show();
           // sb.run();

            if (BL_manager.BL_employee.Add(IDnumber, fname, lname, gender, departmentID, salary, supervisorID))
            {
                MessageBox.Show("The employee "+fname+" "+lname+" added succefully", "Added succefully", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("There where a problem adding the employee to the dataBase.\n One or more from the fields is incorrect, please try again", "Problem",MessageBoxButton.OK, MessageBoxImage.Warning);
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
