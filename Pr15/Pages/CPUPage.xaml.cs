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

namespace Pr15.Pages
{
    /// <summary>
    /// Логика взаимодействия для CPUPage.xaml
    /// </summary>
    public partial class CPUPage : Page
    {
        public static List<basepart_> partsList = Core.Context.basepart_.ToList();
        public static List<basepart_> pageParts = new List<basepart_>();
        public static List<string> manufacturers = new List<string>() {"Все" };
        public CPUPage(parttype_ part)
        {
            InitializeComponent();
            manufacturers = new List<string>() { "Все" };
            pageParts = partsList.Where(p => p.parttypeid == part.id).ToList();
            CPULB.ItemsSource = pageParts;
            
            foreach (basepart_ item in pageParts)
            {
                manufacturers.Add(item.manufacturer_.name);
            }
            manufacturers = manufacturers.Distinct().ToList();
            ManufacturersCB.ItemsSource = manufacturers;
            ManufacturersCB.SelectedIndex = 0;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            basepart_ selectedPart = btn.DataContext as basepart_;
            bool isCompatible = MainWindow.assemble.IsCompatible(selectedPart);

            if (isCompatible)
            {
                int partIndexToRemove = MainWindow.assemble.parts.IndexOf(MainWindow.assemble.parts.Find(p => p.parttypeid == selectedPart.parttypeid));
                MainWindow.assemble.parts.RemoveAt(partIndexToRemove);
                MainWindow.assemble.parts.Insert(partIndexToRemove, selectedPart);
                if (NavigationService.CanGoBack)
                {
                    NavigationService.Navigate(new MainPage());
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Ты создаёшь Франкенштейна.\n" +
                    "Ты уверен, что хочешь это?", "Стой, стой, стой!",
                    MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    int partIndexToRemove = MainWindow.assemble.parts.IndexOf(MainWindow.assemble.parts.Find(p => p.parttypeid == selectedPart.parttypeid));
                    MainWindow.assemble.parts.RemoveAt(partIndexToRemove);
                    MainWindow.assemble.parts.Insert(partIndexToRemove, selectedPart);
                    
                    if (NavigationService.CanGoBack)
                    {
                        NavigationService.Navigate(new MainPage());
                    }
                }
                
            }
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }  
        }

        
        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUI();
        }

        private void ManufacturersCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUI();
        }

        public void UpdateUI()
        {
            List<basepart_> filtered = pageParts;
            filtered = filtered.Where(p => p.name.ToLower().Contains(SearchTB.Text.ToLower())).ToList();
            if (ManufacturersCB.SelectedItem as string != "Все")
            {
                filtered = filtered.Where(p => p.manufacturer_.name.Contains(ManufacturersCB.SelectedItem as string)).ToList();
            }
            CPULB.ItemsSource = filtered;
        }
    }
}
