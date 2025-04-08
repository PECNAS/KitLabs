using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    class Context
    {
        public static int[] array;
        public IStrategy strategy;
        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SortArr(bool flag)
        {
            strategy.SortArr(array, flag);
        }

        public void SortArr(AnalInfo sort) 
          {
              strategy.AnalSortArr(array, sort);
          }

    }
}
