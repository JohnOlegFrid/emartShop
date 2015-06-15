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
using Backend;
using DAL;

namespace PL.Location
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Page
    {

        BL_Manager BL_manager;
        public Add(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
          
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            String country=countrytxt.Text;
            String city=citytxt.Text;
            String street = streettxt.Text;
            String latitude = latitudetxt.Text;
            String longitude = longitudetxt.Text;
            
            Boolean goodInput = false;
            
            
            if (MainWindow.isWord(country) && MainWindow.isWord(city))
            
                goodInput = true;
            if (goodInput && BL_manager.BL_location.Add(country,city,street,latitude,longitude))
            {
                MessageBox.Show("New store location added succefully!");               
            }
            else
            {
                MessageBox.Show("There where a problem.\n One or more from the fields is incorrect, please try again", "Problem", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            

        }

    }
}
