using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pooomnite.Models
{
    public class Pizza
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Size { get; set; }
    }

    public partial class MainPage : Page
    {
        public List<Pizza> PizzasList = new List<Pizza>
        {
            new Pizza
            {
                Name = "Маргарита",
                Description = "Крутая пицца Маргарита",
                Price = 400
            },

            new Pizza
            {
                Name = "4 Сыра",
                Description = "Иди на все 4 стороны с этой пиццой",
                Price = 450
            },

            new Pizza
            {
                Name = "Охотничья",
                Description = "Нет, она не сделает тебя охотником",
                Price = 500
            },

            new Pizza
            {
                Name = "Пирог",
                Description = "Господь не будет так милостив с тобой...",
                Price = 400
            },

            new Pizza
            {
                Name = "Гавайская",
                Description = "Видимо, у тебя нет друзей",
                Price = 400
            }
        };
    }
}
