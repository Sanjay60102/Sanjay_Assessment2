using System.Diagnostics;
using System.Net;

namespace Assessment2
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

        public Book(int bookId, string bookName, double price, string author, string publisher)
        {
            BookId = bookId;
            BookName = bookName;
            Price = price;
            Author = author;
            Publisher = publisher;
        }

        public override string ToString()
        {
            return $"ID: {BookId}, Name: {BookName}, Price: {Price}, Author: {Author}, Publisher: {Publisher}";
        }
    }
    public class library
    {
        public List<Book> books;

        public library()
        {
            books = new List<Book>
            {
                new Book(101, "Mathematics", 450, "Ronaldo", "Padhma Publications"),
                new Book(102, "Physics", 590, "Messi", "Moksha Publications"),
                new Book(103, "Chemistry", 149, "Virat", "Keerthi"),
                new Book(104, "English", 399, "Giri", "Raju Publications"),
                new Book(105, "Telugu", 270, "Siri", "Siri Publications"),
                new Book(106, "Social", 600, "Suresh", "Saritha Publications")
            };
        }
        public void CreateBook(int bookId, string bookName, double price, string author, string publisher)
        {
            books.Add(new Book(bookId, bookName, price, author, publisher));
            Console.WriteLine("Book data Created!");
        }
        public void UpdateBook(int bookId,  double? price = null, string author = null, string publisher = null)
        {
            var book = books.First(b => b.BookId == bookId);
            if (book != null)
            {
                if (price.HasValue)
                {
                    book.Price = price.Value;
                }
                if (author != null)
                {
                    book.Author = author;
                }
                if (publisher != null)
                {
                    book.Publisher = publisher;
                }
                Console.WriteLine("Book details Updated");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }
        public void DisplayBookById(int bookId)
        {
            var book = books.First(b => b.BookId == bookId);
            
            if (book != null)
            {
                Console.WriteLine(book);
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }
        public void DisplayBookByName(string bookName)
        {
            var book = books.First(b => b.BookName.Equals(bookName, StringComparison.OrdinalIgnoreCase));
            if (book != null)
            {
                Console.WriteLine(book);
            }
            else
            {
                Console.WriteLine("Book not found");
            }
        }
        public void DisplayBooksByAuthor(string author)
        {
            var Books = books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase)).ToList();
            if (Books.Any())
            {
                Books.ForEach(book => Console.WriteLine(book));
            }
            else
            {
                Console.WriteLine("No books found for this author");
            }
        }
        public void DisplayBooksByAuthorAndPublisher(string author, string publisher)
        {
            var Books = books.Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase) && b.Publisher.Equals(publisher, StringComparison.OrdinalIgnoreCase)).ToList();
            if (Books.Any())
            {
                Books.ForEach(book => Console.WriteLine(book));
            }
            else
            {
                Console.WriteLine("No books found for this author and publisher");
            }
        }
        public void DisplayAllBooks()
        {
            if (books.Any())
            {
                books.ForEach(book => Console.WriteLine(book));
            }
            else
            {
                Console.WriteLine("No books available");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            library library = new library();
            do
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Create Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Display Book By ID");
                Console.WriteLine("4. Display Book By Name");
                Console.WriteLine("5. Display Books By Author");
                Console.WriteLine("6. Display Books By Author and Publisher");
                Console.WriteLine("7. Display All Books");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        {
                            Console.Write("Enter Book ID: ");
                            int bookId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Book Name: ");
                            string bookName = Console.ReadLine();
                            Console.Write("Enter Book Price: ");
                            double price = double.Parse(Console.ReadLine());
                            Console.Write("Enter Author: ");
                            string author = Console.ReadLine();
                            Console.Write("Enter Publisher: ");
                            string publisher = Console.ReadLine();
                            library.CreateBook(bookId, bookName, price, author, publisher);
                        }
                        break;
                    case 2:
                        {
                            Console.Write("Enter Book ID: ");
                            int bookId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Book Price: ");
                            double price = double.Parse(Console.ReadLine());
                            Console.Write("Enter Author: ");
                            string author = Console.ReadLine();
                            Console.Write("Enter Publisher: ");
                            string publisher = Console.ReadLine();
                            library.UpdateBook(bookId, price, author, publisher);
                        }
                        break;
                    case 3:
                        {
                            Console.Write("Enter Book Id: ");
                            int bookId = int.Parse(Console.ReadLine());
                            library.DisplayBookById(bookId);
                        }
                        break;
                    case 4:
                        {
                            Console.Write("Enter Book Name: ");
                            string bookName = Console.ReadLine();
                            library.DisplayBookByName(bookName);
                        }
                        break;
                    case 5:
                        {
                            Console.Write("Enter Author: ");
                            string author = Console.ReadLine();
                            library.DisplayBooksByAuthor(author);
                        }
                        break;
                    case 6:
                        {
                            Console.Write("Enter Author: ");
                            string author = Console.ReadLine();
                            Console.Write("Enter Publisher: ");
                            string publisher = Console.ReadLine();
                            library.DisplayBooksByAuthorAndPublisher(author, publisher);
                        }
                        break;
                    case 7:
                        {
                            library.DisplayAllBooks();
                        }
                        break;
                    case 8:
                        {
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

            }
            while (true);
        }
    }
}
