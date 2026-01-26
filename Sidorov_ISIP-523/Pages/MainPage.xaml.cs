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

namespace Sidorov_ISIP_523.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<Cart> cart = new List<Cart>();
        Orders order = new Orders();

            public static List<Products> ProductsList = Core.Context.Products.ToList();
        
        public MainPage()
        {
            InitializeComponent();
            ProductsLB.ItemsSource = ProductsList;
            
        }

        private void ProductsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddToCartBtn.IsEnabled = true;
        }

        private void AddToCartBtn_Click(object sender, RoutedEventArgs e)
        {
           Products product = ProductsLB.SelectedItem as Products;
            Cart CartProd = new Cart { OrderID = order.OrderID, Amount = 1, ProductID = product.ProductID };
            cart.Add(CartProd);
            NextBtn.IsEnabled = true;
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CartPage(order, cart));
        }
    }
}
