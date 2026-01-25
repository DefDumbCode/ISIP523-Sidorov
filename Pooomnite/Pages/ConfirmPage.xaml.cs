using Pooomnite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Schema;

namespace Pooomnite.Pages
{
    /// <summary>
    /// Логика взаимодействия для ConfirmPage.xaml
    /// </summary>
    public partial class ConfirmPage : Page
    {
        public ConfirmPage(Pizza pizza)
        {
            InitializeComponent();

            double mult;
            switch (pizza.Size)
            {
                case "Большеротый":
                    mult = 1.4;
                    break;
                case "Среднеротый":
                    mult = 1.2;
                    break;
                case "Малоротый":
                    mult = 1.0;
                    break;
                default:
                    mult = 1;
                    break;
            }
            double total = pizza.Price * mult;

            OrderInfo.Text = $"Тип пиццы: {pizza.Name}.\n" +
                $"Размер: { pizza.Size}.\n" +
                $"Множитель размера: { mult}.\n" +
                $"Доп.  ингридиенты:\n";
            foreach(var ingred in pizza.PizzaIngredients)
            {
                OrderInfo.Text += $"    {ingred.IngredientName}.\n";
                total += ingred.IngredientPrice;
            }
            
            OrderInfo.Text += $"Стоимость: {total}";
        }
    }
}
