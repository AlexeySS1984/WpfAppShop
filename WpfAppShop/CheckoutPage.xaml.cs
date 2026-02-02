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
    public partial class CheckoutPage : Page
    {
        public CheckoutPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LViewOrderSummary.ItemsSource = Core.MyCart;
            decimal sum = Core.MyCart.Sum(p => p.Price);
            TxtFinalPrice.Text = $"К оплате: {sum:N2} руб.";
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtFIO.Text) || string.IsNullOrWhiteSpace(TxtAddress.Text))
            {
                MessageBox.Show("Заполните ФИО и адрес!");
                return;
            }

            Orders newOrder = new Orders();
            newOrder.FullName = TxtFIO.Text;
            newOrder.Email = TxtEmail.Text;
            newOrder.DeliveryAddress = TxtAddress.Text;
            newOrder.OrderDate = DateTime.Now;
            newOrder.TotalCost = Core.MyCart.Sum(p => p.Price);

            Core.Context.Orders.Add(newOrder);

            try
            {
                Core.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка БД: " + ex.Message);
                return;
            }

            foreach (var item in Core.MyCart)
            {
                OrderProducts link = new OrderProducts();
                link.OrderID = newOrder.OrderID;
                link.ProductID = item.ProductID;
                Core.Context.OrderProducts.Add(link);
            }
            Core.Context.SaveChanges();

            MessageBox.Show("Заказ успешно создан! Менеджер свяжется с вами.");
            Core.MyCart.Clear(); 
            NavigationService.Navigate(new ProductPage()); 
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
