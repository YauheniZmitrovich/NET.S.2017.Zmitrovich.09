using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IBookListStorage
    {
        /// <summary>
        /// Save list of books in specified storage.
        /// </summary>
        /// <param name="books"> List of books. </param>
        void Save(List<Book> books);

        /// <summary>
        /// Save list of books in specified storage.
        /// </summary>
        /// <returns> List of books. </returns>
        List<Book> Load();
    }
}
