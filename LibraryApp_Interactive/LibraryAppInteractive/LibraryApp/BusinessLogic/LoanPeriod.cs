using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    /// <summary>
    /// Implements the amount of time a book or other library asset will be loaned by a user as well as when the loan began and other details
    /// </summary>
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

        public LoanPeriod()
        {
            _borrowedOn = new DateTime();
            _returnedOn = new DateTime();
            _dueDate = new DateTime();
        }
    }
}
