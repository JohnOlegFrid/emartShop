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

namespace PL.Customers
{
    /// <summary>
    /// Interaction logic for SearchEmployee.xaml
    /// </summary>
    public partial class Search : Page
    {
        BL_Manager BL_manager;

        public Search(BL_Manager BL_manager)
        {
            this.BL_manager = BL_manager;
            InitializeComponent();
        }


        private void Search_Click(object sender, RoutedEventArgs e)
        {
            List<Club_Member> list = new List<Club_Member>();
            if (byIDradio.IsChecked==true)
            {
                String id = searchtxt.Text;
                if (MainWindow.isNumber(id))
                {
                    list = BL_manager.BL_clubMember.getClubMemberByID(id);
                    searchResult.ItemsSource = list;
                    
                }  
            }
            else if (byNameradio.IsChecked == true)
            {
                String name = searchtxt.Text;
                if (MainWindow.isWord(name))
                {
                    list = BL_manager.BL_clubMember.getClubMemberByFirstName(name);
                    searchResult.ItemsSource = list;

                }
            }
            else if (byLastNameradio.IsChecked == true)
            {
                String lastName = searchtxt.Text;
                if (MainWindow.isWord(lastName))
                {
                    list = BL_manager.BL_clubMember.getClubMemberByLastname(lastName);
                    searchResult.ItemsSource = list;

                }
            }
        }

        private void editClick(object sender, RoutedEventArgs e)
        {
            Club_Member cus = (searchResult.SelectedItem as Club_Member);
            Customers.Edit ee = new Customers.Edit(BL_manager, cus);
            ee.Show();
        }

        private void showAllClick(object sender, RoutedEventArgs e)
        {
            List<Club_Member> list = BL_manager.BL_clubMember.getAllClubMembers();
            searchResult.ItemsSource = list;
        }

        

        

        

       
    }
}
