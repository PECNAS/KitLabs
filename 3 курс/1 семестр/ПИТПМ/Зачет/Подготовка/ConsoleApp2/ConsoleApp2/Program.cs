using ConsoleApp2;

namespace ConsoleApp2
{
    class Program
    {
        public static void Main(string[] args)
        {
            var adder = new Adder();
            int prod_id = adder.AddObject("Яблоко", 100);
            Console.WriteLine(prod_id);
        }
    }

    public class Adder
    {
        public int AddObject(string product_name, int price)
        {
            using (var context = new ProductContext())
            {
                var product = new Product()
                {
                    ProductName = product_name,
                    Price = price
                };
                context.Products.Add(product);
                context.SaveChanges();

                return product.Id;
            }
        }
    }
}