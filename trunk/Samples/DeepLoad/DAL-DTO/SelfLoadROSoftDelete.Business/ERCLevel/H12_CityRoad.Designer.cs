using System;
using Csla;
using SelfLoadROSoftDelete.DataAccess.ERCLevel;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H12_CityRoad (read only object).<br/>
    /// This is a generated base class of <see cref="H12_CityRoad"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="H11_CityRoadColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H12_CityRoad : ReadOnlyBase<H12_CityRoad>
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
        /// Factory method. Loads a <see cref="H12_CityRoad"/> object from the given H12_CityRoadDto.
        /// </summary>
        /// <param name="data">The <see cref="H12_CityRoadDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="H12_CityRoad"/> object.</returns>
        internal static H12_CityRoad GetH12_CityRoad(H12_CityRoadDto data)
        {
            H12_CityRoad obj = new H12_CityRoad();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H12_CityRoad"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H12_CityRoad()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="H12_CityRoad"/> object from the given <see cref="H12_CityRoadDto"/>.
        /// </summary>
        /// <param name="data">The H12_CityRoadDto to use.</param>
        private void Fetch(H12_CityRoadDto data)
        {
            // Value properties
            CityRoad_ID = data.CityRoad_ID;
            CityRoad_Name = data.CityRoad_Name;
            var args = new DataPortalHookArgs(data);
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
