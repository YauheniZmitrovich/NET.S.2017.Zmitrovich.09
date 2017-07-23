using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Comparators;
using Logging;
using Logic;
using Logic.CustomExceptions;
using Storages;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = NLogger.Instance;
            logger.Trace("trace message");

            try
            {
                #region Book service creating and intializing

                logger.Debug("Creating book service object");
                var bookService = new BookListService();

                logger.Debug("Adding books in the book service");
                bookService.AddBook(new Book("Programminng by C#", "Ian Griffiths", "Science fiction", 2012, 1064));
                bookService.AddBook(new Book("C# 6.0", "J. Albahari & B. Albahari", "Science fiction", 2016, 1040));
                bookService.AddBook(new Book("CLR via C#", "J. Richter", "Science fiction", 2006, 986));
                bookService.AddBook(new Book("Demons", "Dostoevsky F.", "Philosophical fiction", 1872, 1000));

                #endregion


                #region Books service's main methods testing

                logger.Debug("Trying to search the book by tag.");
                Book book1 = bookService.FindBookByTag(b => b.Year == 2016);
                Console.WriteLine(book1);
                logger.Info("The book was founded");

                logger.Debug("Show the list of books");
                ShowList(bookService.GetBooks());

                logger.Debug($"Trying to remove the book {book1.Title + " " + book1.Author} from the service");
                bookService.RemoveBook(book1);
                logger.Info("The book was removed");

                logger.Debug("Trying to sort the books by author by service");
                bookService.SortBooksByTag(new ComparatorByAuthor());
                logger.Info("The books were sorted");

                logger.Debug("Show the list of books");
                Console.WriteLine("==============\nAfter sorting by author:");
                ShowList(bookService.GetBooks());

                #endregion


                #region Binary storage testing

                logger.Debug("Creating of new storage");
                var storage = new BinaryStorage("BinaryStorageFile");
                logger.Info("The storage was created");

                logger.Debug("Saving the list of books");
                bookService.Save(storage);
                logger.Info("The list of books was saved");

                logger.Debug("Loading the list of books");
                var bookService2 = new BookListService();
                bookService2.Load(storage);
                logger.Info("The list of books was sucessfully loaded");

                logger.Debug("Show the list of books");
                Console.WriteLine("==============\nAfter loading:");
                ShowList(bookService2.GetBooks());

                #endregion


                #region Binary serialization storage testing

                logger.Debug("Creating of new storage");
                var storage1 = new BinarySerializationStorage("BinarySerializationFile");
                logger.Info("The storage was created");

                logger.Debug("Saving the list of books");
                bookService.Save(storage1);
                logger.Info("The list of books was saved");

                logger.Debug("Loading the list of books");
                var bookService3 = new BookListService();
                bookService3.Load(storage1);
                logger.Info("The list of books was sucessfully loaded");

                logger.Debug("Show the list of books");
                Console.WriteLine("==============\nAfter loading:");
                ShowList(bookService3.GetBooks());

                #endregion


                #region Exceptions testing

                bookService.AddBook(new Book("CLR via C#", "J. Richter", "Science fiction", 2006, 986));
                bookService.AddBook(null);
                bookService.Load(storage);

                #endregion
            }
            catch (BookNotFoundException ex)
            {
                logger.Warn($"The book: {ex.UnfoundBook.ToString()} was not found. Stacktrace:{ex.StackTrace}");
            }
            catch (BookAlreadyExistsException ex)
            {
                logger.Warn($"The book: {ex.ExistingBook.ToString()} already exists. Stacktrace:{ex.StackTrace}");
            }
            catch (BinaryStorageFileNotFoundException ex)
            {
                logger.Warn($"The storage: {ex.UnfoundPath} was not found. StackTrace: {ex.StackTrace}");
            }
            catch (ArgumentNullException ex)
            {
                logger.Error("Argument is null reference. " + ex.Message + "  StackTrace:" + ex.StackTrace);
            }
            catch (ArgumentException ex)
            {

                logger.Error("Incorrect input argument. " + ex.Message + "  StackTrace:" + ex.StackTrace);
            }
            //catch (Exception ex)
            //{
            //    logger.Fatal("UNHANDLED EXCEPTION!:" + ex.Message + "  StackTrace:" + ex.StackTrace);
            //}
        }

        #region Public static methods

        public static void ShowList(List<Book> books)
        {
            foreach (Book b in books)
            {
                Console.WriteLine(b + "\n");
            }
        }

        #endregion
    }
}
