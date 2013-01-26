using System;
using Csla;
using ParentLoadRO.DataAccess.ERCLevel;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B03_Continent_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="B03_Continent_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="B02_Continent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B03_Continent_ReChild : ReadOnlyBase<B03_Continent_ReChild>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int continent_ID2 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_Child_NameProperty = RegisterProperty<string>(p => p.Continent_Child_Name, "Continent Child Name");
        /// <summary>
        /// Gets the Continent Child Name.
        /// </summary>
        /// <value>The Continent Child Name.</value>
        public string Continent_Child_Name
        {
            get { return GetProperty(Continent_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B03_Continent_ReChild"/> object from the given B03_Continent_ReChildDto.
        /// </summary>
        /// <param name="data">The <see cref="B03_Continent_ReChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B03_Continent_ReChild"/> object.</returns>
        internal static B03_Continent_ReChild GetB03_Continent_ReChild(B03_Continent_ReChildDto data)
        {
            B03_Continent_ReChild obj = new B03_Continent_ReChild();
            obj.Fetch(data);
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B03_Continent_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B03_Continent_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B03_Continent_ReChild"/> object from the given <see cref="B03_Continent_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The B03_Continent_ReChildDto to use.</param>
        private void Fetch(B03_Continent_ReChildDto data)
        {
            // Value properties
            LoadProperty(Continent_Child_NameProperty, data.Continent_Child_Name);
            // parent properties
            continent_ID2 = data.Parent_Continent_ID;
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
