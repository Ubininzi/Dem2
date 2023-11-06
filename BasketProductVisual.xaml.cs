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
			BasketProductImage.Source = new BitmapImage(new Uri(ThisProduct.PathToImage, UriKind.RelativeOrAbsolute));
			BasketProductNameLabel.Content = ThisProduct.Name;
			BasketProductPriceLabel.Content = ThisProduct.Price * quantity;
			ProductCountTextBox.Text = quantity.ToString();
			Quantity = quantity;
		}

		private void ProductCountUpButton_Click(object sender, RoutedEventArgs e)
		{
			Quantity++;
			UpdatePrice();
		}

		private void ProductCountDownButton_Click(object sender, RoutedEventArgs e)
		{
			Quantity--;
			UpdatePrice();
			if (Quantity <= 0) EvokingWindow.Basket.Remove(ThisProduct.Id);
			BasketWindow.UpdateBasket();
		}
		private void UpdatePrice() {
			BasketProductPriceLabel.Content = ThisProduct.Price * Quantity;
			ProductCountTextBox.Text = Quantity.ToString();
		}
		private void ProductCountTextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			BasketWindow.UpdateBasket();
			Quantity = Convert.ToInt32(ProductCountTextBox.Text);
			if (Quantity <= 0)
				EvokingWindow.Basket.Remove(ThisProduct.Id);
			UpdatePrice();
		}
	}
}
