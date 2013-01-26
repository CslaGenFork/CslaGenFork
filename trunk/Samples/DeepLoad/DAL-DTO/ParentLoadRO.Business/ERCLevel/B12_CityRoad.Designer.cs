using System;
using Csla;
using ParentLoadRO.DataAccess.ERCLevel;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B12_CityRoad (read only object).<br/>
    /// This is a generated base class of <see cref="B12_CityRoad"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="B11_CityRoadColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B12_CityRoad : ReadOnlyBase<B12_CityRoad>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parent_City_ID = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Gets or sets the City Road ID.
        /// </summary>
        /// <value>The City Road ID.</value>
        public int CityRoad_ID { get; private set; }

        /// <summary>
        /// Gets or sets the City Road Name.
        /// </summary>
        /// <value>The City Road Name.</value>
        public string CityRoad_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B12_CityRoad"/> object from the given B12_CityRoadDto.
        /// </summary>
        /// <param name="data">The <see cref="B12_CityRoadDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B12_CityRoad"/> object.</returns>
        internal static B12_CityRoad GetB12_CityRoad(B12_CityRoadDto data)
        {
            B12_CityRoad obj = new B12_CityRoad();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B12_CityRoad"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B12_CityRoad()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B12_CityRoad"/> object from the given <see cref="B12_CityRoadDto"/>.
        /// </summary>
        /// <param name="data">The B12_CityRoadDto to use.</param>
        private void Fetch(B12_CityRoadDto data)
        {
            // Value properties
            CityRoad_ID = data.CityRoad_ID;
            CityRoad_Name = data.CityRoad_Name;
            // parent properties
            parent_City_ID = data.Parent_City_ID;
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
