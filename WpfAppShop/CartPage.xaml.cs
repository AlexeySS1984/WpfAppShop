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

namespace WpfAppShop
{
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LViewCart.ItemsSource = Core.MyCart;
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal sum = Core.MyCart.Sum(p => p.Price);
            TxtTotal.Text = $"Итого: {sum:N2} руб.";
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            Core.MyCart.Clear();
            LViewCart.Items.Refresh(); 
            UpdateTotal();
        }

        private void BtnCheckout_Click(object sender, RoutedEventArgs e)
        {
            if (Core.MyCart.Count == 0)
            {
                MessageBox.Show("Корзина пуста!");
                return;
            }
            NavigationService.Navigate(new CheckoutPage());
        }
    }
}
