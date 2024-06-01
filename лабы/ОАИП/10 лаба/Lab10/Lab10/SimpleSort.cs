using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    internal class SimpleSort : IStrategy
    {

        private static int comparisons = 0;
        private static int permutations = 0;
        private static string time = "MM:SS.MS";

        public void SortArr(int[] mas, bool flag)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();

            for (int i = 0; i<mas.Length - 1; i++)
            {
        //поиск минимального числа
                int min = i;
                for (int j = i + 1; j<mas.Length; j++)
                {
                    if (Comparisons(mas, j, min, flag))
                    {
                        min = j;
                    }
                }
                //обмен элементов
                Swap(mas, min, i, flag);
            }

            myStopwatch.Stop();
            var resultTime = myStopwatch.Elapsed;
            time = string.Format("{0:00}:{1:00}.{2:000}", resultTime.Minutes, resultTime.Seconds, resultTime.Milliseconds);
            if(flag == false) 
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
            return arr[ind1] < arr[ind2];
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

        public void AnalSortArr(int[] arr, bool flag,AnalInfo sort)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();


            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {   
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                        comparisons++;
                        permutations++;
                    }
                    else
                    {
                        comparisons++;
                    }
                }
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
