using System;
using System.Data;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F06_Country (read only object).<br/>
    /// This is a generated base class of <see cref="F06_Country"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="F07_RegionObjects"/> of type <see cref="F07_RegionColl"/> (1:M relation to <see cref="F08_Region"/>)<br/>
    /// This class is an item of <see cref="F05_CountryColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F06_Country : ReadOnlyBase<F06_Country>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parent_SubContinent_ID = 0;

        #endregion

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Country_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Country_IDProperty = RegisterProperty<int>(p => p.Country_ID, "Countries ID", -1);
        /// <summary>
        /// Gets the Countries ID.
        /// </summary>
        /// <value>The Countries ID.</value>
        public int Country_ID
        {
            get { return GetProperty(Country_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Country_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Country_NameProperty = RegisterProperty<string>(p => p.Country_Name, "Countries Name");
        /// <summary>
        /// Gets the Countries Name.
        /// </summary>
        /// <value>The Countries Name.</value>
        public string Country_Name
        {
            get { return GetProperty(Country_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F07_Country_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F07_Country_Child> F07_Country_SingleObjectProperty = RegisterProperty<F07_Country_Child>(p => p.F07_Country_SingleObject, "F07 Country Single Object");
        /// <summary>
        /// Gets the F07 Country Single Object ("parent load" child property).
        /// </summary>
        /// <value>The F07 Country Single Object.</value>
        public F07_Country_Child F07_Country_SingleObject
        {
            get { return GetProperty(F07_Country_SingleObjectProperty); }
            private set { LoadProperty(F07_Country_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F07_Country_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F07_Country_ReChild> F07_Country_ASingleObjectProperty = RegisterProperty<F07_Country_ReChild>(p => p.F07_Country_ASingleObject, "F07 Country ASingle Object");
        /// <summary>
        /// Gets the F07 Country ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The F07 Country ASingle Object.</value>
        public F07_Country_ReChild F07_Country_ASingleObject
        {
            get { return GetProperty(F07_Country_ASingleObjectProperty); }
            private set { LoadProperty(F07_Country_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F07_RegionObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<F07_RegionColl> F07_RegionObjectsProperty = RegisterProperty<F07_RegionColl>(p => p.F07_RegionObjects, "F07 Region Objects");
        /// <summary>
        /// Gets the F07 Region Objects ("parent load" child property).
        /// </summary>
        /// <value>The F07 Region Objects.</value>
        public F07_RegionColl F07_RegionObjects
        {
            get { return GetProperty(F07_RegionObjectsProperty); }
            private set { LoadProperty(F07_RegionObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F06_Country"/> object.</returns>
        internal static F06_Country GetF06_Country(SafeDataReader dr)
        {
            F06_Country obj = new F06_Country();
            obj.Fetch(dr);
            obj.LoadProperty(F07_RegionObjectsProperty, new F07_RegionColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F06_Country"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public F06_Country()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Country_IDProperty, dr.GetInt32("Country_ID"));
            LoadProperty(Country_NameProperty, dr.GetString("Country_Name"));
            // parent properties
            parent_SubContinent_ID = dr.GetInt32("Parent_SubContinent_ID");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="F07_Country_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F07_Country_Child child)
        {
            LoadProperty(F07_Country_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="F07_Country_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F07_Country_ReChild child)
        {
            LoadProperty(F07_Country_ASingleObjectProperty, child);
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
