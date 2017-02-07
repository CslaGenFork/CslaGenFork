using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// LoggerReadOnlyBidingListBase (base class).<br/>
    /// This is a generated base class of <see cref="LoggerReadOnlyBidingListBase"/> business object.
    /// </summary>
    [Serializable]
    public abstract partial class LoggerReadOnlyBidingListBase<T, C> : ReadOnlyBindingListBase<T, C>, IListLog
        where T : LoggerReadOnlyBidingListBase<T, C>, IListLog
        where C : LoggerReadOnlyBase<C>
    {

        #region Factory Methods

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerReadOnlyBidingListBase"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public LoggerReadOnlyBidingListBase()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

    }
}
