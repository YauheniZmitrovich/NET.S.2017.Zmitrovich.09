using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storages
{
    /// <summary>
    /// Represents errors when binary storage file was not founded.
    /// </summary>
    public class BinaryStorageFileNotFoundException : FileNotFoundException
    {
        #region Properties 

        public string UnfoundPath { get; private set; }

        #endregion

        #region Constructors

        //public BinaryStorageFileNotFoundException() { }

        /// <summary>
        ///  Initializes a new instance of <see cref="BinaryStorageFileNotFoundException"/> class with
        ///  its message string with info about the unfound path.
        /// </summary>
        /// <param name="path">The path which was not founded. </param>
        public BinaryStorageFileNotFoundException(string path) : base($"The storage by path: {path} was not founded") { }

        /// <summary>
        ///  Initializes a new instance of <see cref="BinaryStorageFileNotFoundException"/> class with
        ///  its message string with info about the unfound path.
        /// </summary>
        /// <param name="path">The path which was not founded. </param>
        /// <param name="message"> The message about exception. </param>
        public BinaryStorageFileNotFoundException(string path, string message) : base(message)
        {
            UnfoundPath = path;
        }

        /// <summary>
        ///  Initializes a new instance of <see cref="BinaryStorageFileNotFoundException"/> class with
        ///  its message string with info about the unfound path.
        /// </summary>
        /// <param name="path">The path which was not founded. </param>
        /// <param name="message"> The message about exception. </param>
        /// <param name="innerException"> The inner exception. </param>
        public BinaryStorageFileNotFoundException(string path, string message, Exception innerException) :
            base(message, innerException)
        {
            UnfoundPath = path;
        }

        #endregion
    }
}
