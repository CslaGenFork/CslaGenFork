using System;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERLevel;

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
        /// Factory method. Loads a <see cref="E12_CityRoad"/> object from the given E12_CityRoadDto.
        /// </summary>
        /// <param name="data">The <see cref="E12_CityRoadDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="E12_CityRoad"/> object.</returns>
        internal static E12_CityRoad GetE12_CityRoad(E12_CityRoadDto data)
        {
            E12_CityRoad obj = new E12_CityRoad();
            obj.Fetch(data);
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
        /// Loads a <see cref="E12_CityRoad"/> object from the given <see cref="E12_CityRoadDto"/>.
        /// </summary>
        /// <param name="data">The E12_CityRoadDto to use.</param>
        private void Fetch(E12_CityRoadDto data)
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
