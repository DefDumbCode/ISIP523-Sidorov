using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public static Accounts _user;
        public ProfilePage(Accounts User)
        {
            InitializeComponent();
            DataContext = User;
            _user = User;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ticket ticket = TicketsLB.SelectedItem as Ticket;
            NavigationService.Navigate(new TicketPage(ticket.Session.SessionSeat.First(ses => ses.SeatID == ticket.SeatID)));  
         }
    }
}
