using System;
using Csla;
using ParentLoadRO.DataAccess.ERCLevel;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B07_Country_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="B07_Country_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="B06_Country"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B07_Country_ReChild : ReadOnlyBase<B07_Country_ReChild>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int country_ID2 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Country_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Country_Child_NameProperty = RegisterProperty<string>(p => p.Country_Child_Name, "Country Child Name");
        /// <summary>
        /// Gets the Country Child Name.
        /// </summary>
        /// <value>The Country Child Name.</value>
        public string Country_Child_Name
        {
            get { return GetProperty(Country_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B07_Country_ReChild"/> object from the given B07_Country_ReChildDto.
        /// </summary>
        /// <param name="data">The <see cref="B07_Country_ReChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B07_Country_ReChild"/> object.</returns>
        internal static B07_Country_ReChild GetB07_Country_ReChild(B07_Country_ReChildDto data)
        {
            B07_Country_ReChild obj = new B07_Country_ReChild();
            obj.Fetch(data);
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B07_Country_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B07_Country_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B07_Country_ReChild"/> object from the given <see cref="B07_Country_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The B07_Country_ReChildDto to use.</param>
        private void Fetch(B07_Country_ReChildDto data)
        {
            // Value properties
            LoadProperty(Country_Child_NameProperty, data.Country_Child_Name);
            // parent properties
            country_ID2 = data.Parent_Country_ID;
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