using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E06_Country (read only object).<br/>
    /// This is a generated base class of <see cref="E06_Country"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="E07_RegionObjects"/> of type <see cref="E07_RegionColl"/> (1:M relation to <see cref="E08_Region"/>)<br/>
    /// This class is an item of <see cref="E05_CountryColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E06_Country : ReadOnlyBase<E06_Country>
    {

        #region State Fields

        private byte[] _rowVersion = new byte[] {};

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
        /// Maintains metadata about child <see cref="E07_Country_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E07_Country_Child> E07_Country_SingleObjectProperty = RegisterProperty<E07_Country_Child>(p => p.E07_Country_SingleObject, "E07 Country Single Object");
        /// <summary>
        /// Gets the E07 Country Single Object ("parent load" child property).
        /// </summary>
        /// <value>The E07 Country Single Object.</value>
        public E07_Country_Child E07_Country_SingleObject
        {
            get { return GetProperty(E07_Country_SingleObjectProperty); }
            private set { LoadProperty(E07_Country_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E07_Country_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E07_Country_ReChild> E07_Country_ASingleObjectProperty = RegisterProperty<E07_Country_ReChild>(p => p.E07_Country_ASingleObject, "E07 Country ASingle Object");
        /// <summary>
        /// Gets the E07 Country ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The E07 Country ASingle Object.</value>
        public E07_Country_ReChild E07_Country_ASingleObject
        {
            get { return GetProperty(E07_Country_ASingleObjectProperty); }
            private set { LoadProperty(E07_Country_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E07_RegionObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<E07_RegionColl> E07_RegionObjectsProperty = RegisterProperty<E07_RegionColl>(p => p.E07_RegionObjects, "E07 Region Objects");
        /// <summary>
        /// Gets the E07 Region Objects ("parent load" child property).
        /// </summary>
        /// <value>The E07 Region Objects.</value>
        public E07_RegionColl E07_RegionObjects
        {
            get { return GetProperty(E07_RegionObjectsProperty); }
            private set { LoadProperty(E07_RegionObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="E06_Country"/> object.</returns>
        internal static E06_Country GetE06_Country(SafeDataReader dr)
        {
            E06_Country obj = new E06_Country();
            obj.Fetch(dr);
            obj.LoadProperty(E07_RegionObjectsProperty, new E07_RegionColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E06_Country"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public E06_Country()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E06_Country"/> object from the given SafeDataReader.
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
        /// Loads child <see cref="E07_Country_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E07_Country_Child child)
        {
            LoadProperty(E07_Country_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="E07_Country_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E07_Country_ReChild child)
        {
            LoadProperty(E07_Country_ASingleObjectProperty, child);
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
