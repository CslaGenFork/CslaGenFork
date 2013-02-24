using System;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F07_Country_Child (read only object).<br/>
    /// This is a generated base class of <see cref="F07_Country_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="F06_Country"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F07_Country_Child : ReadOnlyBase<F07_Country_Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int country_ID1 = 0;

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
        /// Factory method. Loads a <see cref="F07_Country_Child"/> object from the given F07_Country_ChildDto.
        /// </summary>
        /// <param name="data">The <see cref="F07_Country_ChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="F07_Country_Child"/> object.</returns>
        internal static F07_Country_Child GetF07_Country_Child(F07_Country_ChildDto data)
        {
            F07_Country_Child obj = new F07_Country_Child();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F07_Country_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F07_Country_Child()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F07_Country_Child"/> object from the given <see cref="F07_Country_ChildDto"/>.
        /// </summary>
        /// <param name="data">The F07_Country_ChildDto to use.</param>
        private void Fetch(F07_Country_ChildDto data)
        {
            // Value properties
            LoadProperty(Country_Child_NameProperty, data.Country_Child_Name);
            // parent properties
            country_ID1 = data.Parent_Country_ID;
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
