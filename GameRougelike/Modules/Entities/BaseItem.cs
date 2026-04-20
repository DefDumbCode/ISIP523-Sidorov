using ISIP523_Sidorov.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRougelike.Modules.Entities
{
    public abstract class BaseItem
    {
        public string itemImg { get; set; }
        public virtual void ItemApply(Hero hero)
        {
            
        }
    }
}
