using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr15
{
    public class Assemble
    {
        public bool isCompatible = false;
        public string author = "";
        public string buildName = "";
        public List<basepart_> parts = new List<basepart_>()
        {
            new basepart_(){ name = "Процессор", parttypeid = 1, image = "/Images/cpu.png", price = 0},
            new basepart_(){ name = "Графический процессор", parttypeid = 2, image = "/Images/gpu.png", price = 0},
            new basepart_(){ name = "ОЗУ", parttypeid = 3, image = "/Images/ram.png", price = 0},
            new basepart_(){ name = "Материнская плата", parttypeid = 4, image = "/Images/motherboard.png", price = 0},
            new basepart_(){ name = "Корпус", parttypeid = 5, image = "/Images/computer.png", price = 0},
            new basepart_(){ name = "Блок питания", parttypeid = 6, image = "/Images/power-supply.png", price = 0},
            new basepart_(){ name = "Система охлаждения", parttypeid = 7, image = "/Images/fan.png", price = 0},
            new basepart_(){ name = "Устройство хранения", parttypeid = 8, image = "/Images/hard-disk-drive.png", price = 0},
        };

        public double CalculatePrice()
        {
            double price = 0;
            price += (double)parts.Sum(p => p.price);
            return price;
        }

        public bool IsCompatible(basepart_ basepart)
        {
            List<basepart_> assembleParts = parts;

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
                        isCompatible &= basepart.motherboard_.memorytypeid == ram.memorytypeid;
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

        public void IsCompatible()
        {
            List<basepart_> assembleParts = parts;

            // Получение всех текущих комплектующих сборки
            cpu_ cpu = assembleParts.FirstOrDefault(p => p.parttypeid == 1).cpu_;
            gpu_ gpu = assembleParts.FirstOrDefault(p => p.parttypeid == 2).gpu_;
            ram_ ram = assembleParts.FirstOrDefault(p => p.parttypeid == 3).ram_;
            motherboard_ motherboard = assembleParts.FirstOrDefault(p => p.parttypeid == 4).motherboard_;
            case_ casePC = assembleParts.FirstOrDefault(p => p.parttypeid == 5).case_;
            powersupply_ powersupply = assembleParts.FirstOrDefault(p => p.parttypeid == 6).powersupply_;
            processorcooler_ processorcooler = assembleParts.FirstOrDefault(p => p.parttypeid == 7).processorcooler_;
            storagedevice_ storagedevice = assembleParts.FirstOrDefault(p => p.parttypeid == 8).storagedevice_;

            isCompatible = true;

            if (cpu != null && gpu != null && ram != null && motherboard != null &&
                powersupply != null && storagedevice != null)
            {
                isCompatible &= cpu.socketid == motherboard.socketid;
                isCompatible &= gpu.recommendpower == powersupply.power;
                isCompatible &= ram.memorytypeid == motherboard.memorytypeid;

                if (casePC != null)
                {
                    isCompatible &= motherboard.formfactor_.boardformfactorcase_
                                .Where(ff => ff.caseid == casePC.id).ToList()
                                != new List<boardformfactorcase_>();
                }

                if(processorcooler != null)
                {
                    isCompatible &= cpu.socket_.socketprocessorcooler_
                            .Where(spc => spc.processorcoolerid == processorcooler.id).ToList()
                            != new List<socketprocessorcooler_>();
                    isCompatible &= motherboard.socket_.socketprocessorcooler_
                               .Where(spc => spc.processorcoolerid == processorcooler.id).ToList()
                               != new List<socketprocessorcooler_>();
                }

            }
            else
            {
                isCompatible = false;
            }
        }

    }
}
