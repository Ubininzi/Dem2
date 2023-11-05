using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;


namespace WpfApp3
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			BookShopContext dbCont = new BookShopContext();
			ProductPanel.Children.Add(new ProductVisual("test1", 150, "C:\\Users\\Максим\\Desktop\\wallpapers\\_F7dP5upuP4.jpg"));
			foreach (var item in dbCont.Products)
			{
				ProductPanel.Children.Add(new ProductVisual(item.Name,item.Price,item.PathToImage));
			}
		}
	}
}
