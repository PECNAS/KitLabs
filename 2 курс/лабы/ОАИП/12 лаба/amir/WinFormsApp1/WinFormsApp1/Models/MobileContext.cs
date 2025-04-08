using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Models
{
    public class MobileContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Notion> Notions { get; set; }

        public MobileContext() : base() { }
    }
}
