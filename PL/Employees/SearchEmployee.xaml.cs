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
    /// Interaction logic for SearchEmployee.xaml
    /// </summary>
    public partial class SearchEmployee : Window
    {
        BL_Manager Bl_manager;

        public SearchEmployee(BL_Manager BL_manager)
        {
            this.Bl_manager = BL_manager;
            InitializeComponent();
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

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (byIDradio.IsChecked==true)
            {
                this.Close();
            }

        }
    }
}
