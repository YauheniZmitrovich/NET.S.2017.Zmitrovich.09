using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Represents errors when book already exists in a book list.
    /// </summary>
    public class BookAlreadyExistsException : Exception
    {
        #region Properties

        /// <summary>
        /// The book which already exists.
        /// </summary>
        public Book ExistingBook { get; private set; }

        #endregion

        #region Constructors

        ///// <summary>
        /////  Initializes a new instance of <see cref="BookAlreadyExistsException"/>.
        ///// </summary>
        //public BookAlreadyExistsException() { }//All must be initialized

        /// <summary>
        ///  Initializes a new instance of <see cref="BookAlreadyExistsException"/> class with
        ///  its message string with info about the book.
        /// </summary>
        /// <param name="book">The book which already exists. </param>
        public BookAlreadyExistsException(Book book) : base($"The book {book.ToString()} already exists.")
        {
            ExistingBook = book;
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="BookAlreadyExistsException"/> class with
        ///  its message string with info about the book.
        /// </summary>
        /// <param name="book">The books which already exists. </param>
        /// <param name="message"> The message about exception. </param>
        public BookAlreadyExistsException(Book book, string message) : base(message)
        {
            ExistingBook = book;
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="BookAlreadyExistsException"/> with
        ///  its message string with info about the book.
        /// </summary>
        /// <param name="book">The books which already exists. </param>
        /// <param name="message"> The message about exception. </param>
        /// <param name="innerException"> The inner exception. </param>
        public BookAlreadyExistsException(Book book, string message, Exception innerException) : base(message, innerException)
        {
            ExistingBook = book;
        }

        #endregion
    }

    /// <summary>
    /// Represents errors when book was not founded in a book list. 
    /// </summary>
    public class BookNotFoundException : Exception
    {
        #region Properties

        public Book UnfoundBook { get; private set; }

        #endregion

        #region Constructors

        ///// <summary>
        /////  Initializes a new instance of <see cref="BookNotFoundException"/>.
        ///// </summary>
        //public BookNotFoundException() { }

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
