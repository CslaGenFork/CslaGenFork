using System;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F11_City_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="F11_City_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="F10_City"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F11_City_ReChild : ReadOnlyBase<F11_City_ReChild>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int city_ID2 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Gets the CityRoads Child Name.
        /// </summary>
        /// <value>The CityRoads Child Name.</value>
        public string City_Child_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F11_City_ReChild"/> object from the given F11_City_ReChildDto.
        /// </summary>
        /// <param name="data">The <see cref="F11_City_ReChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="F11_City_ReChild"/> object.</returns>
        internal static F11_City_ReChild GetF11_City_ReChild(F11_City_ReChildDto data)
        {
            F11_City_ReChild obj = new F11_City_ReChild();
            obj.Fetch(data);
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F11_City_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public F11_City_ReChild()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F11_City_ReChild"/> object from the given <see cref="F11_City_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The F11_City_ReChildDto to use.</param>
        private void Fetch(F11_City_ReChildDto data)
        {
            // Value properties
            City_Child_Name = data.City_Child_Name;
            // parent properties
            city_ID2 = data.Parent_City_ID;
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
