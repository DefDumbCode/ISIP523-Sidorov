using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Equipment
{
    public class Armor
    {
        public string Name;
        public double DEF;

        public Armor(string name, int def)
        {
            Name = name;
            DEF = def;
        }

        public Armor()
        {
            Name = "Старый доспех";
            DEF = 0.2;
        }

        public void ArmorInfo()
        {
            Console.WriteLine($"Доспехи:\n" +
                $"Название: {Name}\n" +
                $"Защита: {DEF}");
        }
    }
}
