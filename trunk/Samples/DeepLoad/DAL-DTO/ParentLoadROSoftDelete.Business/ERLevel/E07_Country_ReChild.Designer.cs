using System;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERLevel;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E07_Country_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="E07_Country_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="E06_Country"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E07_Country_ReChild : ReadOnlyBase<E07_Country_ReChild>
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
        public static readonly PropertyInfo<string> Country_Child_NameProperty = RegisterProperty<string>(p => p.Country_Child_Name, "Regions Child Name");
        /// <summary>
        /// Gets the Regions Child Name.
        /// </summary>
        /// <value>The Regions Child Name.</value>
        public string Country_Child_Name
        {
            get { return GetProperty(Country_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E07_Country_ReChild"/> object from the given E07_Country_ReChildDto.
        /// </summary>
        /// <param name="data">The <see cref="E07_Country_ReChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="E07_Country_ReChild"/> object.</returns>
        internal static E07_Country_ReChild GetE07_Country_ReChild(E07_Country_ReChildDto data)
        {
            E07_Country_ReChild obj = new E07_Country_ReChild();
            obj.Fetch(data);
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E07_Country_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public E07_Country_ReChild()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E07_Country_ReChild"/> object from the given <see cref="E07_Country_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The E07_Country_ReChildDto to use.</param>
        private void Fetch(E07_Country_ReChildDto data)
        {
            // Value properties
            LoadProperty(Country_Child_NameProperty, data.Country_Child_Name);
            // parent properties
            country_ID2 = data.Parent_Country_ID;
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
