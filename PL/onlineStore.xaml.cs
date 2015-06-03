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
using Backend;
using BL;
namespace PL
{
    /// <summary>
    /// Interaction logic for onlineStore.xaml
    /// </summary>
    [Serializable]
    public partial class onlineStore : Window
    {
        BL_Manager BL_manager;
        public onlineStore(BL_Manager BL_manager)
        {
            this.BL_manager=BL_manager;
            InitializeComponent();
        }

        private void loadTypes(object sender, RoutedEventArgs e)
        {
            foreach (string type in Enum.GetNames(typeof(Product.Type)))
            {
                types.Items.Add(type);
                Console.WriteLine(type);
            }
            types.Items.Add("All");
            types.SelectedItem = "All";
        }
        private void loadProductView(object sender, RoutedEventArgs e)
        {
            //Button x = new Button();
            //x.Content="add to cart";
            //s.Children.Add(x);
            ProductView.Items.Clear();
            //ProductView.Items.Add(s);
            List<Product> selectedProducts;
            if(types.SelectedValue=="All")
            {
                selectedProducts = BL_manager.BL_product.getAllProductsList();
            }
            else
            {
                selectedProducts = BL_manager.BL_product.getProductsListByType((Product.Type)Enum.Parse(typeof(Product.Type), (string)types.SelectedValue));
            }

            foreach(Product p in selectedProducts)
            {
                StackPanel s = new StackPanel();
                s.Orientation = Orientation.Horizontal;
                TextBlock name = new TextBlock();
                name.Margin = new Thickness(0,0,5,0);
                name.Text =p.name;
                s.Children.Add(name);
                if(BL_manager.getBestSeller().Contains(p.name))
                {
                    TextBlock BestSeller = new TextBlock();
                    BestSeller.Margin = new Thickness(5, 0, 5, 0);
                    /**ImageBrush textImageBrush = new ImageBrush();
                    textImageBrush.ImageSource = new BitmapImage(new Uri(@"PL/Bestseller.jpg", UriKind.Relative));
                    textImageBrush.AlignmentX = AlignmentX.Left;
                    textImageBrush.Stretch = Stretch.None;
                    // Use the brush to paint the button's background.
                    BestSeller.Background = textImageBrush;**/
                    BestSeller.Text = "BEST SELLER!!!";
                    s.Children.Add(BestSeller);
                }
                TextBlock price = new TextBlock();
                price.Text = p.price.ToString()+"$";
                price.Margin = new Thickness(5, 0, 0, 0);
                s.Children.Add(price);
                Console.WriteLine(p.name);
                ProductView.Items.Add(s);
                Button addToCart = new Button();
                
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(types.SelectedValue);
            this.loadProductView(sender, e);
        }

    }
    
}
