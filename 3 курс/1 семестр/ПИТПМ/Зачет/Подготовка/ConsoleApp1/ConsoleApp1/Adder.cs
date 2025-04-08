using ConsoleApp1.Base.Entities;
using ConsoleApp1.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Adder
    {
        public int AddObject(string product_name, int price)
        {
            Product product;
            using (var context = new TestContext())
            {
                product = new Product()
                {
                    ProductName = product_name,
                    Price = price
                };
                context.Products.Add(product);
                context.SaveChanges();
            }
            return product.Id;
        }
    }
}
