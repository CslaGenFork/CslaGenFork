using System;
using Csla;
using SelfLoadRO.DataAccess.ERCLevel;

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
        /// Factory method. Loads a <see cref="D12_CityRoad"/> object from the given D12_CityRoadDto.
        /// </summary>
        /// <param name="data">The <see cref="D12_CityRoadDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="D12_CityRoad"/> object.</returns>
        internal static D12_CityRoad GetD12_CityRoad(D12_CityRoadDto data)
        {
            D12_CityRoad obj = new D12_CityRoad();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D12_CityRoad"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public D12_CityRoad()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="D12_CityRoad"/> object from the given <see cref="D12_CityRoadDto"/>.
        /// </summary>
        /// <param name="data">The D12_CityRoadDto to use.</param>
        private void Fetch(D12_CityRoadDto data)
        {
            // Value properties
            CityRoad_ID = data.CityRoad_ID;
            CityRoad_Name = data.CityRoad_Name;
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
