using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Comparators;
using Logic;
using Storages;

namespace ConsoleUI
{
    class Program
    {
        public static void ShowList(List<Book> books)
        {
            foreach (Book b in books)
            {
                Console.WriteLine(b + "\n");
            }
        }

        static void Main(string[] args)
        {
            var bookService = new BookListService();

            bookService.AddBook(new Book("Programminng by C#", "Ian Griffiths", "Science fiction", 2012, 1064));
            bookService.AddBook(new Book("C# 6.0", "J. Albahari & B. Albahari", "Science fiction", 2016, 1040));
            bookService.AddBook(new Book("CLR via C#", "J. Richter", "Science fiction", 2006, 986));
            bookService.AddBook(new Book("Demons", "Dostoevsky F.", "Philosophical fiction", 1872, 1000));

            Book book1 = bookService.FindBookByTag(b => b.Year == 2016);
            Console.WriteLine(book1);

            ShowList(bookService.GetBooks());
            bookService.RemoveBook(book1);

            Console.WriteLine("==============\nAfter book removing:");
            ShowList(bookService.GetBooks());

            Book book2 = bookService.FindBookByTag(b => b.Year == 2016);
            if (book2 == null)
                Console.WriteLine("\nThe book was not founded.");

            bookService.SortBooksByTag(new ComparatorByAuthor());
            Console.WriteLine("==============\nAfter sorting by author:");
            ShowList(bookService.GetBooks());

            var storage = new BinaryStorage("BinaryStorageFile");
            bookService.Save(storage);

            var bookService2 = new BookListService();
            bookService2.Load(storage);

            Console.WriteLine("==============\nAfter loading:");
            ShowList(bookService2.GetBooks());

            try
            {
                //bookService.AddBook(new Book("C# 6.0", "J. Albahari & B. Albahari", "Science fiction", 2016, 1040));
                //bookService.AddBook(null);
                // bookService.Load();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
