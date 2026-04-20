using GameRougelike.Modules.Entities;
using GameRougelike.Modules.Rooms;
using GameRougelike.Pages;
using ISIP523_Sidorov.Modules.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRougelike.Modules.Factory
{
    public static class NewRoom
    {
        public static Room RandomRoom(GamePage page)
        {
            Random random = new Random();
            switch (random.Next(1, 3))
            {
                case 1:
                    return new ChestRoom(page);
                    break;
                case 2:
                    return new EnemyRoom(page);
                    break;
                default: return new ChestRoom(page);
            }
        }
    }
}
