using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Comparators
{
    /// <summary>
    /// Defines a method that a type implements to compare two books.
    /// </summary>
    public class ComparatorByAuthor:IComparer<Book>
    {
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than,
        /// equal to, or greater than the other.
        /// </summary>
        /// <param name="ob1"> The first book to compare. </param>
        /// <param name="ob2"> The second book to compare. </param>
        /// <returns>
        /// A signed integer that indicates the relative values of ob1 and ob2, as shown in the
        /// following table.Value Meaning Less than zero ob1 is less than ob2. Zero ob1 equals ob2. Greater
        /// than zero ob1 is greater than ob2.
        ///</returns>
        public int Compare(Book ob1, Book ob2)
        {
            if (ReferenceEquals(ob1, ob2))
                return 0;
            if (ReferenceEquals(ob1, null))
                return 1;
            if (ReferenceEquals(ob2, null))
                return -1;

            return ob1.Author.CompareTo(ob2.Author);
        }
    }
}
