using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    /// <summary>
    /// Implements an asset of the library
    /// </summary>
    public class LibraryAsset
    {
        /// <summary>
        /// A book from thr Book class
        /// </summary>
        private Book _book;
        /// <summary>
        /// The ID of the library the asset is part pf
        /// </summary>
        private int _libID;
        /// <summary>
        /// The status of the asset
        /// </summary>
        private AssetStatus _status;
        /// <summary>
        /// The period of time an asset is being loaned for
        /// </summary>
        private LoanPeriod _loanPeriod;

        public LibraryAsset()
        {
            _book = new Book();
            _libID = 0;
            _status = AssetStatus.Available;
            _loanPeriod = new LoanPeriod();
        }
    }

}
