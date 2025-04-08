using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WpfApp1.Base.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; } // 1 = админ, 0 = пользователь
        public string Category { get; set; } // Категория прав, на которую учит
        public virtual Car Car { get; set; } = null;
        public virtual ICollection<Student> Students { get; set; }

        public Instructor()
        {
            Students = new List<Student>();
        }
    }
}
