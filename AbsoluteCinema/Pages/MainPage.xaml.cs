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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static List<Films> FilmsList = Core.Context.Films.ToList();
        public static List<string> Sorting = new List<string> { "НАЗВАНИЮ", "РЕЙТИНГУ" };
        public MainPage()
        {
            InitializeComponent();
            FilmsLB.ItemsSource = FilmsList;
            SortByCB.ItemsSource = Sorting;
            SortByCB.SelectedIndex = 0;
        }

        private void FilmsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            FilmsLB.ItemsSource = FilmsList.Where(f => f.FilmName.ToLower().Contains(SearchTB.Text.ToLower()));
        }

        private void SortByCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (SortByCB.SelectedItem as string)
            {
                case "НАЗВАНИЮ":
                    FilmsLB.ItemsSource = FilmsList.OrderBy(f => f.FilmName);
                    break;
                case "РЕЙТИНГУ":
                    FilmsLB.ItemsSource = FilmsList.OrderByDescending(f => f.FilmRate);
                    break;
                default:
                    FilmsLB.ItemsSource = FilmsList.OrderBy(f => f.FilmName);
                    break;
            }
            
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilmsLB.ItemsSource = FilmsList.Where(f => f.FilmName.ToLower().Contains(SearchTB.Text.ToLower()));
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
