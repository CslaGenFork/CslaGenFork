using System;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F03_Continent_Child (read only object).<br/>
    /// This is a generated base class of <see cref="F03_Continent_Child"/> business object.
    /// </summary>
    /// <remarks>
    /// This class is an item of <see cref="F02_Continent"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F03_Continent_Child : ReadOnlyBase<F03_Continent_Child>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int continent_ID1 = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Child_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_Child_NameProperty = RegisterProperty<string>(p => p.Continent_Child_Name, "SubContinents Child Name");
        /// <summary>
        /// Gets the SubContinents Child Name.
        /// </summary>
        /// <value>The SubContinents Child Name.</value>
        public string Continent_Child_Name
        {
            get { return GetProperty(Continent_Child_NameProperty); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F03_Continent_Child"/> object from the given F03_Continent_ChildDto.
        /// </summary>
        /// <param name="data">The <see cref="F03_Continent_ChildDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="F03_Continent_Child"/> object.</returns>
        internal static F03_Continent_Child GetF03_Continent_Child(F03_Continent_ChildDto data)
        {
            F03_Continent_Child obj = new F03_Continent_Child();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F03_Continent_Child"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public F03_Continent_Child()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F03_Continent_Child"/> object from the given <see cref="F03_Continent_ChildDto"/>.
        /// </summary>
        /// <param name="data">The F03_Continent_ChildDto to use.</param>
        private void Fetch(F03_Continent_ChildDto data)
        {
            // Value properties
            LoadProperty(Continent_Child_NameProperty, data.Continent_Child_Name);
            // parent properties
            continent_ID1 = data.Parent_Continent_ID;
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
