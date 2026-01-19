using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pooomnite.Models
{
    public class Ingredient
    {
        public string IngredientName { get; set; }
        public int IngredientPrice { get; set; }
    }
    public partial class IngredientData
    {
        public static List<Ingredient> IngredientList = new List<Ingredient>
        {
            new Ingredient
            {
                IngredientName = "Сыр",
                IngredientPrice = 40
            },

            new Ingredient
            {
                IngredientName = "Пепе-ронин",
                IngredientPrice = 55
            },

            new Ingredient
            {
                IngredientName = "Санчоусы",
                IngredientPrice = 50
            },
        };
    }
}
