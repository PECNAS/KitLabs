namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа принимает на вход натуральное число N\n" +
                "После ввода числа N программа выводит все палиндромы, меньше числа N.\n\n");

            Console.Write("Введите число N: ");
            string N = Console.ReadLine();

            if (Convert.ToInt32(N) < 11) Console.WriteLine($"Палиндромов меньше {N} не найдено");
            else
            {
                for (int i = 11; i <= Convert.ToInt32(N); i++)
                {
                    string num = Convert.ToString(i);
                    var reversed_num = new string(num.Reverse().ToArray());

                    if (reversed_num.Equals(num))
                    {
                        Console.WriteLine($"Число {i} является палиндромом");
                    }
                }
            }

        }
    }
}
