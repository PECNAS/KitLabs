namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Название книги: ");
            string title = Console.ReadLine();
            Console.WriteLine("Автор книги: ");
            string author = Console.ReadLine();

            var adder = new Adder();
            Console.WriteLine($"Id новой книги: {adder.AddObject(title, author)}");
        }
    }

    public class Adder
    {
        public Book AddObject(string title, string author)
        {
            Book book;

            using (var context = new BooksContext())
            {
                book = new Book()
                {
                    Author = author,
                    Title = title,
                };
                context.Books.Add(book);
                context.SaveChanges();
            }
            return book;
        }
    }
}