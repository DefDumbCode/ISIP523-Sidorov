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

namespace AbsoluteCinema.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public static List<Accounts> accounts = Core.Context.Accounts.ToList();
        public LoginPage()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Accounts login_try = accounts.FirstOrDefault(a => a.AccountLogin == FioTB.Text);
            if (login_try != null)
            {
                if(PasswordTB.Text == login_try.AccountPassword)
                {
                    MainWindow.User = login_try;
                    if(NavigationService.CanGoBack)
                    {
                        NavigationService.GoBack();
                    }
                }
            }
            else
            {
                MessageBox.Show("Неправильно введен логин или пароль!");
                PasswordTB.Text = "";
            }
        }

        private void FioTB_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void PasswordTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(FioTB.Text) && !String.IsNullOrEmpty(PasswordTB.Text))
            {
                LoginBtn.IsEnabled = true;
            }
        }
    }
}
