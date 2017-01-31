using System;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F12_CityRoad (read only object).<br/>
    /// This is a generated base class of <see cref="F12_CityRoad"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="F11_CityRoadColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F12_CityRoad : ReadOnlyBase<F12_CityRoad>
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
        /// Factory method. Loads a <see cref="F12_CityRoad"/> object from the given F12_CityRoadDto.
        /// </summary>
        /// <param name="data">The <see cref="F12_CityRoadDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="F12_CityRoad"/> object.</returns>
        internal static F12_CityRoad GetF12_CityRoad(F12_CityRoadDto data)
        {
            F12_CityRoad obj = new F12_CityRoad();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F12_CityRoad"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public F12_CityRoad()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F12_CityRoad"/> object from the given <see cref="F12_CityRoadDto"/>.
        /// </summary>
        /// <param name="data">The F12_CityRoadDto to use.</param>
        private void Fetch(F12_CityRoadDto data)
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

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
