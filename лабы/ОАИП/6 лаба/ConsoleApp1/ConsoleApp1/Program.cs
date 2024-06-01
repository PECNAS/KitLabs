using program;
using System;
using System.Reflection;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            Accaunt acc = new Accaunt();
            acc.set_owner();
            Console.Write("Сейчас на вашем счете: ");
            Console.WriteLine(acc.get_summ());

            acc.take_summ();
            Console.Write("Сейчас на вашем счете: ");
            Console.WriteLine(acc.get_summ());

            acc.put_summ();
            Console.Write("Сейчас на вашем счете: ");
            Console.WriteLine(acc.get_summ());

            acc.add_interest();
            Console.Write("Сейчас на вашем счете: ");
            Console.WriteLine(acc.get_summ());

            Console.WriteLine($"Ваш счет в долларах: {acc.to_dollars()}");

            Console.WriteLine($"Ваш счет в евро: {acc.to_euros()}");
        }
    }

    class Accaunt
    {
        private string owner;
        private double summ;
        private long acc_num;
        private float percent;

        private void generator()
        {
            var rand = new Random();
            this.summ = rand.Next(5000, 1000000);
            this.acc_num = Convert.ToInt64($"408178109991{rand.Next(1000000, 9999999)}");
            this.percent = 11;
        }
        public void set_owner()
        {
            Console.Write("Введите фамилию владельца счёта: ");
            this.owner = Console.ReadLine();

            this.generator();

            Console.WriteLine($"Настоящий владелец счёта: {this.owner}");
        }

        public void take_summ()
        {
            Console.Write("Введите сумму, которую вы хотите снять со своего счета: ");
            double delta = Convert.ToInt32(Console.ReadLine());

            if (delta <= this.summ)
            {
                this.summ -= delta;
            } else if (delta >= this.summ) {
                Console.WriteLine("На вашем счете недостаточно средств, чтобы снять такую сумму.");
            } else if (delta < 0) {
                Console.WriteLine("Введенная сумма должна быть положительной");
            }
        }

        public void put_summ()
        {
            Console.Write("Введите сумму, которая хотите добавить к своему счету: ");
            double delta = Convert.ToInt32(Console.ReadLine());

            if (delta >= 0)
            {
                this.summ += delta;
            } else
            {
                Console.WriteLine("Ошибка. Сумма должна быть положительной");
            }
        }

        public void add_interest()
        {
            this.summ += (this.summ / 100) * (this.percent / 12);
            Console.WriteLine("На ваш счет начислены проценты!");
        }

        public double get_summ()
        {
            return this.summ;
        }

        public double to_dollars()
        {
            return this.summ / 92;
        }

        public double to_euros()
        {
            return this.summ / 99;
        }
    }
}