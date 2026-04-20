using GameRougelike.Modules.Entities;
using ISIP523_Sidorov.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Equipment
{
    public class Armor : BaseItem
    {
        public string Name;
        public double DEF;

        public Armor(string name = "Ржавый доспех", int def = 70)
        {
            Name = name;
            DEF = def;
            itemImg = "https://cdn-icons-png.flaticon.com/512/1065/1065537.png";
        }

        public string ArmorInfo()
        {
            return $"Доспехи:\n" +
                $"Название: {Name}\n" +
                $"Защита: {DEF}";
        }

        public override void ItemApply(Hero hero)
        {
            hero.Armor = this;
        }
    }
}
