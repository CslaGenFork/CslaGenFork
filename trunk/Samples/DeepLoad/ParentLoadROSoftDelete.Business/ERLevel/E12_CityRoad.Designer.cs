using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E12_CityRoad (read only object).<br/>
    /// This is a generated base class of <see cref="E12_CityRoad"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="E11_CityRoadColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E12_CityRoad : ReadOnlyBase<E12_CityRoad>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parent_City_ID = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Gets the CityRoads ID.
        /// </summary>
        /// <value>The CityRoads ID.</value>
        public int CityRoad_ID { get; private set; }

        /// <summary>
        /// Gets the CityRoads Name.
        /// </summary>
        /// <value>The CityRoads Name.</value>
        public string CityRoad_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E12_CityRoad"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E12_CityRoad"/> object.</returns>
        internal static E12_CityRoad GetE12_CityRoad(SafeDataReader dr)
        {
            E12_CityRoad obj = new E12_CityRoad();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E12_CityRoad"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E12_CityRoad()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E12_CityRoad"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            CityRoad_ID = dr.GetInt32("CityRoad_ID");
            CityRoad_Name = dr.GetString("CityRoad_Name");
            // parent properties
            parent_City_ID = dr.GetInt32("Parent_City_ID");
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
