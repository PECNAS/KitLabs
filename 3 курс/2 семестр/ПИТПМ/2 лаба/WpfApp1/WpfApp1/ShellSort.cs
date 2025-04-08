using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ShellSort
    {
        public List<int> sort(List<int> mas)
        {
            int n = mas.Count();
            int i, j, step;
            int tmp;
            for (step = n / 2; step > 0; step /= 2)
                for (i = step; i < n; i++)
                {
                    tmp = mas[i];
                    for (j = i; j >= step; j -= step)
                    {
                        if (tmp < mas[j - step])
                            mas[j] = mas[j - step];
                        else
                            break;
                    }
                    mas[j] = tmp;
                }
            return mas;
        }
    }
}
