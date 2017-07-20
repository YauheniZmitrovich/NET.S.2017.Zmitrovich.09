using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Logic;

namespace Storages
{
    /// <summary>
    /// The binary storage for list of books.
    /// </summary>
    public sealed class BinaryStorage : IBookListStorage
    {
        private readonly string _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryStorage"/> class.
        /// </summary>
        /// <param name="path"> The path to the file. </param>
        public BinaryStorage(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Save list of books in the binary storage.
        /// </summary>
        /// <param name="books"> List of books. </param>
        public void Save(IEnumerable<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException(nameof(books));

            using (var writer = new BinaryWriter(File.Open(_path, FileMode.Create)))
            {
                foreach (Book b in books)
                {
                    writer.Write(b.Title);
                    writer.Write(b.Author);
                    writer.Write(b.Genre);
                    writer.Write(b.Year);
                    writer.Write(b.NumberOfPages);
                }
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

            var books = new List<Book>();

            using (var reader = new BinaryReader(File.Open(_path, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {

                    string title = reader.ReadString();
                    string author = reader.ReadString();
                    string genre = reader.ReadString();
                    int year = reader.ReadInt32();
                    int numberOfPages = reader.ReadInt32();

                    books.Add(new Book(title, author, genre, year, numberOfPages));
                }
            }

            return books;
        }
    }
}

