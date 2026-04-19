using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    /// <summary>
    /// Implements an asset of the library
    /// </summary>
    /// 
    //No unimplemented methods TODO it seems
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

        /// <summary>
        /// Constructor for a LibraryAsset
        /// </summary>
        /// <param name="libID"></param>
        /// <param name="book"></param>
        public LibraryAsset(int libID, Book book)
        {
            _book = book;
            _libID = libID;
            _status = AssetStatus.Available;
            _loanPeriod = new LoanPeriod();
        }

        /// <summary>
        /// libID as a property
        /// </summary>
        public int LibID
        {
            get { return _libID; }
            set { _libID = value; }
        }

        /// <summary>
        /// Asset status as a property
        /// </summary>
        public AssetStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        /// <summary>
        /// Loanperiod as a property
        /// </summary>
        public LoanPeriod Loan
        {
            get { return _loanPeriod; }
            set { _loanPeriod = value; }
        }

        /// <summary>
        ///IsAvailable as a property, 
        /// </summary>
        public bool IsAvailable
        {
            get { return _status == AssetStatus.Available; }
            set {
                if (value == true)
                {
                    _status = AssetStatus.Available;
                }
                else
                {
                    _status = AssetStatus.Loaned;
                }
            }
        }
        public override string ToString()
        {
            return $"LibID: {LibID}, Status: {Status} ";
        }
    }
   
    }
