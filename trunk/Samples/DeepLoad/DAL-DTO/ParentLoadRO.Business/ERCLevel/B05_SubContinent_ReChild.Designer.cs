using System;
using Csla;
using ParentLoadRO.DataAccess.ERCLevel;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B05_SubContinent_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="B05_SubContinent_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="B04_SubContinent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B05_SubContinent_ReChild : ReadOnlyBase<B05_SubContinent_ReChild>
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
        public static readonly PropertyInfo<string> SubContinent_Child_NameProperty = RegisterProperty<string>(p => p.SubContinent_Child_Name, "Sub Continent Child Name");
        /// <summary>
        /// Gets the Sub Continent Child Name.
        /// </summary>
        /// <value>The Sub Continent Child Name.</value>
        public string SubContinent_Child_Name
        {
            get { return GetProperty(SubContinent_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B05_SubContinent_ReChild"/> object from the given B05_SubContinent_ReChildDto.
        /// </summary>
        /// <param name="data">The <see cref="B05_SubContinent_ReChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="B05_SubContinent_ReChild"/> object.</returns>
        internal static B05_SubContinent_ReChild GetB05_SubContinent_ReChild(B05_SubContinent_ReChildDto data)
        {
            B05_SubContinent_ReChild obj = new B05_SubContinent_ReChild();
            obj.Fetch(data);
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B05_SubContinent_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B05_SubContinent_ReChild()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B05_SubContinent_ReChild"/> object from the given <see cref="B05_SubContinent_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The B05_SubContinent_ReChildDto to use.</param>
        private void Fetch(B05_SubContinent_ReChildDto data)
        {
            // Value properties
            LoadProperty(SubContinent_Child_NameProperty, data.SubContinent_Child_Name);
            // parent properties
            subContinent_ID2 = data.Parent_SubContinent_ID;
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
