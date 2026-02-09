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
    /// Логика взаимодействия для TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        public static SessionSeat _sessionSeat;
        public static double price = 500;
        public TicketPage(SessionSeat sessionSeat)
        {
            InitializeComponent();
            DataContext = sessionSeat;
            _sessionSeat = sessionSeat;
            switch (sessionSeat.Session.Rooms.RoomRate.RateName)
            {
                case "VIP":
                    price *= 1.5;
                    break;
                case "Люкс":
                    price *= 1.3;
                    break;
                case "Обычный":
                    break;
                default:
                    break;
            }
            PriceTB.Text += price.ToString();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack) 
            {
                NavigationService.GoBack();
            }
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = new Ticket 
            {
                SeatID = _sessionSeat.SeatID,
                AccountID = MainWindow.User.AccountID,
                TicketPrice = price,
                SessionID = _sessionSeat.SessionID,
            };
            Core.Context.Ticket.Add(ticket);
            Core.Context.SessionSeat.First(ses => ses.SessionSeatID == _sessionSeat.SessionSeatID).Taken = true;

            Core.Context.SaveChanges();

            MessageBox.Show("Билет успешно оформлен!");
            NavigationService.Navigate(new MainPage());
        }
    }
}
