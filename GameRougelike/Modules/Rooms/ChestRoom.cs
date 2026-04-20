using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GameRougelike.Modules.Entities;
using GameRougelike.Modules.Equipment;
using GameRougelike.Pages;
using ISIP523_Sidorov.Modules;
using ISIP523_Sidorov.Modules.Equipment;

namespace GameRougelike.Modules.Rooms
{
    public class ChestRoom : Room
    {
        BaseItem item;

        public ChestRoom(GamePage page)
        {
            Page = page;
            page.LogShow("Вы наткнулись на сундук");
            GenerateLoot();       
        }

        public void GenerateLoot()
        {
            string loot = Randomizer.GetRandomLoot();
            switch (loot)
            {
                case "оружие":
                    item = Randomizer.GenerateRandomWeapon();
                    Page.LogShow((item as Weapon).WeaponInfo());
                    break;
                case "броня":
                    item = Randomizer.GenerateRandomArmor();
                    Page.LogShow((item as Armor).ArmorInfo());
                    break;
                case "зелье":
                    item = new Potion();
                    Page.LogShow("Зелье лечения");
                    break;
                default:
                    item = new Potion();
                    Page.LogShow("Зелье лечения");
                    break;
            }
        }


        public override void Action(string choice)
        {
            if(choice == "ATK")
            {
                item.ItemApply(Page.hero);
                
            }
            else{
                Page.LogShow("Вы пропустили предмет");
            }
            isClear = true;
        }

        public BaseItem CreateElements()
        {
            return item;
        }

    }
}
