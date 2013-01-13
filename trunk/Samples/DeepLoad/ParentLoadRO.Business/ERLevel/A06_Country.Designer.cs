using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A06_Country (read only object).<br/>
    /// This is a generated base class of <see cref="A06_Country"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="A07_RegionObjects"/> of type <see cref="A07_RegionColl"/> (1:M relation to <see cref="A08_Region"/>)<br/>
    /// This class is an item of <see cref="A05_CountryColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A06_Country : ReadOnlyBase<A06_Country>
    {

        #region State Fields

        [NotUndoable]
        private byte[] _rowVersion = new byte[] {};

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
        /// Maintains metadata about <see cref="ParentSubContinentID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> ParentSubContinentIDProperty = RegisterProperty<int>(p => p.ParentSubContinentID, "ParentSubContinentID");
        /// <summary>
        /// Gets the ParentSubContinentID.
        /// </summary>
        /// <value>The ParentSubContinentID.</value>
        public int ParentSubContinentID
        {
            get { return GetProperty(ParentSubContinentIDProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A07_Country_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A07_Country_Child> A07_Country_SingleObjectProperty = RegisterProperty<A07_Country_Child>(p => p.A07_Country_SingleObject, "A07 Country Single Object");
        /// <summary>
        /// Gets the A07 Country Single Object ("parent load" child property).
        /// </summary>
        /// <value>The A07 Country Single Object.</value>
        public A07_Country_Child A07_Country_SingleObject
        {
            get { return GetProperty(A07_Country_SingleObjectProperty); }
            private set { LoadProperty(A07_Country_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A07_Country_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A07_Country_ReChild> A07_Country_ASingleObjectProperty = RegisterProperty<A07_Country_ReChild>(p => p.A07_Country_ASingleObject, "A07 Country ASingle Object");
        /// <summary>
        /// Gets the A07 Country ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The A07 Country ASingle Object.</value>
        public A07_Country_ReChild A07_Country_ASingleObject
        {
            get { return GetProperty(A07_Country_ASingleObjectProperty); }
            private set { LoadProperty(A07_Country_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A07_RegionObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<A07_RegionColl> A07_RegionObjectsProperty = RegisterProperty<A07_RegionColl>(p => p.A07_RegionObjects, "A07 Region Objects");
        /// <summary>
        /// Gets the A07 Region Objects ("parent load" child property).
        /// </summary>
        /// <value>The A07 Region Objects.</value>
        public A07_RegionColl A07_RegionObjects
        {
            get { return GetProperty(A07_RegionObjectsProperty); }
            private set { LoadProperty(A07_RegionObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A06_Country"/> object.</returns>
        internal static A06_Country GetA06_Country(SafeDataReader dr)
        {
            A06_Country obj = new A06_Country();
            obj.Fetch(dr);
            obj.LoadProperty(A07_RegionObjectsProperty, new A07_RegionColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A06_Country"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A06_Country()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="A06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Country_IDProperty, dr.GetInt32("Country_ID"));
            LoadProperty(Country_NameProperty, dr.GetString("Country_Name"));
            LoadProperty(ParentSubContinentIDProperty, dr.GetInt32("Parent_SubContinent_ID"));
            _rowVersion = dr.GetValue("RowVersion") as byte[];
            // parent properties
            parent_SubContinent_ID = dr.GetInt32("Parent_SubContinent_ID");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="A07_Country_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A07_Country_Child child)
        {
            LoadProperty(A07_Country_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="A07_Country_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A07_Country_ReChild child)
        {
            LoadProperty(A07_Country_ASingleObjectProperty, child);
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
