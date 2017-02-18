using System;
using System.Data;
using Csla;
using Csla.Data;
using Invoices.DataAccess;

namespace Invoices.Business
{

    /// <summary>
    /// LoggerDynamicListBase (base class).<br/>
    /// This is a generated base class of <see cref="LoggerDynamicListBase"/> business object.
    /// </summary>
    [Serializable]
    public abstract partial class LoggerDynamicListBase<T> : DynamicListBase<T>, IListLog
        where T : LoggerBusinessBase<T>
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerDynamicListBase"/> class.
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
