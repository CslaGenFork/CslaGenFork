using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A03Level11Child (read only object).<br/>
    /// This is a generated base class of <see cref="A03Level11Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="A02Level1"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A03Level11Child : ReadOnlyBase<A03Level11Child>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_Child_NameProperty = RegisterProperty<string>(p => p.Level_1_1_Child_Name, "Level_1_1 Child Name");
        /// <summary>
        /// Gets the Level_1_1 Child Name.
        /// </summary>
        /// <value>The Level_1_1 Child Name.</value>
        public string Level_1_1_Child_Name
        {
            get { return GetProperty(Level_1_1_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A03Level11Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A03Level11Child"/> object.</returns>
        internal static A03Level11Child GetA03Level11Child(SafeDataReader dr)
        {
            A03Level11Child obj = new A03Level11Child();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A03Level11Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A03Level11Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="A03Level11Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_Child_NameProperty, dr.GetString("Level_1_1_Child_Name"));
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
