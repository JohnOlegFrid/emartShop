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
            String name = nametxt.Text;
            if (MainWindow.isWord(name))
            {
                if (BL_manager.BL_department.isNameTaken(name))
                {
                    BL_manager.BL_department.RemoveByName(name);
                    MessageBox.Show("The departmnet " + name + " Removed succefully.", "Removed succefully", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Department with that name doesn't exist, please try other department name.", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Incorrect name, please try other department name.", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        
    }
}
