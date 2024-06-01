namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа позволяет узнать результат выполнения выражения\n" +
                "1 / (1 + 1 / (3 + 1 / (... 101 + 1 / 103)))");
            double sum = 103;

            for (int i = 103; i > 1; i = i - 2)
            {
                sum = i - 2 + (1 / sum);

            }

            Console.Write("Результат выполнения выражения: ");
            Console.WriteLine(1 / sum);

        }
    }
}