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

namespace GameRougelite.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        //static Weapon weapon = new Weapon();
        //static Armor armor = new Armor();
        //static Hero hero = new Hero(weapon, armor);
        //static Enemy enemy;
        
        public MainPage()
        {
            InitializeComponent();
            
        }


        private void AtkBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BlockBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private string GenerateRoom()
        {
            Random rand = new Random();

            double throws = rand.NextDouble();
            if (throws >= 0.5)
            {
                return "сундук";
            }
            else
            {
                return "противник";
            }
        }

    }
}
