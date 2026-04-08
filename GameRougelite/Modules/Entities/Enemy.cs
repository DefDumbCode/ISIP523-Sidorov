using ISIP523_Sidorov.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ISIP523_Sidorov.Modules.Game;

namespace ISIP523_Sidorov.Modules.Enemies
{
    public abstract class Enemy
    {
        
        public double HP;
            public double ATK;
            public double DEF;
            public Race Race;

        public void EnemyInfo()
            {
                Console.WriteLine($"{Race}:\n" +
                    $"ОЗ: {HP}");
            }

            public virtual void GetDamage(double Dmg)
            {
                Console.WriteLine($"{Race} получил {Math.Round(Dmg / DEF)} урона.");
                HP = HP - Math.Round(Dmg / DEF);
            }

            public virtual void Attack(Hero Player, bool def, bool dodge)
            {
                if (dodge == false)
                {
                    if (def == true)
                    {
                        Player.GetDamage(ATK / Player.Armor.DEF);
                    }
                    else { Player.GetDamage(ATK); }
                }
                else
                {
                    Console.WriteLine("Вы успешно уклонились от атаки");
                }
            }

    }
 }

