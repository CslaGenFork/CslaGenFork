using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F11Level111111Child (read only object).<br/>
    /// This is a generated base class of <see cref="F11Level111111Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="F10Level11111"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F11Level111111Child : ReadOnlyBase<F11Level111111Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int cQarentID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Gets or sets the Level_1_1_1_1_1_1 Child Name.
        /// </summary>
        /// <value>The Level_1_1_1_1_1_1 Child Name.</value>
        public string Level_1_1_1_1_1_1_Child_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F11Level111111Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F11Level111111Child"/> object.</returns>
        internal static F11Level111111Child GetF11Level111111Child(SafeDataReader dr)
        {
            F11Level111111Child obj = new F11Level111111Child();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F11Level111111Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F11Level111111Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F11Level111111Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            Level_1_1_1_1_1_1_Child_Name = dr.GetString("Level_1_1_1_1_1_1_Child_Name");
            cQarentID1 = dr.GetInt32("CQarentID1");
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
