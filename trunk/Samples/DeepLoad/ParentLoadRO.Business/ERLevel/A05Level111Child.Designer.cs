using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A05Level111Child (read only object).<br/>
    /// This is a generated base class of <see cref="A05Level111Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="A04Level11"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A05Level111Child : ReadOnlyBase<A05Level111Child>
    {

        #region State Fields

        [NotUndoable]
        private byte[] _rowVersion = new byte[] {};

        [NotUndoable]
        [NonSerialized]
        internal int cMarentID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_1_Child_NameProperty = RegisterProperty<string>(p => p.Level_1_1_1_Child_Name, "Level_1_1_1 Child Name");
        /// <summary>
        /// Gets the Level_1_1_1 Child Name.
        /// </summary>
        /// <value>The Level_1_1_1 Child Name.</value>
        public string Level_1_1_1_Child_Name
        {
            get { return GetProperty(Level_1_1_1_Child_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="CMarentID1"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> CMarentID1Property = RegisterProperty<int>(p => p.CMarentID1, "CMarent ID1");
        /// <summary>
        /// Gets the CMarent ID1.
        /// </summary>
        /// <value>The CMarent ID1.</value>
        public int CMarentID1
        {
            get { return GetProperty(CMarentID1Property); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A05Level111Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A05Level111Child"/> object.</returns>
        internal static A05Level111Child GetA05Level111Child(SafeDataReader dr)
        {
            A05Level111Child obj = new A05Level111Child();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A05Level111Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A05Level111Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="A05Level111Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_Child_NameProperty, dr.GetString("Level_1_1_1_Child_Name"));
            LoadProperty(CMarentID1Property, dr.GetInt32("CMarentID1"));
            _rowVersion = (dr.GetValue("RowVersion")) as byte[];
            cMarentID1 = dr.GetInt32("CMarentID1");
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
