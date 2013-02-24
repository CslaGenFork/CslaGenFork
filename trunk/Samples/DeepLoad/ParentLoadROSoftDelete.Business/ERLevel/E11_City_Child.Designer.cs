using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E11_City_Child (read only object).<br/>
    /// This is a generated base class of <see cref="E11_City_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="E10_City"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E11_City_Child : ReadOnlyBase<E11_City_Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int city_ID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Gets the CityRoads Child Name.
        /// </summary>
        /// <value>The CityRoads Child Name.</value>
        public string City_Child_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E11_City_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E11_City_Child"/> object.</returns>
        internal static E11_City_Child GetE11_City_Child(SafeDataReader dr)
        {
            E11_City_Child obj = new E11_City_Child();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E11_City_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E11_City_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E11_City_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            City_Child_Name = dr.GetString("City_Child_Name");
            // parent properties
            city_ID1 = dr.GetInt32("City_ID1");
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
