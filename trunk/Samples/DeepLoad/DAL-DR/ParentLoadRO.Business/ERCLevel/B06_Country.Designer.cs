using System;
using System.Data;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B06_Country (read only object).<br/>
    /// This is a generated base class of <see cref="B06_Country"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B07_RegionObjects"/> of type <see cref="B07_RegionColl"/> (1:M relation to <see cref="B08_Region"/>)<br/>
    /// This class is an item of <see cref="B05_CountryColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B06_Country : ReadOnlyBase<B06_Country>
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
        public static readonly PropertyInfo<int> Country_IDProperty = RegisterProperty<int>(p => p.Country_ID, "3_Countries ID", -1);
        /// <summary>
        /// Gets the 3_Countries ID.
        /// </summary>
        /// <value>The 3_Countries ID.</value>
        public int Country_ID
        {
            get { return GetProperty(Country_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Country_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Country_NameProperty = RegisterProperty<string>(p => p.Country_Name, "3_Countries Name");
        /// <summary>
        /// Gets the 3_Countries Name.
        /// </summary>
        /// <value>The 3_Countries Name.</value>
        public string Country_Name
        {
            get { return GetProperty(Country_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B07_Country_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B07_Country_Child> B07_Country_SingleObjectProperty = RegisterProperty<B07_Country_Child>(p => p.B07_Country_SingleObject, "B07 Country Single Object");
        /// <summary>
        /// Gets the B07 Country Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B07 Country Single Object.</value>
        public B07_Country_Child B07_Country_SingleObject
        {
            get { return GetProperty(B07_Country_SingleObjectProperty); }
            private set { LoadProperty(B07_Country_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B07_Country_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B07_Country_ReChild> B07_Country_ASingleObjectProperty = RegisterProperty<B07_Country_ReChild>(p => p.B07_Country_ASingleObject, "B07 Country ASingle Object");
        /// <summary>
        /// Gets the B07 Country ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B07 Country ASingle Object.</value>
        public B07_Country_ReChild B07_Country_ASingleObject
        {
            get { return GetProperty(B07_Country_ASingleObjectProperty); }
            private set { LoadProperty(B07_Country_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B07_RegionObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B07_RegionColl> B07_RegionObjectsProperty = RegisterProperty<B07_RegionColl>(p => p.B07_RegionObjects, "B07 Region Objects");
        /// <summary>
        /// Gets the B07 Region Objects ("parent load" child property).
        /// </summary>
        /// <value>The B07 Region Objects.</value>
        public B07_RegionColl B07_RegionObjects
        {
            get { return GetProperty(B07_RegionObjectsProperty); }
            private set { LoadProperty(B07_RegionObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B06_Country"/> object.</returns>
        internal static B06_Country GetB06_Country(SafeDataReader dr)
        {
            B06_Country obj = new B06_Country();
            obj.Fetch(dr);
            obj.LoadProperty(B07_RegionObjectsProperty, new B07_RegionColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B06_Country"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B06_Country()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Country_IDProperty, dr.GetInt32("Country_ID"));
            LoadProperty(Country_NameProperty, dr.GetString("Country_Name"));
            parent_SubContinent_ID = dr.GetInt32("Parent_SubContinent_ID");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="B07_Country_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B07_Country_Child child)
        {
            LoadProperty(B07_Country_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="B07_Country_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B07_Country_ReChild child)
        {
            LoadProperty(B07_Country_ASingleObjectProperty, child);
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
