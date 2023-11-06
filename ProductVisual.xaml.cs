using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp3
{
	public partial class ProductVisual : UserControl
	{
		Product ThisProduct;
		private MainWindow EvokingWindow;
		public ProductVisual(MainWindow MainWindow, int productId)
		{
			InitializeComponent();
			BookShopContext dbCont = new BookShopContext();
			ThisProduct = dbCont.Products.Find(productId);
			EvokingWindow = MainWindow;
			ProductImage.Source = new BitmapImage(new Uri(ThisProduct.PathToImage, UriKind.RelativeOrAbsolute));
			ProductNameLabel.Content = ThisProduct.Name;
			ProductPriceLabel.Content = ThisProduct.Price;
			if (ThisProduct.Stock < 1)
			{
				ProductAddButton.IsEnabled = false;
				this.Background = Brushes.Gray;
			}
		}

		private void ProductAddButton_Click(object sender, RoutedEventArgs e)
		{
			if (EvokingWindow.Basket.ContainsKey(ThisProduct.Id))
				EvokingWindow.Basket[ThisProduct.Id] += 1;
			else EvokingWindow.Basket.Add(ThisProduct.Id, 1);
			BasketWindow.UpdateBasket();
			EvokingWindow.TurnOnBasketButton();
			MessageBox.Show("Товар успешно добавлен!");
		}
	}
}
