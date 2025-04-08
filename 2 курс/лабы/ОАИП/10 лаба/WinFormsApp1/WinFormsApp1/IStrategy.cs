using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    interface IStrategy
    {
        void SortArr(int[] arr, bool flag);
        void AnalSortArr(int[] arr, AnalInfo sort);
    }
}
