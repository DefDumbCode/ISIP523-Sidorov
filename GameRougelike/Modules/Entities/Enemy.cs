using ISIP523_Sidorov.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ISIP523_Sidorov.Modules.Game;

namespace ISIP523_Sidorov.Modules.Enemies
{
    public enum Race
    {
        Goblin = 1,
        Sekleton,
        Mage,
        Slime
    }
    public abstract class Enemy
    {
        public double MaxHP { get; set; }
        public double HP { get; set; }
        public double ATK;
        public double DEF;
        public Race Race;
        public string EnemyName { get; set; }
        public string enemyImg { get; set; } 
        public bool Disabled = true;


        public virtual string GetDamage(double Dmg)
        {
            HP = HP - Math.Round(Dmg - Dmg * DEF * 0.1);
            return $"{EnemyName} получил {Math.Round(Dmg - Dmg * DEF * 0.1)} урона.";
        }

        public virtual string Attack(Hero Player, bool def)
        {
            if (def == true)
            {
                return Player.GetDamage(ATK * (Player.Armor.DEF / 100));
            }
            else 
            { 
                return Player.GetDamage(ATK); 
            }
        }
    }
 }

