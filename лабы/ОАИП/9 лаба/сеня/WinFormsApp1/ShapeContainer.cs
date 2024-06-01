using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public static class ShapeContainer
    {
        public static List<Figure> figureList;
        public static int length;
        static ShapeContainer()
        {
            figureList = new List<Figure>();
            length = 0;
        }
        public static void AddFigure(Figure figure)
        {
            figureList.Add(figure);
            length += 1;
        }

        public static void RemoveFigure(Figure figure)
        {
            figureList.Remove(figure);
            length -= 1;
        }

    }
}
