using System;
using System.Collections.Generic;
using Csla;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// LoggerDynamicListBase (base class).<br/>
    /// This is a generated <see cref="LoggerDynamicListBase{T}"/> base classe.
    /// </summary>
    [Serializable]
    public abstract partial class LoggerDynamicListBase<T> : DynamicListBase<T>, IListLog
        where T : LoggerBusinessBase<T>
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerDynamicListBase{T}"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public LoggerDynamicListBase()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion
    }
}
