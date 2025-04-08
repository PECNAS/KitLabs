using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Base.Entities;



namespace WpfApp1.Base
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base() { }

        public DbSet<Item> Items { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
