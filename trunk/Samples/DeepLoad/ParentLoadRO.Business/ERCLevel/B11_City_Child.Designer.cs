using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B11_City_Child (read only object).<br/>
    /// This is a generated base class of <see cref="B11_City_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="B10_City"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B11_City_Child : ReadOnlyBase<B11_City_Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int city_ID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Gets or sets the 6_CityRoads Child Name.
        /// </summary>
        /// <value>The 6_CityRoads Child Name.</value>
        public string City_Child_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B11_City_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B11_City_Child"/> object.</returns>
        internal static B11_City_Child GetB11_City_Child(SafeDataReader dr)
        {
            B11_City_Child obj = new B11_City_Child();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B11_City_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B11_City_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B11_City_Child"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            City_Child_Name = dr.GetString("City_Child_Name");
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
