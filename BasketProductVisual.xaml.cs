using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp3
{
	public partial class BasketProductVisual : UserControl
	{
		private BasketWindow EvokingWindow;
		private int Quantity;
		Product ThisProduct;
		public BasketProductVisual(BasketWindow BasketWindow, int productId, int quantity)
		{
			InitializeComponent();
			BookShopContext dbCont = new BookShopContext();
			ThisProduct = dbCont.Products.Find(productId);
			EvokingWindow = BasketWindow;
			if (ThisProduct.PathToImage != null) {
				BasketProductImage.Source = new BitmapImage(new Uri(ThisProduct.PathToImage, UriKind.RelativeOrAbsolute));
			}
			BasketProductNameLabel.Content = ThisProduct.Name;
			BasketProductSumLabel.Content = new string($"{ThisProduct.Price * quantity * (1-(Decimal)ThisProduct.Discount) }");
			BasketProductPriceLabel.Content = new string($"{ThisProduct.Price} за ед.");
			BasketProductDiscountLabel.Content = new string($"Скидка {ThisProduct.Discount * 100}%");
			ProductCountTextBox.Text = quantity.ToString();
			Quantity = quantity;
		}

		private void ProductCountUpButton_Click(object sender, RoutedEventArgs e)
		{
			Quantity++;
			EvokingWindow.Basket[ThisProduct.Id]++;
            EvokingWindow.RefreshBasket();
			UpdatePrice();
        }

        private void ProductCountDownButton_Click(object sender, RoutedEventArgs e)
		{
			Quantity--;
            EvokingWindow.Basket[ThisProduct.Id]--;
            EvokingWindow.RefreshBasket();
			UpdatePrice();
        }
        private void UpdatePrice() {
			BasketProductPriceLabel.Content = ThisProduct.Price * Quantity;
			ProductCountTextBox.Text = Quantity.ToString();
 		}
		private void ProductCountTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			Quantity = Convert.ToInt32(ProductCountTextBox.Text);
			UpdatePrice();
			EvokingWindow.RefreshBasket();
		}

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            EvokingWindow.Basket.Remove(ThisProduct.Id);
            UpdatePrice();
            EvokingWindow.RefreshBasket();
        }

        private void ProductCountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Quantity = Convert.ToInt32(ProductCountTextBox.Text);
            UpdatePrice();
            EvokingWindow.RefreshBasket();
        }
    }
}
