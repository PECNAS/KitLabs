using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab10
{
    internal class ImprovedSort: IStrategy
    {
        private static int comparisons = 0;
        private static int permutations = 0;
        private static string time = "MM:SS.MS";
        private static int range = 10;
        private static int length = 2;


        public void SortArr(int[] arr, bool flag)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();

            ArrayList[] lists = new ArrayList[range];
            for(int i = 0; i<range; ++i)
                lists[i] = new ArrayList();

            for(int step = 0; step<length; ++step) {
                //распределение по спискам
                for(int i = 0; i<arr.Length; ++i) {
                    int rank = (arr[i] % (int)Math.Pow(range, step + 1)) / (int)Math.Pow(range, step);
                    AddInRank(lists, rank, arr, i, flag);
                }

                //сборка
                int k = 0;
                for(int i = 0; i<range; ++i) {
                    for(int j = 0; j<lists[i].Count; ++j) {
                        AddInArray(arr, k, lists, i, j, flag);
                        k++;
                    }
                }

                for (int i = 0; i < range; ++i)
                   lists[i].Clear();
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

        private void AddInRank(ArrayList[] lists, int rank, int[] arr, int ind1, bool flag)
        {
            comparisons++;

            if (flag && FileOut.fileString == null)
            {
                FileOut.fileString = "Исходный массив: ";
                FileOut.Fill();
            }

            if (flag)
            { 
                FileOut.fileString += $"Элемент [{arr[ind1]}] помещен в разряд {rank}\n";
                FileOut.Fill();
            }
            lists[rank].Add(arr[ind1]);

        }

        private void AddInArray(int[] arr, int k, ArrayList[] lists, int i, int j, bool flag)
        {
            permutations++;

            arr[k] = (int)lists[i][j];
            if (flag) FileOut.fileString += $"Вставка элемента [{(int)(lists[i][j])}] под индекс {k}\n";

            string swapString = "";

            for (int el = 0; el < arr.Length; el++) {
                if (el == k) swapString += $"[{arr[el]}] ";
                else swapString += $"{arr[el]} ";
            }

            Form1.AddSortLine(swapString);
            FileOut.Fill();
        }
        public void AnalSortArr(int[] arr, bool flag,AnalInfo sort)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();

            var d = arr.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < arr.Length; i++)
                {
                    var j = i;
                    while ((j >= d) && Comparisons(arr,j-d,j))
                    {
                        int temp = arr[j];
                        arr[j] = arr[j-d];
                        arr[j-d] = temp;
                        j = j - d;
                        permutations++;
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

        private bool Comparisons(int[] arr, int ind1, int ind2)
        {
            comparisons++;
            return arr[ind1] > arr[ind2];
        }
    }

}

