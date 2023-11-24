using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.EntityFrameworkCore;


namespace WpfApp3
{
	public partial class MainWindow : Window
	{
		public bool IsBasketWindowActive = false;
		public bool IsAdmined = false;
		public bool IsAuth = false;
		public Dictionary<int, int> Basket = new();
		public MainWindow()
		{
			InitializeComponent();
			UpdateProductsList();
		}
		public void UpdateProductsList()
		{
			ProductPanel.Children.Clear();
			BookShopContext dbCont = new BookShopContext();
			foreach (var item in dbCont.Products)
				ProductPanel.Children.Add(new ProductVisual(this, item.Id, IsAdmined));
		}
		public void UpdateAuth() {
			AuthButton.Content = "Выйти из аккаунта";
			UpdateProductsList();
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

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
			if (!IsAuth)
			{
				AuthWindow authWindow = new AuthWindow(this);
				authWindow.Show();
			}
			else {
				AuthButton.Content = "Авторизация";
				IsAdmined = false;
				IsAuth = false;
				UpdateProductsList();
			}
        }

    }
}
