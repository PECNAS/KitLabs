using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
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

      public void SortArr(AnalInfo sort, bool flag) 
        {
            strategy.AnalSortArr(array, flag, sort);
        }

    }
}
