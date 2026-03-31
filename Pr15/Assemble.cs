using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr15
{
    public class Assemble
    {
        public List<basepart_> parts = new List<basepart_>() 
        {
            new basepart_(){ name = "Процессор", parttypeid = 1, image = "/Images/cpu.png"},
            new basepart_(){ name = "Графический процессор", parttypeid = 2, image = "/Images/gpu.png"},
            new basepart_(){ name = "ОЗУ", parttypeid = 3, image = "/Images/ram.png"},
            new basepart_(){ name = "Материнская плата", parttypeid = 4, image = "/Images/motherboard.png"},
            new basepart_(){ name = "Корпус", parttypeid = 5, image = "/Images/computer.png"},
            new basepart_(){ name = "Блок питания", parttypeid = 6, image = "/Images/power-supply.png"},
            new basepart_(){ name = "Система охлаждения", parttypeid = 7, image = "/Images/fan.png"},
            new basepart_(){ name = "Устройство хранения", parttypeid = 8, image = "/Images/hard-disk-drive.png"},
        };
    }
}
