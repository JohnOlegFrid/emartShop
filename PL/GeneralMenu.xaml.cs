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
    /// Interaction logic for GeneralMenu.xaml
    /// </summary>
    public partial class GeneralMenu : Window
    {
        BL_Manager BL_manager;
        public GeneralMenu(BL_Manager BL_manager)
        {
            this.BL_manager=BL_manager;
            InitializeComponent();
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            Window Mw = new MainWindow(BL_manager);
            Mw.Show();
            this.Close();
        }
    }
}
