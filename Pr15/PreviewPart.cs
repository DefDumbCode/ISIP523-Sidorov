using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr15
{
    public partial class basepart_
    {
        public string preview
        {
            get
            {
                if (id == 0)
                {
                    return $"{name}";
                }
                else {
                    switch (parttypeid)
                    {
                        case 1:
                            return $"{name} {cpu_.socket_.name} " +
                                $"{cpu_.numberofcores}яд." +
                                $"{cpu_.basecorefrequency}ГГц-" +
                                $"{cpu_.maxcorefrequency}ГГц" +
                                $"L3:{cpu_.cachel3}" +
                                $"IGPU:{cpu_.hasigpu} {cpu_.igpu_.name}" +
                                $"Thermal power: {cpu_.thermalpower}" +
                                $"Производитель: {manufacturer_.name}" +
                                $"Цена: {price}";
                        case 2:
                            return $"{name}" +
                                $"{gpu_.gpuinterface_.name}" +
                                $"{gpu_.chipfrequency}" +
                                $"{gpu_.videomemory}" +
                                $"{gpu_.memorybus}" +
                                $"{gpu_.recommendpower}" +
                                $"Производитель: {manufacturer_.name}" +
                                $"Цена: {price}";
                        case 3:
                            return $"{name} {ram_.memorytype_.name}" +
                                $"{ram_.capacity}Гб" +
                                $"{ram_.count}" +
                                $"{ram_.ghz}" +
                                $"{ram_.timings}" +
                                $"Производитель: {manufacturer_.name}" +
                                $"Цена: {price}";
                        case 4:
                            return $"{name} Сокет:{motherboard_.socket_.name}" +
                                $"Форм-фактор: {motherboard_.formfactor_.name}" +
                                $"Слотов памяти: {motherboard_.memoryslots}" +
                                $"Тип памяти: {motherboard_.memorytype_.name}" +
                                $"Слотов psi: {motherboard_.pcislots}" +
                                $"Сата-порты: {motherboard_.sataports}" +
                                $"USB-порты: {motherboard_.usbports}" +
                                $"Производитель: {manufacturer_.name}" +
                                $"Цена: {price}";
                        case 5:
                            return $"{name} Размер: {case_.casesize_.name}" +
                                $"Слотов расширения: {case_.expansionslots}" +
                                $"Вентиляторы:{case_.fans}" +
                                $"Производитель: {manufacturer_.name}" +
                                $"Цена: {price}";
                        case 6:
                            return $"{name} {powersupply_.certificate_.name}" +
                                $"{powersupply_.power}" +
                                $"Размеры:{powersupply_.fandimension_.name}" +
                                $"Производитель: {manufacturer_.name}" +
                                $"Цена: {price}";
                        case 7:
                            return $"{name} Размеры:{processorcooler_.fandimension_.name}" +
                                $"Тепловые трубки: {processorcooler_.heatpipes}" +
                                $"Мин. скорость: {processorcooler_.minspeed}" +
                                $"Макс. скорость: {processorcooler_.maxspeed}" +
                                $"Уровень шума: {processorcooler_.noiselevel}" +
                                $"Производитель: {manufacturer_.name}" +
                                $"Цена: {price}";
                        case 8:
                            switch (storagedevice_.storagedevicetype_.name)
                            {
                                case "HDD":
                                    return $"{name} {storagedevice_.storagedevicetype_.name}" +
                                        $"Скорость оборотов: {storagedevice_.hdd_.rotationspeed}" +
                                        $"Вместимость:{storagedevice_.capacity}" +
                                        $"Производитель: {manufacturer_.name}" +
                                        $"Цена: {price}";
                                case "SSD":
                                    return $"{name} {storagedevice_.storagedevicetype_.name}" +
                                        $"TBW: {storagedevice_.ssd_.tbw}" +
                                        $"Вместимость:{storagedevice_.capacity}" +
                                        $"Производитель: {manufacturer_.name}" +
                                        $"Цена: {price}";
                                default:
                                    return "Пусто";

                            }
                        default:
                            return $"Выберите деталь";
                    };
                }

            }
        }
    };
}

