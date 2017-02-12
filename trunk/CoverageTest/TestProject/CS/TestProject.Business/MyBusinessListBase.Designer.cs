using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using UsingLibrary;

namespace TestProject.Business
{

    /// <summary>
    /// MyBusinessListBase (base class).<br/>
    /// This is a generated base class of <see cref="MyBusinessListBase"/> business object.
    /// </summary>
    [Attributable]
    [Serializable]
    public abstract partial class MyBusinessListBase<T, C> : BusinessListBase<T, C>, IHaveInterface
        where T : BusinessListBase<T, C>, IHaveInterface
        where C : BusinessBase<C>
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MyBusinessListBase"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public MyBusinessListBase()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

    }
}
