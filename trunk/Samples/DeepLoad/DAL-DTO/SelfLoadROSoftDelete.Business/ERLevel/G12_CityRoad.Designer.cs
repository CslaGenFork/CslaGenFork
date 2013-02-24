using System;
using Csla;
using SelfLoadROSoftDelete.DataAccess.ERLevel;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G12_CityRoad (read only object).<br/>
    /// This is a generated base class of <see cref="G12_CityRoad"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="G11_CityRoadColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G12_CityRoad : ReadOnlyBase<G12_CityRoad>
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
        /// Factory method. Loads a <see cref="G12_CityRoad"/> object from the given G12_CityRoadDto.
        /// </summary>
        /// <param name="data">The <see cref="G12_CityRoadDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="G12_CityRoad"/> object.</returns>
        internal static G12_CityRoad GetG12_CityRoad(G12_CityRoadDto data)
        {
            G12_CityRoad obj = new G12_CityRoad();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G12_CityRoad"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private G12_CityRoad()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G12_CityRoad"/> object from the given <see cref="G12_CityRoadDto"/>.
        /// </summary>
        /// <param name="data">The G12_CityRoadDto to use.</param>
        private void Fetch(G12_CityRoadDto data)
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
