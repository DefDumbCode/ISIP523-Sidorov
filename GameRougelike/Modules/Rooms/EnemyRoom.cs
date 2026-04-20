using GameRougelike.Modules.Entities;
using GameRougelike.Pages;
using ISIP523_Sidorov.Modules.Enemies;
using ISIP523_Sidorov.Modules.Entities;
using ISIP523_Sidorov.Modules.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GameRougelike.Modules.Rooms
{
    public class EnemyRoom:Room
    {
        List<Enemy> enemies;
        int activeEnemies;
        public EnemyRoom(GamePage gamePage)
        {
            Page = gamePage;
            enemies = new List<Enemy>();
            gamePage.LogShow("Вы наткнулись на комнату с противниками!");
            activeEnemies = Randomizer.GetRandomEnemiesAmount();
            for (int i = 0; i < activeEnemies; i++)
            {
                enemies.Add(NewEnemy.RandomEnemy());
            }
            enemies.First().Disabled = false;

            gamePage.LogShow("Ваши противники:");
            foreach(Enemy enemy in enemies)
            {
                gamePage.LogShow($"{enemy.EnemyName}");
            }
        }

        public override void Action(string choice)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.Disabled == false)
                {
                    bool def = false;
                    bool dodge = false;
                    if (choice == "ATK")
                    {
                        Page.LogShow(enemy.GetDamage(Page.hero.Weapon.ATK));
                    }
                    else
                    {
                        dodge = Randomizer.Dodge();
                        def = true;
                    }

                    if (enemy.HP > 0)
                    {
                        if (dodge)
                        {
                            Page.LogShow("Вы успешно уклонились от атаки");
                        }
                        else
                        {
                            Page.LogShow(enemy.Attack(Page.hero, def));

                        }
                    }
                    else
                    {
                        Page.LogShow($"Вы победили {enemy.Race}");
                        enemy.Disabled = true;
                        activeEnemies--;
                        if (activeEnemies != 0)
                        {
                            enemies[enemies.Count - activeEnemies].Disabled = false;
                        }
                    }
                }
            }
            if (activeEnemies == 0)
            {
                Page.LogShow($"Комната зачищена!");
                isClear = true;
                enemies.Clear();
            }
        }
        public virtual List<Enemy> CreateElements()
        {
           return enemies;
        }



    }
}
