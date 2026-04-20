using ISIP523_Sidorov.Modules.Entities;
using ISIP523_Sidorov.Modules.Equipment;
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

namespace GameRougelike.Pages
{
    /// <summary>
    /// Логика взаимодействия для EndPage.xaml
    /// </summary>
    public partial class EndPage : Page
    {
        public EndPage()
        {
            InitializeComponent();
        }

        private void AgainBtn_Click(object sender, RoutedEventArgs e)
        {
            Weapon weapon = new Weapon();
            Armor armor = new Armor();
            Hero hero = new Hero(weapon, armor);
            NavigationService.Navigate(new GamePage(hero));
        }
    }
}
