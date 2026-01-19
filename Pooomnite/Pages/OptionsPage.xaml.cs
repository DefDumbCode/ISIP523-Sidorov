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

namespace Pooomnite.Pages
{
    /// <summary>
    /// Логика взаимодействия для OptionsPage.xaml
    /// </summary>
    public partial class OptionsPage : Page
    {
        Pizza pizza;
        Ingredient ingredient;

        public OptionsPage(Pizza _pizza)
        {
            InitializeComponent();
            pizza = _pizza;
            SelectInredient.ItemsSource = IngredientData.IngredientList;
            SelectInredient.SelectedIndex = 0;
        }

        private void MediumPizzaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            pizza.Size = "Среднеротый";
            NextBtn.IsEnabled = true;
        }

        private void BigPizzaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            pizza.Size = "Большеротый";
            NextBtn.IsEnabled = true;
        }

        private void SmallPizzaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            pizza.Size = "Малоротый";
            NextBtn.IsEnabled = true;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService?.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ConfirmPage(pizza));
        }

        private void SelectInredient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            var ingred = SelectInredient.SelectedItem as Ingredient;
            pizza.PizzaIngredients.Add(ingred);
            PizzasIngred.Text += $"\nНаименование: {ingred.IngredientName} \n" +
                $"Цена: {ingred.IngredientPrice}";

        }
    }
}
