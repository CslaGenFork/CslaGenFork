using System;
using Csla;
using ParentLoadRO.DataAccess.ERLevel;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A12_CityRoad (read only object).<br/>
    /// This is a generated base class of <see cref="A12_CityRoad"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="A11_CityRoadColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A12_CityRoad : ReadOnlyBase<A12_CityRoad>
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
        /// Factory method. Loads a <see cref="A12_CityRoad"/> object from the given A12_CityRoadDto.
        /// </summary>
        /// <param name="data">The <see cref="A12_CityRoadDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="A12_CityRoad"/> object.</returns>
        internal static A12_CityRoad GetA12_CityRoad(A12_CityRoadDto data)
        {
            A12_CityRoad obj = new A12_CityRoad();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A12_CityRoad"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A12_CityRoad()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="A12_CityRoad"/> object from the given <see cref="A12_CityRoadDto"/>.
        /// </summary>
        /// <param name="data">The A12_CityRoadDto to use.</param>
        private void Fetch(A12_CityRoadDto data)
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
