using System;
using System.Data;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F05_SubContinent_Child (read only object).<br/>
    /// This is a generated base class of <see cref="F05_SubContinent_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="F04_SubContinent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F05_SubContinent_Child : ReadOnlyBase<F05_SubContinent_Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int subContinent_ID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_Child_NameProperty = RegisterProperty<string>(p => p.SubContinent_Child_Name, "3_Countries Child Name");
        /// <summary>
        /// Gets the 3_Countries Child Name.
        /// </summary>
        /// <value>The 3_Countries Child Name.</value>
        public string SubContinent_Child_Name
        {
            get { return GetProperty(SubContinent_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F05_SubContinent_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F05_SubContinent_Child"/> object.</returns>
        internal static F05_SubContinent_Child GetF05_SubContinent_Child(SafeDataReader dr)
        {
            F05_SubContinent_Child obj = new F05_SubContinent_Child();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F05_SubContinent_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F05_SubContinent_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F05_SubContinent_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(SubContinent_Child_NameProperty, dr.GetString("SubContinent_Child_Name"));
            // parent properties
            subContinent_ID1 = dr.GetInt32("SubContinent_ID1");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        #endregion

        #region Pseudo Events

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
