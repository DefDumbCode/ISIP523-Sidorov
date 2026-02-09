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
    /// Логика взаимодействия для SessionPage.xaml
    /// </summary>
    public partial class SessionPage : Page
    {
        public static List<Seats> seats = Core.Context.Seats.ToList();
        public static List<SessionSeat> sessionSeats = Core.Context.SessionSeat.ToList();
        public SessionPage(Session session)
        {
            InitializeComponent();
            sessionSeats = sessionSeats.Where(ses => ses.SessionID == session.SessionID).ToList();
            SeatsLB.ItemsSource = sessionSeats;
        }

        private void SeatsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToTicketBtn.IsEnabled = true;
        }

        private void ToTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            SessionSeat selectedSeat = SeatsLB.SelectedItem as SessionSeat;
            NavigationService.Navigate(new TicketPage(selectedSeat));
        }
    }
}
