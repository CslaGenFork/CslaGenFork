using System;
using Csla;
using ParentLoadRO.DataAccess.ERLevel;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A05_SubContinent_ReChild (read only object).<br/>
    /// This is a generated base class of <see cref="A05_SubContinent_ReChild"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="A04_SubContinent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A05_SubContinent_ReChild : ReadOnlyBase<A05_SubContinent_ReChild>
    {

        #region State Fields

        private byte[] _rowVersion = new byte[] {};

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
        /// Factory method. Loads a <see cref="A05_SubContinent_ReChild"/> object from the given A05_SubContinent_ReChildDto.
        /// </summary>
        /// <param name="data">The <see cref="A05_SubContinent_ReChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="A05_SubContinent_ReChild"/> object.</returns>
        internal static A05_SubContinent_ReChild GetA05_SubContinent_ReChild(A05_SubContinent_ReChildDto data)
        {
            A05_SubContinent_ReChild obj = new A05_SubContinent_ReChild();
            obj.Fetch(data);
            // check all object rules and property rules
            obj.BusinessRules.CheckRules();
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A05_SubContinent_ReChild"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public A05_SubContinent_ReChild()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="A05_SubContinent_ReChild"/> object from the given <see cref="A05_SubContinent_ReChildDto"/>.
        /// </summary>
        /// <param name="data">The A05_SubContinent_ReChildDto to use.</param>
        private void Fetch(A05_SubContinent_ReChildDto data)
        {
            // Value properties
            LoadProperty(SubContinent_Child_NameProperty, data.SubContinent_Child_Name);
            _rowVersion = data.RowVersion;
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
