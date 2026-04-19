using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    /// <summary>
    /// Derived class from base class Book, implements a digital book
    /// </summary>
    /// 

    //TODO:
    //User should be able to borrow a library asset through BorrowBook and be able to return a library asset using ReturnBook
    //DetermineLoanLicense should use LoanPeriod
    //Borrow book should change an assets status to loaned
    //Return book should make it available again
    //Add check that the book is currently available before borrowing
    
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
            DetermineLoanLicense();
        }

        /// <summary>
        /// Calculates a loan license
        /// </summary>
        private void DetermineLoanLicense()
        {
            _maxBorrowDays = 14;
            _latePenaltyPerDay = 0.50f;
        }

        /// <summary>
        /// Lets user borrow a book. probably override
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override LibraryAsset BorrowBook()
        {
            LibraryAsset currentAsset = findNextAvailableAsset();
            if (currentAsset == null)
            {
                throw new Exception("No copies are available. Try another book");
            }

            currentAsset.Status = AssetStatus.Loaned;
            currentAsset.Loan = new LoanPeriod(DateTime.Now, DateTime.MinValue, _maxBorrowDays);
            return currentAsset;
        }

        /// <summary>
        /// Lets userreturn a book. probably override
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public (TimeSpan,int, decimal) ReturnBook(int libID)
        {
            LibraryAsset returnAsset = findLibraryAsset(libID);
            if (returnAsset != null)
            {
                returnAsset.Status = AssetStatus.Available;
                LoanPeriod loan = returnAsset.Loan;
                loan.ReturnedOn = DateTime.Now;
                returnAsset.Loan = loan;


            }
            //time borrowd, days late, fine
            TimeSpan timeBorrowed = returnAsset.Loan.LoanDuration;
            int daysLate = (int)returnAsset.Loan.LatePeriod.TotalDays;
            if (daysLate < 0)
            {
                daysLate = 0;
            }
            decimal fine = daysLate * (decimal)_latePenaltyPerDay;
            return (timeBorrowed, daysLate, fine);

        }
    }
}


