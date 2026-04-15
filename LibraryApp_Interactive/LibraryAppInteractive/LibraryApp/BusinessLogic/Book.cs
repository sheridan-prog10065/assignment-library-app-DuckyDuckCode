using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{

    /// <summary>
    /// A book contained within a library
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The name of a book
        /// </summary>
        private string _bookName;
        /// <summary>
        /// The ISBN of the book, acts as an ID
        /// </summary>
        private string _bookISBN;
        /// <summary>
        /// List of authors of a book. List because a book may have multiple authors
        /// </summary>
        private List<string> _bookAuthorList;
        /// <summary>
        /// List of library assets the book is related to
        /// </summary>
        private List<LibraryAsset> _libAssetList;

        /// <summary>
        /// Constructor for Book object
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="bookISBN"></param>
        public Book(string bookName, string bookISBN){
            _bookName = bookName;
            _bookISBN = bookISBN;
            _bookAuthorList = new List<string>();
            _libAssetList = new List<LibraryAsset>();
        }

        /// <summary>
        /// Name of book as a property
        /// </summary>
        public string Name
        {
            get { return _bookName; }
            set { _bookName = value; }
        }
       /// <summary>
       /// ISBN of a book as a property
       /// </summary>
        public string ISBN
        {
            get { return _bookISBN; }
            set { _bookISBN = value; }
        }

        /// <summary>
        /// List of authors as a property
        /// </summary>
        public List<string> Authors
        {
            get { return _bookAuthorList; }
            set { _bookAuthorList = value; }
        }

        /// <summary>
        /// Assets as a property
        /// </summary>
        public IEnumerable<LibraryAsset> Assets
        {
            get { return _libAssetList; }
            set { _libAssetList = (List<LibraryAsset>)value; }
        }

        /// <summary>
        /// Checks if an asset is available for borrowing
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public (bool,LibraryAsset) CheckAvailability()
        {
            throw new Exception("Unimplemented");
        }

        /// <summary>
        /// Allows user to borrow a book
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public LibraryAsset BorrowBook()
        {
            throw new Exception("Unimplemented");
        }

        /// <summary>
        /// Computes when book should be returned
        /// </summary>
        /// <param name="libID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public (TimeSpan, int, decimal) ReturnBook(int libID)
        {
            throw new Exception("Unimplemented");
        }

        /// <summary>
        /// Allows user to reserve a book in advance
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public LibraryAsset ReserveBook()
        {
            throw new Exception("Unimplemented");
        }

        /// <summary>
        /// Allows for finding a library asset 
        /// </summary>
        /// <param name="libID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private LibraryAsset findLibraryAsset(int libID)
        {
            throw new Exception("Unimplemented");
        }

        /// <summary>
        /// Finds an asset for the user if requested one isnt available 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private LibraryAsset findNextAvailableAsset()
        {
            throw new Exception("Unimplemented");
        }
    }
}
