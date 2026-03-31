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
            CPULB.ItemsSource = partsList.Where(p => p.parttypeid == part.id).ToList();
            
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

        public bool IsCompatible(basepart_ basepart)
        {
            List<basepart_> assembleParts = MainWindow.assemble.parts;

            // Получение всех текущих комплектующих сборки
            cpu_ cpu = assembleParts.FirstOrDefault(p => p.parttypeid == 1).cpu_;
            gpu_ gpu = assembleParts.FirstOrDefault(p => p.parttypeid == 2).gpu_;
            ram_ ram = assembleParts.FirstOrDefault(p => p.parttypeid == 3).ram_;
            motherboard_ motherboard = assembleParts.FirstOrDefault(p => p.parttypeid == 4).motherboard_;
            case_ casePC = assembleParts.FirstOrDefault(p => p.parttypeid == 5).case_;
            powersupply_ powersupply = assembleParts.FirstOrDefault(p => p.parttypeid == 6).powersupply_;
            processorcooler_ processorcooler = assembleParts.FirstOrDefault(p => p.parttypeid == 7).processorcooler_;
            storagedevice_ storagedevice = assembleParts.FirstOrDefault(p => p.parttypeid == 8).storagedevice_;

            bool isCompatible = true;

            switch (basepart.parttypeid)
            {
                // CPU
                case 1:
                    // Фильтрация по сокету процессора и материнской платы
                    if (motherboard != null)
                    {
                        isCompatible &= basepart.cpu_.socketid == motherboard.socketid;
                    }

                    // Фильтрация по сокету кулера
                    if (processorcooler != null)
                    {
                        isCompatible &= basepart.cpu_.socket_.socketprocessorcooler_
                            .Where(spc => spc.processorcoolerid == processorcooler.id).ToList()
                            != new List<socketprocessorcooler_>();
                    }

                    break;
                // GPU
                case 2:
                    if (powersupply != null)
                    {
                        isCompatible &= basepart.gpu_.recommendpower == powersupply.power;
                    }
                    break;
                // RAM
                case 3:
                    if (motherboard != null)
                    {
                        isCompatible &= basepart.ram_.memorytypeid == motherboard.memorytypeid;
                    }
                    break;
                // Motherboard
                case 4:
                    // Сокеты процессора и материнской платы
                    if (cpu != null)
                    {
                        isCompatible &= basepart.motherboard_.socketid == cpu.socketid;
                    }

                    // Сокеты системы охлаждения и материнской платы
                    if (processorcooler != null)
                    {
                        isCompatible &= basepart.motherboard_.socket_.socketprocessorcooler_
                            .Where(spc => spc.processorcoolerid == processorcooler.id).ToList()
                            != new List<socketprocessorcooler_>();
                    }

                    // Форм-факторы корпуса и материнской платы
                    if (casePC != null)
                    {
                        isCompatible &= basepart.motherboard_.formfactor_.boardformfactorcase_
                            .Where(ff => ff.caseid == casePC.id).ToList()
                            != new List<boardformfactorcase_>();
                    }

                    // Тип памяти ОЗУ и материнской платы
                    if (ram != null)
                    {
                        isCompatible &= basepart.ram_.memorytypeid == motherboard.memorytypeid;
                    }
                    break;
                // Case
                case 5:
                    if (motherboard != null)
                    {
                        isCompatible &= basepart.case_.boardformfactorcase_
                            .Where(ff => ff.formfactorid == motherboard.formfactorid).ToList()
                            != new List<boardformfactorcase_>();
                    }
                    break;
                // Power supply
                case 6:
                    if (gpu != null)
                    {
                        isCompatible &= basepart.powersupply_.power == gpu.recommendpower;
                    }
                    break;
                // Processor cooler
                case 7:
                    if (cpu != null)
                    {
                        isCompatible &= basepart.processorcooler_.socketprocessorcooler_
                            .Where(spc => spc.socketid == cpu.socketid).ToList()
                            != new List<socketprocessorcooler_>();
                    }

                    if (motherboard != null)
                    {
                        isCompatible &= basepart.processorcooler_.socketprocessorcooler_
                            .Where(spc => spc.socketid == motherboard.socketid).ToList()
                            != new List<socketprocessorcooler_>();
                    }
                    break;
                // Storage device
                case 8:
                    break;
                default:
                    break;
            }
            return isCompatible;
        }
    }
}
