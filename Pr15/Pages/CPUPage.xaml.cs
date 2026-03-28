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
        public CPUPage(parttype_ part)
        {
            InitializeComponent();
            CPULB.ItemsSource = partsList.Where(p => p.parttypeid == part.id);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
