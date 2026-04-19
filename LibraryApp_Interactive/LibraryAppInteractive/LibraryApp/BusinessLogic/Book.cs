using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{

    /// <summary>
    /// A book contained within a library
    /// </summary>
    /// 

    //TODO
    //be able to check availability using the AssetStatus
    //User should be able to borrow a library asset through BorrowBook and be able to return a library asset using ReturnBook
    //Borrow book should change an assets status to loaned
    //Return book should make it available again
    //Add check that the book is currently available before borrowing
    //User should be able to change a book's status to reserved using ReserveBook
    //should be able to find another asset for a user if the requested one is not available
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
            foreach(LibraryAsset asset in _libAssetList)
            {
                if (asset.IsAvailable)
                {
                    return (true, asset);
                }
             
            }
            return (false, null);
        }

        /// <summary>
        /// Allows user to borrow a book
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public virtual LibraryAsset BorrowBook()
        {
            LibraryAsset currentAsset = findNextAvailableAsset();
            if (currentAsset == null)
            {
                throw new Exception("No copies are available. Try another book");
            }

            currentAsset.Status = AssetStatus.Loaned;
            currentAsset.Loan = new LoanPeriod(DateTime.Now, DateTime.MinValue, 14);
            return currentAsset;
        }

        /// <summary>
        /// Computes when book should be returned
        /// </summary>
        /// <param name="libID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exceptionpublic
        public (TimeSpan, int, decimal) ReturnBook(int libID)
        {
            LibraryAsset returnAsset = findLibraryAsset(libID);
            if(returnAsset != null)
            {
                returnAsset.Status = AssetStatus.Available;

            }
           
            LoanPeriod loan = returnAsset.Loan;
            loan.ReturnedOn = DateTime.Now;
            returnAsset.Loan = loan;
            
         
            TimeSpan timeBorrowed = returnAsset.Loan.LoanDuration;
            int daysLate = (int)returnAsset.Loan.LatePeriod.TotalDays;
            if (daysLate < 0)
            {
                daysLate = 0;
            }
            decimal fine = daysLate * 0.25m;
           

            return (timeBorrowed, daysLate, fine);

        }
        
        /// <summary>
        /// Allows user to reserve a book in advance
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public LibraryAsset ReserveBook()
        {
            LibraryAsset currentAsset = findNextAvailableAsset();
            if (currentAsset == null)
            {
                throw new Exception("No copies are available. Try another book");
            }

            currentAsset.Status = AssetStatus.Reserved;
            return currentAsset;
        }

        /// <summary>
        /// Allows for finding a library asset 
        /// </summary>
        /// <param name="libID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected LibraryAsset findLibraryAsset(int libID)
        {
            foreach(LibraryAsset asset in _libAssetList)
            {
                if(asset.LibID == libID)
                {
                    return asset;
                }
            }
            return null;
        }

        /// <summary>
        /// Finds an asset for the user if requested one isnt available 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected LibraryAsset findNextAvailableAsset()
        {
            foreach (LibraryAsset asset in _libAssetList)
            {
                if (asset.Status == AssetStatus.Available)
                {
                    return asset;
                }
            }
            return null;
        }

        public void AddAsset(LibraryAsset asset)
        {
            _libAssetList.Add(asset);
        }
    }
}
