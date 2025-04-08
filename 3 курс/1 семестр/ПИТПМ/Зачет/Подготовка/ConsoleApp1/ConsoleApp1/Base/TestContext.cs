using ConsoleApp1.Base.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Base
{
    public class TestContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public TestContext() : base()
        {

        }
    }
}
