using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp3
{
	public partial class ProductVisual : UserControl
	{
		private int ProductId;
		private MainWindow EvokingWindow;
		public ProductVisual(MainWindow MainWindow,int productId ,string ProductName,decimal? ProductPrice,string PathToImage)
		{
			InitializeComponent();
			ProductId = productId;
			EvokingWindow = MainWindow;
			ProductImage.Source = new BitmapImage(new Uri(PathToImage, UriKind.RelativeOrAbsolute));
            ProductNameLabel.Content = ProductName;
            ProductPriceLabel.Content = ProductPrice;
        }

		private void ProductAddButton_Click(object sender, RoutedEventArgs e)
		{
			if (EvokingWindow.Basket.ContainsKey(ProductId))
				EvokingWindow.Basket[ProductId] += 1;
			else EvokingWindow.Basket.Add(ProductId, 1);
            //BasketWindow.Update();
            EvokingWindow.TurnOnBasketButtton();
			MessageBox.Show("Товар успешно добавлен!");
		}
	}
}
