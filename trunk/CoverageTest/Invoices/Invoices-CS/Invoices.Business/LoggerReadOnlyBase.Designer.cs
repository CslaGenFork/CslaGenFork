using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace Invoices.Business
{

    /// <summary>
    /// LoggerReadOnlyBase (base class).<br/>
    /// This is a generated base class of <see cref="LoggerReadOnlyBase"/> business object.
    /// </summary>
    [Serializable]
    public abstract partial class LoggerReadOnlyBase<T> : ReadOnlyBase<T>, ILog
        where T : LoggerReadOnlyBase<T>, ILog
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="LogAction"/> property.
        /// </summary>
        public static readonly PropertyInfo<byte> LogActionProperty = RegisterProperty<byte>(p => p.LogAction, "Log Action");
        /// <summary>
        /// Gets or sets the Log Action.
        /// </summary>
        /// <value>The Log Action.</value>
        public LogActions LogAction
        {
            get { return ReadPropertyConvert<byte, LogActions>(LogActionProperty); }
            set { LoadPropertyConvert<byte, LogActions>(LogActionProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="LogDateTime"/> property.
        /// </summary>
        public static readonly PropertyInfo<DateTime> LogDateTimeProperty = RegisterProperty<DateTime>(p => p.LogDateTime, "Log Date Time", DateTime.Now);
        /// <summary>
        /// Gets or sets the Log Date Time.
        /// </summary>
        /// <value>The Log Date Time.</value>
        public DateTime LogDateTime
        {
            get { return ReadProperty(LogDateTimeProperty); }
            set { LoadProperty(LogDateTimeProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="LogUser"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> LogUserProperty = RegisterProperty<int>(p => p.LogUser, "Log Useer");
        /// <summary>
        /// Gets or sets the Log Useer.
        /// </summary>
        /// <value>The Log Useer.</value>
        public int LogUser
        {
            get { return ReadProperty(LogUserProperty); }
            set { LoadProperty(LogUserProperty, value); }
        }

        #endregion

        #region Factory Methods

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerReadOnlyBase"/> class.
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
