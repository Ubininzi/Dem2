using System.Linq;
using System.Windows;


namespace WpfApp3
{
    public partial class AuthWindow : Window
    {
        private MainWindow EvokingWindow;
        public AuthWindow(MainWindow MainWindow)
        {
            InitializeComponent();
            this.EvokingWindow = MainWindow;
        }

        private void Authorize_Click(object sender, RoutedEventArgs e)
        {
            BookShopContext db = new BookShopContext();
            bool auth = false,admined = false;
            Login log = new Login();
            foreach (Login item in db.Logins)
            {
                if (item.Login1 == this.LoginTextBox.Text && item.Password == this.PasswordTextBox.Text)
                {
                    auth = true;
                    log = item;
                    break;
                }
            }
            if (auth && log.Role == db.Roles.First(x => x.Rolename == "ADMIN").Id) {
                admined = true;
            }
            EvokingWindow.IsAdmined = admined;
            EvokingWindow.IsAuth = auth;
            if (auth)
            {
                MessageBox.Show("авторизация успешна");
                EvokingWindow.UpdateAuth();
                this.Close();
            }
            else {
                MessageBox.Show("логин или пароль не найдены");
            }
        }
    }
}
