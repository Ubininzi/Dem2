using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp3
{
	public partial class BasketWindow : Window
	{
		public MainWindow EvokingWindow;
		public Dictionary<int, int> Basket = new();

		public BasketWindow(MainWindow evokingWindow,Dictionary<int, int> basket)
		{
			InitializeComponent();
			EvokingWindow = evokingWindow;
			Basket = basket;
			CreateBasket();
		}

		public static void UpdateBasket()
		{
			foreach (BasketWindow window in Application.Current.Windows.OfType<BasketWindow>())
				window.RefreshBasket();
		}
		private void CreateBasket() {
			BookShopContext dbCont = new BookShopContext();
			foreach (var item in dbCont.Products)
				if (Basket.ContainsKey(item.Id))
					BasketProductPanel.Children.Add(new BasketProductVisual(this, item.Id, Basket[item.Id]));
		}
		public void RefreshBasket() { 
			foreach (var item in Basket)
				if (item.Value < 1)
					Basket.Remove(item.Key);

			BasketProductPanel.Children.Clear();
			CreateBasket();
		}
		private void BasketWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			EvokingWindow.IsBasketWindowActive = false;
			EvokingWindow.TurnOnBasketButton();
		}

	}
}
