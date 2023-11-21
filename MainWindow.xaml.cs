using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.EntityFrameworkCore;


namespace WpfApp3
{
	public partial class MainWindow : Window
	{
		public bool IsBasketWindowActive = false;
		public Dictionary<int, int> Basket = new();
		public MainWindow()
		{
			InitializeComponent();
			BookShopContext dbCont = new BookShopContext();
			foreach (var item in dbCont.Products)
				ProductPanel.Children.Add(new ProductVisual(this, item.Id,false));

		}
		public void TurnOnBasketButton() { 
			if (!IsBasketWindowActive)
				BasketButton.IsEnabled = true;
		}

		private void BasketButton_Click(object sender, RoutedEventArgs e)
		{
			IsBasketWindowActive = true;
			BasketButton.IsEnabled = false;
			BasketWindow basketWindow = new BasketWindow(this,Basket);
			basketWindow.Show();
			BasketWindow.UpdateBasket();
		}
	}
}
