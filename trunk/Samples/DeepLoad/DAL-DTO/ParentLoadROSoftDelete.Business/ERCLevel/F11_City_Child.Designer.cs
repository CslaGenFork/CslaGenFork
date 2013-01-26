using System;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F11_City_Child (read only object).<br/>
    /// This is a generated base class of <see cref="F11_City_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="F10_City"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F11_City_Child : ReadOnlyBase<F11_City_Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int city_ID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Gets or sets the 6_CityRoads Child Name.
        /// </summary>
        /// <value>The 6_CityRoads Child Name.</value>
        public string City_Child_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F11_City_Child"/> object from the given F11_City_ChildDto.
        /// </summary>
        /// <param name="data">The <see cref="F11_City_ChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="F11_City_Child"/> object.</returns>
        internal static F11_City_Child GetF11_City_Child(F11_City_ChildDto data)
        {
            F11_City_Child obj = new F11_City_Child();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F11_City_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F11_City_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F11_City_Child"/> object from the given <see cref="F11_City_ChildDto"/>.
        /// </summary>
        /// <param name="data">The F11_City_ChildDto to use.</param>
        private void Fetch(F11_City_ChildDto data)
        {
            // Value properties
            City_Child_Name = data.City_Child_Name;
            // parent properties
            city_ID1 = data.Parent_City_ID;
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
