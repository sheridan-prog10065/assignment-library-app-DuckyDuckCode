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

        public DigitalBook() : base()
        {
            _maxBorrowDays = 0;
            _latePenaltyPerDay = 0.0f;
        }
    }

}
