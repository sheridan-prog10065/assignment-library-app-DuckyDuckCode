using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    /// <summary>
    /// Derived class from base class Book, implements a paper book
    /// </summary>

    //TODO:
    //User should be able to borrow a library asset through BorrowBook and be able to return a library asset using ReturnBook
    //Borrow book should change an assets status to loaned
    //Return book should make it available again
    //Add check that the book is currently available before borrowing
    public class PaperBook : Book
    {
        /// <summary>
        /// A constant of the maximum amount of time a PaperBook can be loaned for. Can not exceed 30 days
        /// </summary>
        const int MAX_BORROW_DAYS = 30;
        /// <summary>
        /// A fixed penalty rate for every day past the due date a PaperBack is not returned
        /// </summary>
        const float LATE_PENALTY_PER_DAY = 0.25f;
     
        /// <summary>
        /// Constructor for a paper book
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="bookISBN"></param>
        public PaperBook(string bookName, string bookISBN) : base(bookName, bookISBN)
        {
    
        }

        /// <summary>
        /// Lets user borrow a book. probably override
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override LibraryAsset BorrowBook()
        {
            LibraryAsset currentAsset =  findNextAvailableAsset();
            if (currentAsset == null)
            {
                throw new Exception("No copies are available. Try another book");
            }

            currentAsset.Status = AssetStatus.Loaned;
            currentAsset.Loan = new LoanPeriod(DateTime.Now, DateTime.MinValue, MAX_BORROW_DAYS);
            return currentAsset;
        }

        /// <summary>
        /// Lets userreturn a book. probably override
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public (TimeSpan, int, decimal) ReturnBook(int libID)
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
            if(daysLate < 0)
            {
                daysLate = 0;
            }
            decimal fine = daysLate * (decimal)LATE_PENALTY_PER_DAY;
            return (timeBorrowed, daysLate, fine);

        }
    }
}
