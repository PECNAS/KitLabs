using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        public Context(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
