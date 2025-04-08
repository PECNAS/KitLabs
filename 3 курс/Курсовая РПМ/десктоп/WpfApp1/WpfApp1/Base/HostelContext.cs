using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Base.Entities;

namespace WpfApp1.Base
{
    public class HostelContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reserve> Reserves { get; set; }

        public HostelContext() : base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasOptional(r => r.Reserve)
                .WithOptionalDependent(res => res.Room);

            modelBuilder.Entity<Visitor>()
                .HasMany(v => v.Reserves)
                .WithOptional(r => r.Visitor);
                

            base.OnModelCreating(modelBuilder);
        }
    }
}
