using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public sealed class Book : IEquatable<Book>, IComparable, IComparable<Book>
    {
        #region Private fields

        private string _title;

        private string _author;

        private string _genre;

        private int _numberOfPages;

        #endregion


        #region Properties

        /// <summary>
        /// Title of the book.
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("The book must have the tittle.");
                _title = value;
            }
        }

        /// <summary>
        /// Author of the book.
        /// </summary>
        public string Author
        {
            get => _author;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("The book must have the author.");
                _author = value;
            }
        }

        /// <summary>
        /// Genre of the book.
        /// </summary>
        public string Genre
        {
            get => _genre;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("The book must belong to the genre.");
                _genre = value;
            }
        }

        /// <summary>
        /// Year of publication of the book.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Number of pages of the book.
        /// </summary>
        public int NumberOfPages
        {
            get => _numberOfPages;
            set
            {
                if (value < 1)
                    throw new ArgumentException("Number of pages must be greater than zero.");
                _numberOfPages = value;
            }
        }

        #endregion


        #region Constructors 

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book(string title, string author, string genre, int year, int numberOfPages)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
            NumberOfPages = numberOfPages;
        }

        #endregion


        #region Object methods overloading

        /// <summary>
        /// Returns a string that represents the current book.
        /// </summary>
        /// <returns> A string that represents the current book. </returns>
        public override string ToString() =>
                $"\"{Title}\" was written by {Author} in {Year}.\nGenre: {Genre}.\nNumber of pages: {NumberOfPages}.";

        /// <summary>
        /// Serves as the default hash function for <see cref="Book"/>.
        /// </summary>
        /// <returns>  A hash code for the current book. </returns>
        public override int GetHashCode() => Author.Length ^ Year + Title.Length ^ NumberOfPages + Genre.Length;

        /// <summary>
        /// Determines whether one book is equal to the current object. 
        /// </summary>
        /// <param name="obj"> The object to compare with the current book. </param>
        /// <returns> True if the book is equal to the current object; otherwise, false. </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Book && this.Equals((Book)obj);
        }

        #endregion


        #region Interfaces implementation


        #region IEquatable implementation

        /// <summary>
        /// Indicates whether the current book is equal to another book.
        /// </summary>
        /// <param name="other"> A book to compare with this book. </param>
        /// <returns> True if the book is equal to the current object; otherwise, false. </returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Title.Equals(other.Title) && Author.Equals(other.Author) && Genre.Equals(other.Genre)
                   && Year.Equals(other.Year) && NumberOfPages.Equals(other.NumberOfPages);
        }

        #endregion

        #region IComparable implementations

        /// <summary>
        /// Compares the current instance with another object of the same type and returns
        /// an integer that indicates whether the current instance precedes, follows, or
        /// occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj"> An object to compare with this instance. </param>
        /// <returns> A value that indicates the relative order of the objects being compared. The
        /// return value has these meanings: Value Meaning Less than zero This instance precedes
        /// obj in the sort order. Zero This instance occurs in the same position in the
        /// sort order as obj. Greater than zero This instance follows obj in the sort order. 
        /// </returns>
        /// <exception cref="ArgumentException"> Obj is not the same type as this instance. </exception>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (!(obj is Book))
                throw new ArgumentException("Object is not a Book");

            return CompareTo(obj);
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <param name="other"> An object to compare with this object. </param>
        /// <returns> Compares the current object with another object of the same type. </returns>
        public int CompareTo(Book other)
        {
            if (other == null) return 1;

            return String.Compare(Title, other.Title, StringComparison.Ordinal);
        }

        #endregion


        #endregion


        #region Operators overloading

        public static bool operator ==(Book operand1, Book operand2)
        {
            if (ReferenceEquals((object)operand1, (object)operand2))
            {
                return true;
            }

            if ((object)operand1 == null || (object)operand2 == null)
            {
                return false;
            }

            return operand1.Equals(operand2);
        }

        public static bool operator !=(Book operand1, Book operand2)
        {
            return !(operand1 == operand2);
        }

        #endregion
    }

}

