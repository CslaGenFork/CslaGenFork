using System;
using System.Collections.Generic;
using Csla;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// LoggerReadOnlyListBase (base class).<br/>
    /// This is a generated base class of <see cref="LoggerReadOnlyListBase"/> business object.
    /// </summary>
    [Serializable]
    public abstract partial class LoggerReadOnlyListBase<T, C> : ReadOnlyListBase<T, C>, IListLog
        where T : LoggerReadOnlyListBase<T, C>, IListLog
        where C : LoggerReadOnlyBase<C>
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerReadOnlyListBase"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public LoggerReadOnlyListBase()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

    }
}
