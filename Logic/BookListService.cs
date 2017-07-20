using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class BookListService
    {
        #region Private fields

        private List<Book> _list;

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        public BookListService()
        {
            _list = new List<Book>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class. 
        /// </summary>
        /// <param name="books"> Book array for the list. </param>
        public BookListService(IEnumerable<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException(nameof(books));

            _list.AddRange(books);
        }

        #endregion


        #region Methods

        /// <summary>
        /// Adds the book to the end of the book list.
        /// </summary>
        /// <param name="book"> The book to add to the book list. </param>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (_list.Contains(book))
                throw new BookAlreadyExistsException(book,"The same book already exists.");

            _list.Add(book);
        }

        /// <summary>
        /// Removes the first occurrence of the book from the book list.
        /// </summary>
        /// <param name="book"> The book to remove from the book list. </param>
        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (!_list.Remove(book))
                throw new BookNotFoundException(book,"The book was not founded.");
        }

        /// <summary>
        ///  Searches for an element that matches the conditions defined by the specified
        ///  predicate, and returns the first occurrence.
        /// </summary>
        /// <param name="condition">
        ///  The System.Predicate delegate that defines the conditions of the element to search for.
        /// </param>
        /// <returns>
        /// The first element that matches the conditions defined by the specified predicate.
        /// </returns>
        public Book FindBookByTag(Predicate<Book> condition)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));

            return _list.Find(condition);
        }

        /// <summary>
        /// Sorts the elements using the specified comparer.
        /// </summary>
        /// <param name="comparer">
        /// The System.Collections.Generic.IComparer implementation to use when comparing
        /// elements, or null to use the default comparer System.Collections.Generic.Comparer.Default.
        /// </param>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();

            _list.Sort(comparer);
        }

        /// <summary>
        /// Save list of books to <see cref="storage"/>.
        /// </summary>
        /// <param name="storage"> Storage to save the list of books. </param>
        public void Save(IBookListStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException(nameof(storage));

            storage.Save(_list);
        }

        /// <summary>
        /// Load list of books from <see cref="storage"/>.
        /// </summary>
        /// <returns> Storage to load a list of books. </returns>
        public void Load(IBookListStorage storage)
        {
            _list = storage?.Load() ?? throw new ArgumentNullException(nameof(storage));
        }

        /// <summary>
        /// Returns array of books.
        /// </summary>
        /// <returns> Returns <see cref="IEnumerable{Book}"/> of books. </returns>
        public List<Book> GetBooks()
        {
            Book[] books = new Book[_list.Count];
            _list.CopyTo(books);

            return new List<Book>(books);
        }

        #endregion


        #region Properties

        /// <summary>
        /// Number of books in list.
        /// </summary>
        public int NumberOfBooks => _list.Count;

        #endregion
    }
}
