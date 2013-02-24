using System;
using Csla;
using ParentLoadRO.DataAccess.ERCLevel;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B11_City_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="B11_City_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="B10_City"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B11_City_ReChild : ReadOnlyBase<B11_City_ReChild>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int city_ID2 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Gets the City Child Name.
        /// </summary>
        /// <value>The City Child Name.</value>
        public string City_Child_Name { get; private set; }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B11_City_ReChild"/> object from the given B11_City_ReChildDto.
        /// </summary>
        /// <param name="data">The <see cref="B11_City_ReChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B11_City_ReChild"/> object.</returns>
        internal static B11_City_ReChild GetB11_City_ReChild(B11_City_ReChildDto data)
        {
            B11_City_ReChild obj = new B11_City_ReChild();
            obj.Fetch(data);
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B11_City_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B11_City_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B11_City_ReChild"/> object from the given <see cref="B11_City_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The B11_City_ReChildDto to use.</param>
        private void Fetch(B11_City_ReChildDto data)
        {
            // Value properties
            City_Child_Name = data.City_Child_Name;
            // parent properties
            city_ID2 = data.Parent_City_ID;
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
