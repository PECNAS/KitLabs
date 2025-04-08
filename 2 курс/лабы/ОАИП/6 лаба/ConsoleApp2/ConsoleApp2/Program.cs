using program;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            Money bankomat = new Money();
            bool res = false;

            do
            {
                res = bankomat.set_first();
            }
            while (res == false);

            bankomat.set_second();
            bankomat.summa();

        }
    }

    class Money
    {
        private int first;
        private int second;
        private int[] nominals = { 1, 2, 5, 10, 50, 100, 500, 1000, 5000 };

        public bool set_first()
        {
            Console.Write("Введите номинал купюры: ");
            first = Convert.ToInt32(Console.ReadLine());

            foreach (int i in this.nominals)
            {
                if (first == i)
                {
                    this.first = first;

                    return true;
                }
            }
            Console.Write("Вы ввели неподдерживаемый номинал. Поддерживаемые номиналы: \n");
            foreach (int i in this.nominals)
            {
                Console.Write(i);
                Console.Write(", ");
            }
            Console.WriteLine();

            return false;
            
        }

        public void set_second()
        {
            Console.Write($"Введите количество купюр номиналом {this.first}: ");
            this.second = Convert.ToInt32(Console.ReadLine());
        }

        public void summa()
        {
            Console.WriteLine($"Общая сумма: {this.first * this.second}");
        }
    }
}