using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class CoursesContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Duration { get; set; }
    }
}
