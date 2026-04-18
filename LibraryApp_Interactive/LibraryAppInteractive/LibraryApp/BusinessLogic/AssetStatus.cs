using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryAppInteractive.BusinessLogic
{
    /// <summary>
    /// Connects to a book or other library asset to determine if its not available, available, loaned, or reserved
    /// </summary>
    /// 
    //Nothing more TODO here
    public enum AssetStatus
    {
        NotAvailable,
        Available,
        Loaned,
        Reserved
    }
}
