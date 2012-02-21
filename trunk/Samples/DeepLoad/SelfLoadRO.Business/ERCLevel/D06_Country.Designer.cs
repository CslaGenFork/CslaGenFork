using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D06_Country (read only object).<br/>
    /// This is a generated base class of <see cref="D06_Country"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="D07_RegionObjects"/> of type <see cref="D07_RegionColl"/> (1:M relation to <see cref="D08_Region"/>)<br/>
    /// This class is an item of <see cref="D05_CountryColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D06_Country : ReadOnlyBase<D06_Country>
    {

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
        /// Maintains metadata about child <see cref="D07_Country_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D07_Country_Child> D07_Country_SingleObjectProperty = RegisterProperty<D07_Country_Child>(p => p.D07_Country_SingleObject, "D07 Country Single Object");
        /// <summary>
        /// Gets the D07 Country Single Object ("self load" child property).
        /// </summary>
        /// <value>The D07 Country Single Object.</value>
        public D07_Country_Child D07_Country_SingleObject
        {
            get { return GetProperty(D07_Country_SingleObjectProperty); }
            private set { LoadProperty(D07_Country_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D07_Country_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D07_Country_ReChild> D07_Country_ASingleObjectProperty = RegisterProperty<D07_Country_ReChild>(p => p.D07_Country_ASingleObject, "D07 Country ASingle Object");
        /// <summary>
        /// Gets the D07 Country ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The D07 Country ASingle Object.</value>
        public D07_Country_ReChild D07_Country_ASingleObject
        {
            get { return GetProperty(D07_Country_ASingleObjectProperty); }
            private set { LoadProperty(D07_Country_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D07_RegionObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<D07_RegionColl> D07_RegionObjectsProperty = RegisterProperty<D07_RegionColl>(p => p.D07_RegionObjects, "D07 Region Objects");
        /// <summary>
        /// Gets the D07 Region Objects ("self load" child property).
        /// </summary>
        /// <value>The D07 Region Objects.</value>
        public D07_RegionColl D07_RegionObjects
        {
            get { return GetProperty(D07_RegionObjectsProperty); }
            private set { LoadProperty(D07_RegionObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="D06_Country"/> object.</returns>
        internal static D06_Country GetD06_Country(SafeDataReader dr)
        {
            D06_Country obj = new D06_Country();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D06_Country"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D06_Country()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="D06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Country_IDProperty, dr.GetInt32("Country_ID"));
            LoadProperty(Country_NameProperty, dr.GetString("Country_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(D07_Country_SingleObjectProperty, D07_Country_Child.GetD07_Country_Child(Country_ID));
            LoadProperty(D07_Country_ASingleObjectProperty, D07_Country_ReChild.GetD07_Country_ReChild(Country_ID));
            LoadProperty(D07_RegionObjectsProperty, D07_RegionColl.GetD07_RegionColl(Country_ID));
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
