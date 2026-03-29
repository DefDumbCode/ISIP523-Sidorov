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
            PartsLB.ItemsSource = MainWindow.assemble.parts;
            
            
        }

        private void CPUBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            basepart_ selectedPart = btn.DataContext as basepart_;
            parttype_ part = parttype_s.FirstOrDefault(p => p.id == selectedPart.parttypeid);
            NavigationService.Navigate(new CPUPage(part));
        }
    }
}
