using System;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F05_SubContinent_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="F05_SubContinent_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="F04_SubContinent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F05_SubContinent_ReChild : ReadOnlyBase<F05_SubContinent_ReChild>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int subContinent_ID2 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_Child_NameProperty = RegisterProperty<string>(p => p.SubContinent_Child_Name, "Countries Child Name");
        /// <summary>
        /// Gets the Countries Child Name.
        /// </summary>
        /// <value>The Countries Child Name.</value>
        public string SubContinent_Child_Name
        {
            get { return GetProperty(SubContinent_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F05_SubContinent_ReChild"/> object from the given F05_SubContinent_ReChildDto.
        /// </summary>
        /// <param name="data">The <see cref="F05_SubContinent_ReChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="F05_SubContinent_ReChild"/> object.</returns>
        internal static F05_SubContinent_ReChild GetF05_SubContinent_ReChild(F05_SubContinent_ReChildDto data)
        {
            F05_SubContinent_ReChild obj = new F05_SubContinent_ReChild();
            obj.Fetch(data);
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F05_SubContinent_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public F05_SubContinent_ReChild()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F05_SubContinent_ReChild"/> object from the given <see cref="F05_SubContinent_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The F05_SubContinent_ReChildDto to use.</param>
        private void Fetch(F05_SubContinent_ReChildDto data)
        {
            // Value properties
            LoadProperty(SubContinent_Child_NameProperty, data.SubContinent_Child_Name);
            // parent properties
            subContinent_ID2 = data.Parent_SubContinent_ID;
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
