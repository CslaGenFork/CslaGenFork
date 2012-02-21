using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D12_CityRoad (read only object).<br/>
    /// This is a generated base class of <see cref="D12_CityRoad"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="D11_CityRoadColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D12_CityRoad : ReadOnlyBase<D12_CityRoad>
    {

        #region Business Properties

        /// <summary>
        /// Gets or sets the 6_CityRoads ID.
        /// </summary>
        /// <value>The 6_CityRoads ID.</value>
        public int CityRoad_ID { get; private set; }

        /// <summary>
        /// Gets or sets the 6_CityRoads Name.
        /// </summary>
        /// <value>The 6_CityRoads Name.</value>
        public string CityRoad_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D12_CityRoad"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="D12_CityRoad"/> object.</returns>
        internal static D12_CityRoad GetD12_CityRoad(SafeDataReader dr)
        {
            D12_CityRoad obj = new D12_CityRoad();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D12_CityRoad"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D12_CityRoad()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="D12_CityRoad"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            CityRoad_ID = dr.GetInt32("CityRoad_ID");
            CityRoad_Name = dr.GetString("CityRoad_Name");
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
