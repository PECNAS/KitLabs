namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            const int N = 5;
            int[] array = new int[N] { 1, 4, 4, 3, 2 };
            Dictionary<int, int> counter = new Dictionary<int, int>();

            for (int i = 0; i < N; i++)
            {
                if (counter.ContainsKey(array[i])) counter[array[i]]++;
                else counter.Add(array[i], 1);
            }

            foreach (var nbr in counter)
            {
                Console.WriteLine($"Число вхождения числа {nbr.Key} в массив = {nbr.Value}");
            }
        }
    }
}