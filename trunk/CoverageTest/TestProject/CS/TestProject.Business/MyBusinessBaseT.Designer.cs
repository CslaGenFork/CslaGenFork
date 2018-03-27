using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using UsingLibrary;

namespace TestProject.Business
{

    /// <summary>
    /// MyBusinessBase (base class).<br/>
    /// This is a generated <see cref="MyBusinessBase{T}"/> base classe.
    /// </summary>
    [Attributable]
    [Serializable]
    public abstract partial class MyBusinessBase<T> : BusinessBase<T>, IHaveInterface
        where T : MyBusinessBase<T>, IHaveInterface
    {

        #region Business Properties

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MyBusinessBase{T}"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public MyBusinessBase()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion
    }
}
