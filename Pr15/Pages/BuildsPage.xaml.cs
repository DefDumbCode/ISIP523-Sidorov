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
    /// Логика взаимодействия для BuildsPage.xaml
    /// </summary>
    public partial class BuildsPage : Page
    {
        public List<partassembly_> partassembly_s = Core.Context.partassembly_.ToList();
        public List<assembly_> assembly_s = Core.Context.assembly_.ToList();
        public BuildsPage()
        {
            InitializeComponent();
            AssemblesLB.ItemsSource = assembly_s;
            
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            assembly_ assembly = btn.DataContext as assembly_;
            List<basepart_> parts = assembly.partassembly_.Select(p => p.basepart_).ToList();
            MainWindow.assemble.parts = parts;
            MainWindow.assemble.author = assembly.author;
            MainWindow.assemble.buildName = assembly.name;
            NavigationService.Navigate(new MainPage());
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }

        }

        private void DelBTN_Click(object sender, RoutedEventArgs e)
        {
            assembly_ assembly = AssemblesLB.SelectedItem as assembly_;

            List<partassembly_> partassemblies = assembly.partassembly_.ToList();
            foreach(partassembly_ partassembly in partassemblies)
            {
                Core.Context.partassembly_.Remove(partassembly);
            }
            Core.Context.assembly_.Remove(assembly);
            assembly_s.Remove(assembly);
            AssemblesLB.ItemsSource = null;
            AssemblesLB.ItemsSource = assembly_s;
            Core.Context.SaveChanges();
            
        }

        private void AssemblesLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DelBTN.IsEnabled = true;
        }
    }
}
