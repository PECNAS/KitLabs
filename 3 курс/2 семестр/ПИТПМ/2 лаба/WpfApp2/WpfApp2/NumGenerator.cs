using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class NumGenerator
    {
        public static List<int> Generate(int size)
        {
            List<int> mas = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                mas.Add(rand.Next());
            }

            return mas;
        }
    }
}
