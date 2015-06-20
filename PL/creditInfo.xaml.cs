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

namespace PL
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class creditinfo : Window
    {
        private Person member;
        private BL_Manager BL_manager;
        public creditinfo(BL_Manager BL_manager, string r, Person c)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            member = c;
            this.BL_manager = BL_manager;
            string text = "";
            foreach (Backend.Receipt recipt in BL_manager.BL_transaction.itsDAL.receiptDB)
            {
                if(recipt.ID==r)
                {
                    string name = BL_manager.BL_product.getProductsInStockByID(recipt.product).name;
                    text += "\n" + recipt.amount + " " + name + " " + (recipt.amount * recipt.price) + "$";
                }
            }
            shoppingList.Text=text;
        }
      
        private void addInfo_Click(object sender, RoutedEventArgs e)
        {
            String inf = info.Text;
            if (MainWindow.isNumber(inf))
            {
                if(member is Club_Member)
                {
                    BL_manager.BL_clubMember.itsDAL.updateMemberVisa(member.ID, inf);
                    MessageBox.Show("visa number saved");
                    this.Close();
                }
                if(member is Employee)
                {
                    BL_manager.BL_employee.itsDAL.updateEmployeeVisa(member.ID, inf);
                    MessageBox.Show("visa number saved");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Incorrect Credit card number,please try again.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        

       
        

        

        
    }
}
