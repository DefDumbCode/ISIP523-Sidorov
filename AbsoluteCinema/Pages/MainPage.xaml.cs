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
        public MainPage()
        {
            InitializeComponent();
            FilmsLB.ItemsSource = FilmsList;
        }

        private void FilmsLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchTB_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
