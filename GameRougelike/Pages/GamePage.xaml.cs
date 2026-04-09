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
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public static Weapon weapon = new Weapon();
        public static Armor armor = new Armor();
        public static Hero hero = new Hero(weapon, armor);
        public GamePage()
        {
            InitializeComponent();
            
        }

        private void AtkBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BlockBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
