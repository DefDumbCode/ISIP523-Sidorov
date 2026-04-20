using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Enemies
{
    internal class Slime : Enemy
    {
        public Slime() 
        {
            MaxHP = 30;
            HP = MaxHP;
            ATK = 4;
            DEF = 1;
            Race = Race.Slime;
            EnemyName = "Блёбик";
            enemyImg = "https://png.klev.club/uploads/posts/2024-06/png-klev-club-wgx5-p-slaimi-slaim-rancher-png-24.png";
        }

        public override string GetDamage(double Dmg)
        {
            return base.GetDamage(Dmg - 2);
        }
    }
}
