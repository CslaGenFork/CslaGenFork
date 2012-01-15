using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A07Level1111Child (read only object).<br/>
    /// This is a generated base class of <see cref="A07Level1111Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="A06Level111"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A07Level1111Child : ReadOnlyBase<A07Level1111Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int cLarentID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Level_1_1_1_1_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Level_1_1_1_1_Child_NameProperty = RegisterProperty<string>(p => p.Level_1_1_1_1_Child_Name, "Level_1_1_1_1 Child Name");
        /// <summary>
        /// Gets the Level_1_1_1_1 Child Name.
        /// </summary>
        /// <value>The Level_1_1_1_1 Child Name.</value>
        public string Level_1_1_1_1_Child_Name
        {
            get { return GetProperty(Level_1_1_1_1_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A07Level1111Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A07Level1111Child"/> object.</returns>
        internal static A07Level1111Child GetA07Level1111Child(SafeDataReader dr)
        {
            A07Level1111Child obj = new A07Level1111Child();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A07Level1111Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A07Level1111Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="A07Level1111Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Level_1_1_1_1_Child_NameProperty, dr.GetString("Level_1_1_1_1_Child_Name"));
            cLarentID1 = dr.GetInt32("CLarentID1");
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
