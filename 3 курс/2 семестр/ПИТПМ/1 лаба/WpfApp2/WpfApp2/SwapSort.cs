using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class SwapSort
    {
        public List<int> sort(List<int> mas)
        {
            int temp;
            for (int i = 0; i < mas.Count; i++)
            {
                for (int j = i + 1; j < mas.Count; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
    }
}
