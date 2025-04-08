using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WpfApp1.Base.Entities;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace WpfApp1.Base
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasMany(c => c.Instructors)
                .WithOptional(i => i.Car);

            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.Students)
                .WithOptional(s => s.Instructor);

            base.OnModelCreating(modelBuilder);
        }
    }
}
