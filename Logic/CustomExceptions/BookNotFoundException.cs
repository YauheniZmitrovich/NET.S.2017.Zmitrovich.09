using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.CustomExceptions
{
    /// <summary>
    /// Represents errors when book was not founded in a book list. 
    /// </summary>
    public class BookNotFoundException : Exception
    {
        #region Properties

        public Book UnfoundBook { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        ///  Initializes a new instance of <see cref="BookNotFoundException"/> class with
        ///  its message string with info about the book.
        /// </summary>
        /// <param name="book">The books which was not founded. </param>
        public BookNotFoundException(Book book) : base($"The book {book.ToString()} was not founded.")
        {
            UnfoundBook = book;
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="BookNotFoundException"/> class with
        ///  its message string with info about the book.
        /// </summary>
        /// <param name="book">The books which was not founded. </param>
        /// <param name="message"> The message about exception. </param>
        public BookNotFoundException(Book book, string message) : base(message)
        {
            UnfoundBook = book;
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="BookNotFoundException"/> class with
        ///  its message string with info about the book.
        /// </summary>
        /// <param name="book">The books which was not founded. </param>
        /// <param name="message"> The message about exception. </param>
        /// <param name="innerException"> The inner exception. </param>
        public BookNotFoundException(Book book, string message, Exception innerException) : base(message, innerException)
        {
            UnfoundBook = book;
        }

        #endregion
    }
}
