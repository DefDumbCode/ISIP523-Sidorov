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
    /// Логика взаимодействия для FilmPage.xaml
    /// </summary>
    public partial class FilmPage : Page
    {
        public static List<Genres> genres = Core.Context.Genres.ToList();
        public static List<FilmsGenre> filmsGenres = Core.Context.FilmsGenre.ToList();
        public static List<Session> sessions = Core.Context.Session.ToList();
        public static List<Rooms> rooms = Core.Context.Rooms.ToList();
        Films films {get; set; }
        public FilmPage(Films film)
        {
            InitializeComponent();
            sessions = Core.Context.Session.ToList();
            this.films = film;
            DataContext = films;
            //FilmImg.Source = film.ImagePath;//new BitmapImage(new Uri(film.ImagePath, UriKind.Absolute));
            FilmName.Text = film.FilmName;
            FilmRate.Text = film.FilmRate.ToString();

            List<FilmsGenre> fg = filmsGenres.Where(g => g.FilmID == film.FilmID).ToList();
            foreach (var filmsgenre in fg)
            {
                FilmGenres.Text += genres.FirstOrDefault(g => g.GenreID == filmsgenre.GenreID).GenreName.ToString();
                FilmGenres.Text += " ";
            }
            FilmDesc.Text = film.Description;

            sessions = sessions.Where(s => s.FilmID == film.FilmID).ToList();
            SessionsLB.ItemsSource = sessions;

        }

        private void Grid_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            
        }

        private void SessionsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainWindow.User != null)
            {
                Session selectedSession = SessionsLB.SelectedItem as Session;
                NavigationService.Navigate(new SessionPage(selectedSession));
            }
            else
            {
                MessageBox.Show("Оформление билетов доступно только зарегистрированным пользователям");
                NavigationService.Navigate(new LoginPage());
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void SessionsLB_Selected(object sender, RoutedEventArgs e)
        {
            if (MainWindow.User != null)
            {
                Session selectedSession = SessionsLB.SelectedItem as Session;
                NavigationService.Navigate(new SessionPage(selectedSession));
            }
            else
            {
                MessageBox.Show("Оформление билетов доступно только зарегистрированным пользователям");
                NavigationService.Navigate(new LoginPage());
            }
        }

  
    }
}
