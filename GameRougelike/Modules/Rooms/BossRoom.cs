using GameRougelike.Pages;
using ISIP523_Sidorov.Modules.Enemies;
using ISIP523_Sidorov.Modules.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRougelike.Modules.Rooms
{
    public class BossRoom : EnemyRoom
    {
        Enemy boss;
        public BossRoom(GamePage gamePage) 
            : base(gamePage)
        {
            Page = gamePage;
            gamePage.LogShow("Вы наткнулись на комнату с боссом!");
            boss = NewEnemy.RandomBoss();
            boss.Disabled = false;

            gamePage.LogShow("Ваш противник:");
            gamePage.LogShow($"{boss.EnemyName}");
        }

        public override void Action(string choice)
        {
            bool def = false;
            bool dodge = false;
            if (choice == "ATK")
            {
                Page.LogShow(boss.GetDamage(Page.hero.Weapon.ATK));
            }
            else
            {
                dodge = Randomizer.Dodge();
                def = true;
            }

            if (boss.HP > 0)
            {
                if (dodge)
                {
                    Page.LogShow("Вы успешно уклонились от атаки");
                }
                else
                {
                    Page.LogShow(boss.Attack(Page.hero, def));

                }
            }
            else
            {
                Page.LogShow($"Вы победили {boss.Race}");
                Page.LogShow($"Комната зачищена!");
                isClear = true;
            }
        }

        public override List<Enemy> CreateElements()
        {
            return new List<Enemy>() {boss};
        }
    }
}
