using GameRougelike.Modules.Entities;
using ISIP523_Sidorov.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRougelike.Modules.Equipment
{
    public class Potion:BaseItem
    {
        public Potion()
        {
            itemImg = "https://cdn-icons-png.flaticon.com/512/8331/8331206.png";
        }
        public override void ItemApply(Hero hero)
        {
            hero.Heal();
        }
    }
}
