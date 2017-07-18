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
        public BookAlreadyExistsException() { }

        public BookAlreadyExistsException(string message): base(message) { }

        public BookAlreadyExistsException(string message, Exception innerException):
            base(message, innerException){ }
    }

    /// <summary>
    /// Represents errors when book was not founded in a book list. 
    /// </summary>
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException() { }

        public BookNotFoundException(string message) : base(message) { }

        public BookNotFoundException(string message, Exception innerException) :
            base(message, innerException)
        { }
    }
}
