using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E12Level111111 (read only object).<br/>
    /// This is a generated base class of <see cref="E12Level111111"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="E11Level111111Coll"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E12Level111111 : ReadOnlyBase<E12Level111111>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int qarentID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Gets or sets the Level_1_1_1_1_1_1 ID.
        /// </summary>
        /// <value>The Level_1_1_1_1_1_1 ID.</value>
        public int Level_1_1_1_1_1_1_ID { get; private set; }

        /// <summary>
        /// Gets or sets the Level_1_1_1_1_1_1 Name.
        /// </summary>
        /// <value>The Level_1_1_1_1_1_1 Name.</value>
        public string Level_1_1_1_1_1_1_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E12Level111111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E12Level111111"/> object.</returns>
        internal static E12Level111111 GetE12Level111111(SafeDataReader dr)
        {
            E12Level111111 obj = new E12Level111111();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E12Level111111"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E12Level111111()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E12Level111111"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            Level_1_1_1_1_1_1_ID = dr.GetInt32("Level_1_1_1_1_1_1_ID");
            Level_1_1_1_1_1_1_Name = dr.GetString("Level_1_1_1_1_1_1_Name");
            qarentID1 = dr.GetInt32("QarentID1");
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
