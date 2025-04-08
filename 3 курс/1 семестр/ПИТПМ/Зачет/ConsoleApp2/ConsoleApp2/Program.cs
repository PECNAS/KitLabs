using System.Collections.Specialized;
using System.Drawing;
namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> list1 = new List<int> { 1, 2, 3};
            List<int> list2 = new List<int> { 1, 2, 3};

            Console.WriteLine(list1.SequenceEqual(list2));
            //var adder = new Adder();
            //adder.AddObject("Name", 2);
        }
    }

    public class Adder
    {
        public int AddObject(string course_name, int dur)
        {
            using (var context = new CoursesContext())
            {
                var courser = new Course();
                {
                    dur = courser.Duration;
                    course_name = courser.CourseName;
                }
                context.Courses.Add(courser);
                context.SaveChanges();
                return courser.Id;
            }
        }
    }
}