using System;
using System.Collections.Concurrent;
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
    /// Логика взаимодействия для CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        Orders order;
        List<Cart> cart;
        public CartPage( Orders _order, List<Cart> _cart)
        {
            InitializeComponent();
            order = _order;
            cart = _cart;
            List<Products> ProdsInCart = new List<Products>();
            foreach (var product in cart) 
            {
                //ProdsInCart.Add(ProductsData.ProductsList.ToList().FirstOrDefault(p => p.ProductID == product.ProductID));
            }
            ProductsLB.ItemsSource = ProdsInCart;


        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService?.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)

        {
            NavigationService.Navigate(new ConfirmPage(order, cart));
        }

        private void ProductsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
