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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if(PasswordTB.Text == PasswordRepTB.Text)
            {
                if(PasswordTB.Text.Length >= 8)
                {
                    MainWindow.User = new Accounts { AccountLogin = LoginTB.Text, AccountPassword = PasswordTB.Text };
                    Core.Context.Accounts.Add(MainWindow.User);
                    Core.Context.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно");
                    if (NavigationService.CanGoBack)
                    {
                        NavigationService.Navigate(new MainPage());
                    }
                }
                else
                {
                    MessageBox.Show("Пароль должен иметь длину не менее 8 символов");
                }

            }
            else
            {
                MessageBox.Show("Пароли не совпадают");
            }
        }

        private void LoginTB_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void PasswordTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(LoginTB.Text) && !String.IsNullOrEmpty(PasswordTB.Text)
                && !String.IsNullOrEmpty(PasswordRepTB.Text))
            {
                RegBtn.IsEnabled = true;
            }
        }
    }
}
