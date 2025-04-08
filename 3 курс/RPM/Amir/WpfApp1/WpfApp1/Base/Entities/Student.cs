using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Base.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public virtual Instructor Instructor { get; set; } = null;
        public string Category { get; set; } // категория, на которую учится человек
    }
}
