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
    public partial class Window1 : Window
    {
        private Club_Member member;
        private BL_Manager BL_manager;
        public Window1(BL_Manager BL_manager, string r, Club_Member c)
        {
            InitializeComponent();
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

        private void addInfo_Click(object sender, RoutedEventArgs e)
        {
            int creditNum = int.Parse(info.Text);
            BL_manager.BL_clubMember.itsDAL.updateMemberVisa(member.ID, creditNum);
            MessageBox.Show("visa number saved");
        }
    }
}
