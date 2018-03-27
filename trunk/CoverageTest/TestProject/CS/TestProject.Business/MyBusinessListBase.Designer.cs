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
    /// This is a generated <see cref="MyBusinessListBase{T,C}"/> base classe.
    /// </summary>
    [Attributable]
    [Serializable]
    public abstract partial class MyBusinessListBase<T, C> : BusinessListBase<T, C>, IHaveInterface
        where T : MyBusinessListBase<T, C>, IHaveInterface
        where C : BusinessBase<C>
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MyBusinessListBase{T,C}"/> class.
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
