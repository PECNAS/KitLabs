using System;

namespace Laba4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа находит максимальное число в матрице, после чего получает новую матрицу\n" +
                "путём деления всех элементов матрицы на это максимальное число.");

            Console.Write("Введите n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите m: ");
            int m = Convert.ToInt32(Console.ReadLine());

            double[,] matrix = new double[n, m];

            Console.WriteLine("\nИсходная матрица: ");
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = (col  + 1) * (row + 1);
                    Console.Write((col + 1) * (row + 1));
                    Console.Write("\t ");
                }
                Console.WriteLine();
            }

            double max_n = matrix[0, 0];

            for (int row = 0; row < matrix.GetUpperBound(0) + 1; row ++)
            {
                for (int col = 0; col < matrix.GetUpperBound(1) + 1; col++)
                {
                    if (matrix[row, col] > max_n) max_n = matrix[row, col];
                }
            }

            Console.Write("\nНаибольшее число в матрице: ");
            Console.WriteLine(max_n);

            Console.Write("\nНовая матрица, в которой все элементы поделены на ");
            Console.Write(max_n);
            Console.WriteLine(", выглядит так: ");

            for (int row = 0; row < matrix.GetUpperBound(0) + 1; row++)
            {
                for (int col = 0; col < matrix.GetUpperBound(1) + 1; col++)
                {
                    matrix[row, col] /= max_n;
                }
            }

            for (int row = 0; row < matrix.GetUpperBound(0) + 1; row ++)
            {
                for (int col = 0; col < matrix.GetUpperBound(1) + 1; col++)
                {
                    Console.Write(matrix[row, col]);
                    Console.Write("\t ");
                }
                Console.WriteLine();
            }

        }
    }
}