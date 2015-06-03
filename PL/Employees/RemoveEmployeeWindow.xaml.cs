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
    /// Interaction logic for RemoveEmployeeWindow.xaml
    /// </summary>
    public partial class RemoveEmployeeWindow : Window
    {
        BL_Manager BL_manager;

        public RemoveEmployeeWindow(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            String IDnumber=IDnumbertxt.Text;
            if (MainWindow.isNumber(IDnumber))
            {
                if (BL_manager.BL_employee.Remove(IDnumber))
                {
                    MessageBox.Show("The employee deleted succefully", "Deleted succefully", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The ID number doesn't exist.\nPlease try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            else
            {
                MessageBox.Show("There where a problem deleting the employee.\nPlease try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
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
