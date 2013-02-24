using System;
using System.Data;
using Csla;
using Csla.Data;

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
        /// Factory method. Loads a <see cref="F11_City_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F11_City_ReChild"/> object.</returns>
        internal static F11_City_ReChild GetF11_City_ReChild(SafeDataReader dr)
        {
            F11_City_ReChild obj = new F11_City_ReChild();
            obj.Fetch(dr);
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
        private F11_City_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F11_City_ReChild"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            City_Child_Name = dr.GetString("City_Child_Name");
            // parent properties
            city_ID2 = dr.GetInt32("City_ID2");
            var args = new DataPortalHookArgs(dr);
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
