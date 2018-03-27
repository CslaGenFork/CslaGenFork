using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// LoggerReadOnlyBase (base class).<br/>
    /// This is a generated <see cref="LoggerReadOnlyBase{T}"/> base classe.
    /// </summary>
    [Serializable]
    public abstract partial class LoggerReadOnlyBase<T> : ReadOnlyBase<T>, ILog
        where T : LoggerReadOnlyBase<T>, ILog
    {

        #region State Fields

        private byte _logAction = 0;
        private DateTime _logDateTime = DateTime.Now;
        private int _logUser = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Gets or sets the Log Action.
        /// </summary>
        /// <value>The Log Action.</value>
        public LogActions LogAction
        {
            get { return (LogActions)_logAction; }
            set { _logAction = (byte)value; }
        }

        /// <summary>
        /// Gets or sets the Log Date Time.
        /// </summary>
        /// <value>The Log Date Time.</value>
        public DateTime LogDateTime
        {
            get { return _logDateTime; }
            set { _logDateTime = value; }
        }

        /// <summary>
        /// Gets or sets the Log Useer.
        /// </summary>
        /// <value>The Log Useer.</value>
        public int LogUser
        {
            get { return _logUser; }
            set { _logUser = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerReadOnlyBase{T}"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public LoggerReadOnlyBase()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion
    }
}
