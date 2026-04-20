using GameRougelike.Modules;
using ISIP523_Sidorov.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Enemies.Bosses
{
    internal class Pestov : Sekleton
    {
        public double Freeze;
        public Pestov()
        {
            EnemyName = "Пестов";
            MaxHP = Math.Round(HP * 1.3);
            HP = MaxHP;
            ATK = Math.Round(ATK * 1.8);
            DEF = Math.Round(DEF * 0.6);
            Freeze = 0.15 + 0.15;
        }

        public override string Attack(Hero Player, bool def)
        {
            string output = "";
            output += Player.GetDamage(ATK);
            if (Randomizer.IsCritOrFreezed(Freeze))
            {
                output += "\nВас заморозили! Вы пропускаете ход.\n";
                output += Attack(Player, true);
            }
            return output;
        }
    }
}
