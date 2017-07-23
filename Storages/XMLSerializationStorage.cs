using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Logic;

namespace Storages
{
    /// <summary>
    /// The XML serialization storage for list of books.
    /// </summary>
    public sealed class XmlSerializationStorage : IBookListStorage
    {
        private readonly string _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlSerializationStorage"/> class.
        /// </summary>
        /// <param name="path"> The path to the file. </param>
        public XmlSerializationStorage(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Save list of books in the XML serialization storage.
        /// </summary>
        /// <param name="books"> List of books. </param>
        public void Save(IEnumerable<Book> books)
        {
            if (books == null)
                throw new ArgumentNullException(nameof(books));

            var formatter = new XmlSerializer(typeof(List<Book>));

            using (var fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, books);
            }
        }

        /// <summary>
        /// Load data from the XML storage to the list of books;
        /// </summary>
        /// <returns> List of books from the XML storage.</returns>
        public List<Book> Load()
        {
            if (!File.Exists(_path))
                throw new BinaryStorageFileNotFoundException(_path);

            var formatter = new XmlSerializer(typeof(List<Book>));

            var books = new List<Book>();

            using (var fs = new FileStream(_path, FileMode.OpenOrCreate))
            {
                books = (List<Book>)formatter.Deserialize(fs);
            }

            return books;
        }
    }
}