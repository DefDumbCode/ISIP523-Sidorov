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
            new basepart_(){ name = "Процессор", parttypeid = 1},
            new basepart_(){ name = "Графический процессор", parttypeid = 2},
            new basepart_(){ name = "ОЗУ", parttypeid = 3},
            new basepart_(){ name = "Материнская плата", parttypeid = 4},
            new basepart_(){ name = "Корпус", parttypeid = 5},
            new basepart_(){ name = "Блок питания", parttypeid = 6},
            new basepart_(){ name = "Кулер процессора", parttypeid = 7},
            new basepart_(){ name = "ПЗУ", parttypeid = 8},
        };
    }
}
