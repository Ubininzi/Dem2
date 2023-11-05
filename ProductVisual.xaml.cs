using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp3
{
	public partial class ProductVisual : UserControl

	{
		public ProductVisual(string ProductName,decimal? ProductPrice,string PathToImage)
		{
			InitializeComponent();
			ProductImage.Source = new BitmapImage(new Uri(PathToImage, UriKind.RelativeOrAbsolute));
            ProductNameLabel.Content = ProductName;
            ProductPriceLabel.Content = ProductPrice;
        }

		private void ProductAddButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Товар успешно добавлен!");
		}
	}
}
