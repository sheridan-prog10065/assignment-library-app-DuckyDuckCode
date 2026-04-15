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

        public Book(){
            _bookName = "";
            _bookISBN = "";
            _bookAuthorList = new List<string>();
            _libAssetList = new List<LibraryAsset>();
        }
    }
}
