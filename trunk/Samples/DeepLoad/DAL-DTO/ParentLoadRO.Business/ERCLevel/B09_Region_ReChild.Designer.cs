using System;
using Csla;
using ParentLoadRO.DataAccess.ERCLevel;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B09_Region_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="B09_Region_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="B08_Region"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B09_Region_ReChild : ReadOnlyBase<B09_Region_ReChild>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int region_ID2 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Region_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Region_Child_NameProperty = RegisterProperty<string>(p => p.Region_Child_Name, "Region Child Name");
        /// <summary>
        /// Gets the Region Child Name.
        /// </summary>
        /// <value>The Region Child Name.</value>
        public string Region_Child_Name
        {
            get { return GetProperty(Region_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B09_Region_ReChild"/> object from the given B09_Region_ReChildDto.
        /// </summary>
        /// <param name="data">The <see cref="B09_Region_ReChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B09_Region_ReChild"/> object.</returns>
        internal static B09_Region_ReChild GetB09_Region_ReChild(B09_Region_ReChildDto data)
        {
            B09_Region_ReChild obj = new B09_Region_ReChild();
            obj.Fetch(data);
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B09_Region_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B09_Region_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B09_Region_ReChild"/> object from the given <see cref="B09_Region_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The B09_Region_ReChildDto to use.</param>
        private void Fetch(B09_Region_ReChildDto data)
        {
            // Value properties
            LoadProperty(Region_Child_NameProperty, data.Region_Child_Name);
            // parent properties
            region_ID2 = data.Parent_Region_ID;
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
