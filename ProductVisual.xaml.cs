using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp3
{
	public partial class ProductVisual : UserControl
	{
		private Product ThisProduct;
		private MainWindow EvokingWindow;
		public ProductVisual(MainWindow MainWindow, int productId,bool admined)
		{
			InitializeComponent();
			BookShopContext dbCont = new BookShopContext();
			ThisProduct = dbCont.Products.Find(productId);
			EvokingWindow = MainWindow;
			ProductImage.Source = new BitmapImage(new Uri(ThisProduct.PathToImage, UriKind.RelativeOrAbsolute));
			ProductNameLabel.Content = ThisProduct.Name;
			ProductPriceLabel.Content = ThisProduct.Price;
			if (admined) {
				ColumnDefinition col = new ColumnDefinition();
				col.Width = new GridLength(0.5, GridUnitType.Star);
				MainGrid.ColumnDefinitions.Add(col);
				ProductDeleteButton.IsEnabled = true;
			}
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
        private void ProductDeleteButton_Click(object sender, RoutedEventArgs e)
        {
			BookShopContext db = new BookShopContext();
			db.Products.Remove(ThisProduct);
			db.SaveChanges();
			EvokingWindow.ProductPanel.Children.Remove(this);
			//EvokingWindow.UpdateProductsList();
        }
    }
}
