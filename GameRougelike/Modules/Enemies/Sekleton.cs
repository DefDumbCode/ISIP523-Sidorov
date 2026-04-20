using ISIP523_Sidorov.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Enemies
{
    public class Sekleton : Enemy
    {

        public Sekleton()
        {
            MaxHP = 40;
            HP = MaxHP; 
            ATK = 10;
            DEF = 5;
            Race = Race.Sekleton;
            EnemyName = "Крутой секлет";
            enemyImg = "https://cdn-icons-png.flaticon.com/512/7671/7671843.png";
        }

        public override string Attack(Hero Player, bool def)
        {
            return Player.GetDamage(ATK);
        }
    }
}
