using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Base.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }

        public Car()
        {
            Instructors = new List<Instructor>();
        }
    }
}
