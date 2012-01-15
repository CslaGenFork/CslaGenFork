using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B09Level11111Child (read only object).<br/>
    /// This is a generated base class of <see cref="B09Level11111Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="B08Level1111"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B09Level11111Child : ReadOnlyBase<B09Level11111Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int cNarentID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_1_1_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_1_1_1_Child_NameProperty = RegisterProperty<string>(p => p.Level_1_1_1_1_1_Child_Name, "Level_1_1_1_1_1 Child Name");
        /// <summary>
        /// Gets the Level_1_1_1_1_1 Child Name.
        /// </summary>
        /// <value>The Level_1_1_1_1_1 Child Name.</value>
        public string Level_1_1_1_1_1_Child_Name
        {
            get { return GetProperty(Level_1_1_1_1_1_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B09Level11111Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B09Level11111Child"/> object.</returns>
        internal static B09Level11111Child GetB09Level11111Child(SafeDataReader dr)
        {
            B09Level11111Child obj = new B09Level11111Child();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B09Level11111Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B09Level11111Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B09Level11111Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_1_1_Child_NameProperty, dr.GetString("Level_1_1_1_1_1_Child_Name"));
            cNarentID1 = dr.GetInt32("CNarentID1");
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
