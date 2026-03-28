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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static List<parttype_> parttype_s = Core.Context.parttype_.ToList(); 
        public MainPage()
        {
            InitializeComponent();
        }

        private void CPUBtn_Click(object sender, RoutedEventArgs e)
        {
            parttype_ part = parttype_s.FirstOrDefault(p => p.name == "CPU");
            NavigationService.Navigate(new CPUPage(part));
        }

        private void GPUBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RAMBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MotherboardBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CaseBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PowerSupplyBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CoolerBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StorageBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
