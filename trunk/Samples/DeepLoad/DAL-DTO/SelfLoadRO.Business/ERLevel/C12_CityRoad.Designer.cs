using System;
using Csla;
using SelfLoadRO.DataAccess.ERLevel;

namespace SelfLoadRO.Business.ERLevel
{

    /// <summary>
    /// C12_CityRoad (read only object).<br/>
    /// This is a generated base class of <see cref="C12_CityRoad"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="C11_CityRoadColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C12_CityRoad : ReadOnlyBase<C12_CityRoad>
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
        /// Factory method. Loads a <see cref="C12_CityRoad"/> object from the given C12_CityRoadDto.
        /// </summary>
        /// <param name="data">The <see cref="C12_CityRoadDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="C12_CityRoad"/> object.</returns>
        internal static C12_CityRoad GetC12_CityRoad(C12_CityRoadDto data)
        {
            C12_CityRoad obj = new C12_CityRoad();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C12_CityRoad"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public C12_CityRoad()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="C12_CityRoad"/> object from the given <see cref="C12_CityRoadDto"/>.
        /// </summary>
        /// <param name="data">The C12_CityRoadDto to use.</param>
        private void Fetch(C12_CityRoadDto data)
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
