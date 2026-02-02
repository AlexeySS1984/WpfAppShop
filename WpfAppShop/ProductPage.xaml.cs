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
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LViewProducts.ItemsSource = Core.Context.Products.ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var product = btn.DataContext as Products;

            Core.MyCart.Add(product);
            MessageBox.Show($"Товар '{product.Title}' добавлен в корзину!");
        }
    }
}