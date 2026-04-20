using GameRougelike.Modules.Entities;
using GameRougelike.Modules.Equipment;
using GameRougelike.Modules.Factory;
using GameRougelike.Modules.Rooms;
using ISIP523_Sidorov.Modules;
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
        public Weapon weapon = new Weapon();
        public Armor armor = new Armor();
        public Hero hero;
        public static Room room;
        public int roomsCount = 0;
        public int levelsCount = 1;
        public GamePage(Hero _hero)
        {
            InitializeComponent();
            hero = _hero;
            room = NewRoom.RandomRoom(this);
            roomsCount++;
            LoadEnemies();

            LevelTB.Text = $"Этаж {levelsCount}";
            HpBar.Minimum = 0;
            HpBar.Maximum = hero.HP;
            HpBar.Value = hero.HP;
        }

        public void LoadEnemies()
        {
            if (room is EnemyRoom)
            {
                LootTB.Text = null;
                HeroLootTB.Text = null;
                LootImg.Source = null;
                AtkBtn.Content = "Атака";
                BlockBtn.Content = "Защита";

                EnemiesLB.ItemsSource = null;
                EnemiesLB.ItemsSource = (room as EnemyRoom).CreateElements();
            }
            else if(room is ChestRoom)
            {
                EnemiesLB.ItemsSource = null;
                AtkBtn.Content = "Взять";
                BlockBtn.Content = "Оставить";

                LootTB.Text = null;
                HeroLootTB.Text = null;
                BaseItem item = (room as ChestRoom).CreateElements();
                if(item is Weapon)
                {
                    LootTB.Text = (item as Weapon).WeaponInfo();
                    HeroLootTB.Text = hero.Weapon.WeaponInfo();
                }
                else if (item is Armor)
                {
                    LootTB.Text = (item as Armor).ArmorInfo();
                    HeroLootTB.Text = hero.Armor.ArmorInfo();
                }
                else
                {
                    LootTB.Text = "Зелье лечения\n" +
                        "Восстанавливает всё здоровье";
                }
                LootImg.Source = new BitmapImage(new Uri(item.itemImg, UriKind.Absolute));
            }

        }

        private void AtkBtn_Click(object sender, RoutedEventArgs e)
        {
            room.Action("ATK");
            if(hero.HP < 0)
            {
                NavigationService.Navigate(new EndPage());
            }
            HpBar.Value = hero.HP;
            HeroHpTB.Text = "HP " + $"{hero.HP}" + "/200";
            NewRoomCheck();
            LoadEnemies();
        }

        private void BlockBtn_Click(object sender, RoutedEventArgs e)
        {
            room.Action("DEF");
            if (hero.HP < 0)
            {
                // Позже надо перенаправить на страницу с экраном завершения
                LogShow("Вы проиграли");
            }
            HpBar.Value = hero.HP;
            HeroHpTB.Text = "HP " + $"{hero.HP}" + "/200";
            
            NewRoomCheck();
            LoadEnemies();
        }

        public void LogShow(string str)
        {
            LogsTB.Text += str + "\n";
            LogsTB.ScrollToEnd();
        }

        public void NewRoomCheck()
        {
            if (room.isClear)
            {
                roomsCount++;
                if(room is BossRoom)
                {
                    levelsCount++;
                    LevelTB.Text = $"Этаж: {levelsCount}";
                }
                if(roomsCount % 10 != 0)
                {
                    room = NewRoom.RandomRoom(this);
                }
                else
                {
                    room = new BossRoom(this);
                }
            }
        }
    }
}
