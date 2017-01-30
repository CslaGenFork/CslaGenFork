using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERLevel
{

    /// <summary>
    /// C06_Country (read only object).<br/>
    /// This is a generated base class of <see cref="C06_Country"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="C07_RegionObjects"/> of type <see cref="C07_RegionColl"/> (1:M relation to <see cref="C08_Region"/>)<br/>
    /// This class is an item of <see cref="C05_CountryColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C06_Country : ReadOnlyBase<C06_Country>
    {

        #region State Fields

        private byte[] _rowVersion = new byte[] {};

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
        /// Maintains metadata about child <see cref="C07_Country_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C07_Country_Child> C07_Country_SingleObjectProperty = RegisterProperty<C07_Country_Child>(p => p.C07_Country_SingleObject, "C07 Country Single Object");
        /// <summary>
        /// Gets the C07 Country Single Object ("self load" child property).
        /// </summary>
        /// <value>The C07 Country Single Object.</value>
        public C07_Country_Child C07_Country_SingleObject
        {
            get { return GetProperty(C07_Country_SingleObjectProperty); }
            private set { LoadProperty(C07_Country_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C07_Country_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C07_Country_ReChild> C07_Country_ASingleObjectProperty = RegisterProperty<C07_Country_ReChild>(p => p.C07_Country_ASingleObject, "C07 Country ASingle Object");
        /// <summary>
        /// Gets the C07 Country ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The C07 Country ASingle Object.</value>
        public C07_Country_ReChild C07_Country_ASingleObject
        {
            get { return GetProperty(C07_Country_ASingleObjectProperty); }
            private set { LoadProperty(C07_Country_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C07_RegionObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<C07_RegionColl> C07_RegionObjectsProperty = RegisterProperty<C07_RegionColl>(p => p.C07_RegionObjects, "C07 Region Objects");
        /// <summary>
        /// Gets the C07 Region Objects ("self load" child property).
        /// </summary>
        /// <value>The C07 Region Objects.</value>
        public C07_RegionColl C07_RegionObjects
        {
            get { return GetProperty(C07_RegionObjectsProperty); }
            private set { LoadProperty(C07_RegionObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="C06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="C06_Country"/> object.</returns>
        internal static C06_Country GetC06_Country(SafeDataReader dr)
        {
            C06_Country obj = new C06_Country();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C06_Country"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public C06_Country()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="C06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Country_IDProperty, dr.GetInt32("Country_ID"));
            LoadProperty(Country_NameProperty, dr.GetString("Country_Name"));
            LoadProperty(ParentSubContinentIDProperty, dr.GetInt32("Parent_SubContinent_ID"));
            _rowVersion = dr.GetValue("RowVersion") as byte[];
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(C07_Country_SingleObjectProperty, C07_Country_Child.GetC07_Country_Child(Country_ID));
            LoadProperty(C07_Country_ASingleObjectProperty, C07_Country_ReChild.GetC07_Country_ReChild(Country_ID));
            LoadProperty(C07_RegionObjectsProperty, C07_RegionColl.GetC07_RegionColl(Country_ID));
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
