using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.EntityFrameworkCore;


namespace WpfApp3
{
	public partial class MainWindow : Window
	{
		public Dictionary<int, int> Basket = new();
		public MainWindow()
		{
			InitializeComponent();
			BookShopContext dbCont = new BookShopContext();
			//ProductPanel.Children.Add(new ProductVisual("test1", 150, "C:\\Users\\Максим\\Desktop\\wallpapers\\_F7dP5upuP4.jpg"));
			foreach (var item in dbCont.Products)
			{
				ProductPanel.Children.Add(new ProductVisual(this,item.Id,item.Name,item.Price,item.PathToImage));
			}

		}
		public void TurnOnBasketButtton() { 
			BasketButton.IsEnabled = true;
		}

        private void BasketButton_Click(object sender, RoutedEventArgs e)
        {
			//BasketWindow(Basket);
        }
    }
}
