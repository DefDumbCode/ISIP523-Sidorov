using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isip_523_Sidorov
{
    internal class Car
    {
        public List<Details> Broken_details { get; private set; }

        public Car()
        {
            Broken_details = new List<Details>();
        }

        public void NewCar(List<Details> details)
        {
            Random rand = new Random();
            for (int i = 0; i < rand.Next(1, details.Count); i++)
            {
                int random_num = rand.Next(0, details.Count);
                if (Broken_details.Contains(details[random_num]) == false)
                {
                    Broken_details.Add(details[random_num]);
                }
            }
        }
    }
}
