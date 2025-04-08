namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            const int N = 5;
            int[] массивдон = new int[N] { 1, 4, 4, 3, 2 };
            Dictionary<int, int> счетчикдон = new Dictionary<int, int>();

            for (int i = 0; i < N; i++)
            {
                if (счетчикдон.ContainsKey(массивдон[i])) счетчикдон[массивдон[i]]++;
                else счетчикдон.Add(массивдон[i], 1);
            }

            Console.Write("Числа, входящие только один раз: ");
            foreach (var числодон in счетчикдон)
            {
                if (числодон.Value == 1) Console.Write($"{числодон.Key} ");
            }
        }
    }
}