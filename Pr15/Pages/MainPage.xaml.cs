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
        public static List<partassembly_> partassembly_s  = Core.Context.partassembly_.ToList();
        
        public MainPage()
        {
            InitializeComponent();
            PartsLB.ItemsSource = MainWindow.assemble.parts;
            AuthorTB.Text = MainWindow.assemble.author;
            BuildTB.Text = MainWindow.assemble.buildName;
            MainWindow.assemble.IsCompatible();
            if (MainWindow.assemble.isCompatible)
            {
                CompatibleTB.Text = "Сборка пойдёт";
            }
            else
            {
                CompatibleTB.Text = "Сборка не пойдёт";
            }
            PriceTB.Text += MainWindow.assemble.CalculatePrice().ToString();
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            basepart_ selectedPart = btn.DataContext as basepart_;
            parttype_ part = parttype_s.FirstOrDefault(p => p.id == selectedPart.parttypeid);
            NavigationService.Navigate(new CPUPage(part));
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(AuthorTB.Text) && !String.IsNullOrEmpty(BuildTB.Text))
            {
                MainWindow.assemble.author = AuthorTB.Text;
                MainWindow.assemble.buildName = BuildTB.Text;
                assembly_ selectedAssembly = Core.Context.assembly_.ToList().FirstOrDefault(a => 
                a.name == MainWindow.assemble.buildName && a.author == MainWindow.assemble.author);

                if(selectedAssembly != null)
                {

                    List<partassembly_> partassemblies = partassembly_s
                        .Where(pa => pa.assemblyid == selectedAssembly.id).ToList();
                    foreach (partassembly_ partassembly in partassemblies)
                    {
                        partassembly.partid = MainWindow.assemble.parts
                            .FirstOrDefault(p => p.parttypeid == partassembly.basepart_.parttypeid).id;
                    }
                    Core.Context.SaveChanges();
                    MessageBox.Show("Сборка успешно изменена");
                }
                else
                {
                    assembly_ assembly = new assembly_() { 
                        author = MainWindow.assemble.author, 
                        name = MainWindow.assemble.buildName 
                    };
                    Core.Context.assembly_.Add(assembly);
                    Core.Context.SaveChanges();
                    

                    foreach (basepart_ part in MainWindow.assemble.parts)
                    {
                        if (part.id != 0)
                        {
                            partassembly_ partassembly = new partassembly_()
                            {
                                assemblyid = assembly.id,
                                partid = part.id,
                            };
                            Core.Context.partassembly_.Add(partassembly);
                            partassembly_s.Add(partassembly);
                        }
                    }
                    Core.Context.SaveChanges();

                    MessageBox.Show("Сборка успешно сохранена");
                }

            }
            else
            {
                MessageBox.Show("Вы не ввели название сборки или автора");
            }
        }

        private void ToBuildsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BuildsPage());
        }
    }
}
