using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Storages
{
    /// <summary>
    /// The binary serialization storage for list of books.
    /// </summary>
    public sealed class BinarySerializationStorage : IBookListStorage
    {
        private readonly string _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySerializationStorage"/> class.
        /// </summary>
        /// <param name="path"> The path to the file. </param>
        public BinarySerializationStorage(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Save list of books in the binary serialization storage.
        /// </summary>
        /// <param name="books"> List of books. </param>
        public void Save(IEnumerable<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException(nameof(books));

            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, books);
            }
        }

        /// <summary>
        /// Load data from the binary storage to the list of books;
        /// </summary>
        /// <returns> List of books from the binary storage.</returns>
        public List<Book> Load()
        {
            if (!File.Exists(_path))
                throw new BinaryStorageFileNotFoundException(_path);

            var formatter = new BinaryFormatter();

            var books = new List<Book>();

            using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                books = (List<Book>)formatter.Deserialize(fs);
            }

            return books;
        }
    }
}
