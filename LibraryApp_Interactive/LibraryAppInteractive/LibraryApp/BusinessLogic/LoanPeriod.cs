using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    /// <summary>
    /// Implements the amount of time a book or other library asset will be loaned by a user as well as when the loan began and other details
    /// </summary>
    /// 
    //No unimplemented methods TODO it seems
    public struct LoanPeriod
    {
        /// <summary>
        /// The date an asset was borrowed on
        /// </summary>
        private DateTime _borrowedOn;
        /// <summary>
        /// The date an asset was returned to the library
        /// </summary>
        private DateTime _returnedOn;
        /// <summary>
        /// The date an asset must be returned to the library by
        /// </summary>
        private DateTime _dueDate;

        public LoanPeriod(DateTime borrowedOn, DateTime returnedOn)
        {
            _borrowedOn =borrowedOn;
            _returnedOn = returnedOn;
            _dueDate = new DateTime();
        }

        public DateTime BorrowedOn
        {
            get { return _borrowedOn; }
            set { _borrowedOn = value; }
        }

        public DateTime ReturnedOn
        {
            get { return _returnedOn; }
            set { _returnedOn = value; }
        }

        public TimeSpan LoanDuration
        {
            get { return _returnedOn - _borrowedOn; }

        }

        public TimeSpan LatePeriod
        {
            get { return DateTime.Now - _dueDate; }
        }
    }
}
