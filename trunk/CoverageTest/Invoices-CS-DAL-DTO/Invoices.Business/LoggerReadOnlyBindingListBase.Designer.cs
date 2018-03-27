using System;
using System.Collections.Generic;
using Csla;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// LoggerReadOnlyBindingListBase (base class).<br/>
    /// This is a generated <see cref="LoggerReadOnlyBindingListBase{T,C}"/> base classe.
    /// </summary>
    [Serializable]
    public abstract partial class LoggerReadOnlyBindingListBase<T, C> : ReadOnlyBindingListBase<T, C>, IListLog
        where T : LoggerReadOnlyBindingListBase<T, C>, IListLog
        where C : LoggerReadOnlyBase<C>
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerReadOnlyBindingListBase{T,C}"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public LoggerReadOnlyBindingListBase()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion
    }
}
