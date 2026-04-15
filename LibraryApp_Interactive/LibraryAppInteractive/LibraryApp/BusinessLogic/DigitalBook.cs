using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    /// <summary>
    /// Derived class from base class Book, implements a digital book
    /// </summary>
    public class DigitalBook : Book
    {
        /// <summary>
        /// The maximum number of days a digital book can be loaned for
        /// </summary>
        private int _maxBorrowDays;
        /// <summary>
        /// Late penalty amount for every day after the due date that the book is not returned
        /// </summary>
        private float _latePenaltyPerDay;

        /// <summary>
        /// Constructor for DigitalBook
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="bookISBN"></param>
        public DigitalBook(string bookName, string bookISBN) : base(bookName, bookISBN)
        {
            _maxBorrowDays = 0;
            _latePenaltyPerDay = 0.0f;
        }

        /// <summary>
        /// Calculates a loan license
        /// </summary>
        private void DetermineLoanLicense()
        {

        }

        /// <summary>
        /// Lets user borrow a book. probably override
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public LibraryAsset BorrowBook()
        {
            throw new Exception("Unimplemented");
        }
        /// <summary>
        /// Lets userreturn a book. probably override
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public (TimeSpan,int, decimal) ReturnBook(int libID)
        {
            throw new Exception("Unimplemented");
        }


    }

}
