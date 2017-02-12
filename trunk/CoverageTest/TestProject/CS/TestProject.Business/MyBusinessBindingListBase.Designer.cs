using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using UsingLibrary;

namespace TestProject.Business
{

    /// <summary>
    /// MyBusinessBindingListBase (base class).<br/>
    /// This is a generated base class of <see cref="MyBusinessBindingListBase"/> business object.
    /// </summary>
    [Attributable]
    [Serializable]
    public abstract partial class MyBusinessBindingListBase<T, C> : BusinessBindingListBase<T, C>, IHaveInterface
        where T : BusinessBindingListBase<T, C>, IHaveInterface
        where C : BusinessBase<C>
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MyBusinessBindingListBase"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public MyBusinessBindingListBase()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

    }
}
