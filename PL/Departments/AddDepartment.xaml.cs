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

namespace PL.Departments
{
    /// <summary>
    /// Interaction logic for AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Page
    {
        BL_Manager BL_manager;
        public AddDepartment(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            String ID;
            String name = nametxt.Text;

            if (MainWindow.isWord(name))
            {
                if (!BL_manager.BL_department.isNameTaken(name))
                {
                    ID = BL_manager.BL_department.Add(name);
                    MessageBox.Show("The departmnet " + name + " added succefully\nDepartment ID : " + ID, "Added succefully", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("The name you chose is taken, please try other department name.", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Incorrect name, please try other department name.", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
    }
}
