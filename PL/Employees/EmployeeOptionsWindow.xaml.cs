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
namespace PL.Employees
{
    /// <summary>
    /// Interaction logic for EmployeeOptionsWindow.xaml
    /// </summary>
    public partial class EmployeeOptionsWindow : UserControl
    {
        BL_Manager BL_manager;
        public EmployeeOptionsWindow(BL_Manager BL_manager)
        {
            this.BL_manager=BL_manager;
            InitializeComponent();
        }

        private void addEmployeeClick(object sender, RoutedEventArgs e)
        {
            employeePanel.Children.Clear();
            AddEmployeeControl a = new AddEmployeeControl(BL_manager);
            employeePanel.Children.Add(a);
            //AddEmployeeWindow a = new AddEmployeeWindow(BL_manager);
            //a.Show();
        }

        private void printEmployeeClick(object sender, RoutedEventArgs e)
        {
            EmployeeProgress p = new EmployeeProgress(BL_manager);
            p.Show();

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            RemoveEmployeeWindow r = new RemoveEmployeeWindow(BL_manager);
            r.Show();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditEmployee edit = new EditEmployee(BL_manager);
            edit.Show();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchEmployee s = new SearchEmployee(BL_manager);
            s.Show();
        }
    }
}
