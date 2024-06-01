using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{
    internal class ImprovedSort: IStrategy
    {
        private static int comparisons = 0;
        private static int permutations = 0;
        private static string time = "MM:SS.MS";
        private static int range = 10;
        private static int length = 2;


        public void SortArr(int[] mas, bool flag)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();

            //расстояние между элементами, которые сравниваются
            var d = mas.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < mas.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (Comparisons(mas, j - d, j, flag)))
                    {
                        Swap(mas, j, j - d, flag);
                        j = j - d;
                    }
                }
                d = d / 2;
            }

            myStopwatch.Stop();
            var resultTime = myStopwatch.Elapsed;
            time = string.Format("{0:00}:{1:00}.{2:000}", resultTime.Minutes, resultTime.Seconds, resultTime.Milliseconds);
            if (flag == false)
            {
                FileOut.fileString = null;
            }
            Form1.ReadInfo(comparisons, permutations, time);
            comparisons = 0;
            permutations = 0;
        }

        private bool Comparisons(int[] arr, int ind1, int ind2, bool flag)
        {
            comparisons++;

            if (flag && FileOut.fileString == null)
            {
                FileOut.fileString = "Исходный массив: ";
                FileOut.Fill();
            }

            if (flag)
                FileOut.fileString += $"Сравнение {comparisons}: " + $"{arr[ind1]} и {arr[ind2]}\n";
            return arr[ind1] > arr[ind2];
        }
        private void Swap(int[] arr, int ind1, int ind2, bool flag)
        {
            permutations++;

            if (flag)
                FileOut.fileString += $"Перемещение {permutations}: " + $"[{ind1 + 1}] - {arr[ind1]} и [{ind2 + 1}] - {arr[ind2]}\n";

            string swapString = "";
            for (int i = 0; i < arr.Length; i++)
                if (i == ind1 || i == ind2)
                    swapString += $"[{arr[i]}] ";
                else
                    swapString += arr[i] + " ";
            Form1.AddSortLine(swapString);

            int temp = arr[ind1];
            arr[ind1] = arr[ind2];
            arr[ind2] = temp;

            FileOut.Fill();

        }

        public void AnalSortArr(int[] arr, AnalInfo sort)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();


            //расстояние между элементами, которые сравниваются
            var d = arr.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < arr.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && (arr[j - d] > arr[j]))
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - d];
                        arr[j - d] = temp;

                        comparisons++;
                        permutations++;

                        j = j - d;
                    }
                }
                d = d / 2;
            }

            myStopwatch.Stop();
            var resultTime = myStopwatch.Elapsed;
            sort.time = string.Format("{0:00}:{1:00}.{2:000}", resultTime.Minutes, resultTime.Seconds, resultTime.Milliseconds);

            sort.comparisons = comparisons;
            sort.permutations = permutations;
            comparisons = 0;
            permutations = 0;
            Form1.line = "";
        }
    }
}

