using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRougelike.Modules.Entities;
using ISIP523_Sidorov.Modules.Entities;

namespace ISIP523_Sidorov.Modules.Equipment
{
    public class Weapon: BaseItem
    {
        public string Name;
        public int ATK;

        public Weapon(string name = "Ржавый меч", int atk = 12)
        {
            Name = name;
            ATK = atk;
            itemImg = "https://cdn-icons-png.flaticon.com/512/5683/5683480.png";
        }



        public string WeaponInfo()
        {
            return $"Оружие:\n" +
                $"Название: {Name}\n" +
                $"Урон: {ATK}";
        }

        public override void ItemApply(Hero hero)
        {
            hero.Weapon = this;
        }
    }
}
