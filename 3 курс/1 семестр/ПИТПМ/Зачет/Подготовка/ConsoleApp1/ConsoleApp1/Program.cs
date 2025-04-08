using ConsoleApp1.Base;
using ConsoleApp1.Base.Entities;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Название продукта: ");
            string product_name = Console.ReadLine();
            Console.Write("Цена: ");
            int price;
            while (!int.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Ошибка! Попробуйте еще раз");
                Console.Write("Цена: ");
            }

            var adder = new Adder();
            adder.AddObject(product_name, price);

            using (var context = new TestContext())
            {
                foreach (var product in context.Products.ToList())
                {
                    Console.WriteLine($"{product.ProductName}, {product.Price} рублей");
                }
            }
        }

    }
}