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

namespace WpfApp3
{
	/// <summary>
	/// Логика взаимодействия для product.xaml
	/// </summary>
	public partial class Product : UserControl

	{
		public Product(string PathToImage,string ProductName,int ProductPrice)
		{
			InitializeComponent();
			ProductImage.Source = new BitmapImage(new Uri(PathToImage, UriKind.Relative));
            ProductNameLabel.Content = ProductName;
            ProductPriceLabel.Content = ProductPrice;
        }

		private void ProductAddButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Ryjgrf");
		}
	}
}
