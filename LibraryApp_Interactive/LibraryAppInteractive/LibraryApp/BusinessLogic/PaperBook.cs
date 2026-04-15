using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    /// <summary>
    /// Derived class from base class Book, implements a paper book
    /// </summary>

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
     
        
        public PaperBook() : base()
        {

        }
    }
}
