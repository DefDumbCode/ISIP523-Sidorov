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
            CPULB.ItemsSource = Filter(part);

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            basepart_ selectedPart = btn.DataContext as basepart_;
            int partIndexToRemove = MainWindow.assemble.parts.IndexOf(MainWindow.assemble.parts.Find(p => p.parttypeid == selectedPart.parttypeid));
            MainWindow.assemble.parts.RemoveAt(partIndexToRemove);
            MainWindow.assemble.parts.Insert(partIndexToRemove, selectedPart);

            if (NavigationService.CanGoBack)
            {
                NavigationService.Navigate(new MainPage());
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }  
        }

        public List<basepart_> Filter(parttype_ parttype)
        {
            List<basepart_> assembleParts = MainWindow.assemble.parts;
            List<basepart_> filtered = partsList.Where(p => p.parttypeid == parttype.id).ToList();

            // Получение всех текущих комплектующих сборки
            cpu_ cpu = assembleParts.FirstOrDefault(p => p.parttypeid == 1).cpu_;
            gpu_ gpu = assembleParts.FirstOrDefault(p => p.parttypeid == 2).gpu_;
            ram_ ram = assembleParts.FirstOrDefault(p => p.parttypeid == 3).ram_;
            motherboard_ motherboard = assembleParts.FirstOrDefault(p => p.parttypeid == 4).motherboard_;
            case_ casePC = assembleParts.FirstOrDefault(p => p.parttypeid == 5).case_;
            powersupply_ powersupply = assembleParts.FirstOrDefault(p => p.parttypeid == 6).powersupply_;
            processorcooler_ processorcooler = assembleParts.FirstOrDefault(p => p.parttypeid == 7).processorcooler_;
            storagedevice_ storagedevice = assembleParts.FirstOrDefault(p => p.parttypeid == 8).storagedevice_;


            switch (parttype.id) 
            {
                // CPU
                case 1:
                    // Фильтрация по сокету процессора и материнской платы
                    if (motherboard != null)
                    {
                        filtered = filtered.Where(p => p.cpu_.socketid == motherboard.socketid).ToList();
                    }

                    // Фильтрация по сокету кулера
                    if (processorcooler != null)
                    {
                        filtered = filtered.Where(p => p.cpu_.socket_.socketprocessorcooler_ == processorcooler.socketprocessorcooler_).ToList();
                    }

                    break;
                // GPU
                case 2:
                    if (powersupply != null)
                    {
                        filtered = filtered.Where(p => p.gpu_.recommendpower == powersupply.power).ToList();
                    }
                    break;
                // RAM
                case 3:
                    if (motherboard != null)
                    {
                        filtered = filtered.Where(p => p.ram_.memorytypeid == motherboard.memorytypeid).ToList();
                    }
                    break;
                // Motherboard
                case 4:
                    // Сокеты процессора и материнской платы
                    if (cpu != null)
                    {
                        filtered = filtered.Where(p => p.motherboard_.socketid == cpu.socketid).ToList();
                    }

                    // Сокеты системы охлаждения и материнской платы
                    if (processorcooler != null)
                    {
                        filtered = filtered.Where(p => p.motherboard_.socket_.socketprocessorcooler_ == processorcooler.socketprocessorcooler_).ToList();
                    }

                    // Форм-факторы корпуса и материнской платы
                    if (casePC != null)
                    {
                        filtered = filtered.Where(p => p.motherboard_.formfactor_.boardformfactorcase_ == casePC.boardformfactorcase_).ToList();
                    }

                    // Тип памяти ОЗУ и материнской платы
                    if (ram != null)
                    {
                        filtered = filtered.Where(p => p.motherboard_.memorytypeid == ram.memorytypeid).ToList();
                    }
                    break;
                // Case
                case 5:
                    if (motherboard != null)
                    {
                        filtered = filtered.Where(f => f.case_.boardformfactorcase_.Contains(b=>b.formfactorid == motherboard.formfactorid)).ToList();
                    }
                    break;
                // Power supply
                case 6:
                    if (gpu != null)
                    {
                        filtered = filtered.Where(p => p.powersupply_.power == gpu.recommendpower).ToList();
                    }
                    break;
                // Processor cooler
                case 7:
                    if (cpu != null)
                    {
                        filtered = filtered.Where(p => p.processorcooler_.socketprocessorcooler_ == cpu.socket_.socketprocessorcooler_).ToList();
                    }
                    break;
                // Storage device
                case 8:
                    break;
                default:
                    break;
            }

            return filtered;
        }
    }
}
