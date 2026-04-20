using GameRougelike.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRougelike.Modules.Entities
{
    public abstract class Room
    {
        public GamePage Page;
        public bool isClear;
        public virtual void Action(string choice)
        {
            
        } 
    }
}
