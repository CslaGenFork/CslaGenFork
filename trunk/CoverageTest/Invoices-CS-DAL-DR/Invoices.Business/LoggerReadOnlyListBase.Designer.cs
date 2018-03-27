using System;
using System.Data;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// LoggerReadOnlyListBase (base class).<br/>
    /// This is a generated <see cref="LoggerReadOnlyListBase{T,C}"/> base classe.
    /// </summary>
    [Serializable]
    public abstract partial class LoggerReadOnlyListBase<T, C> : ReadOnlyListBase<T, C>, IListLog
        where T : LoggerReadOnlyListBase<T, C>, IListLog
        where C : LoggerReadOnlyBase<C>
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerReadOnlyListBase{T,C}"/> class.
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
