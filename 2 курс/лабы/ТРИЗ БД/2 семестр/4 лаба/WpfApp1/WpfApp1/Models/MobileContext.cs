using System.Data.Entity;

namespace WpfApp1.Models
{
    public class MobileContext: DbContext
    {
        public MobileContext() : base() { }
        public DbSet<App> Apps { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Executor> Executors { get; set; }
        public DbSet<History> Histories { get; set; }

        
    }
}
