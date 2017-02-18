using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// LoggerBusinessBindingListBase (base class).<br/>
    /// This is a generated base class of <see cref="LoggerBusinessBindingListBase"/> business object.
    /// </summary>
    [Serializable]
    public abstract partial class LoggerBusinessBindingListBase<T, C> : BusinessBindingListBase<T, C>, IListLog
        where T : LoggerBusinessBindingListBase<T, C>, IListLog
        where C : LoggerBusinessBase<C>
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerBusinessBindingListBase"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public LoggerBusinessBindingListBase()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

    }
}
