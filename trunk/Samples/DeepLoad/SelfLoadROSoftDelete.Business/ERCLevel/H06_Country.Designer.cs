using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H06_Country (read only object).<br/>
    /// This is a generated base class of <see cref="H06_Country"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="H07_RegionObjects"/> of type <see cref="H07_RegionColl"/> (1:M relation to <see cref="H08_Region"/>)<br/>
    /// This class is an item of <see cref="H05_CountryColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H06_Country : ReadOnlyBase<H06_Country>
    {

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
        /// Maintains metadata about child <see cref="H07_Country_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H07_Country_Child> H07_Country_SingleObjectProperty = RegisterProperty<H07_Country_Child>(p => p.H07_Country_SingleObject, "H07 Country Single Object");
        /// <summary>
        /// Gets the H07 Country Single Object ("self load" child property).
        /// </summary>
        /// <value>The H07 Country Single Object.</value>
        public H07_Country_Child H07_Country_SingleObject
        {
            get { return GetProperty(H07_Country_SingleObjectProperty); }
            private set { LoadProperty(H07_Country_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H07_Country_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H07_Country_ReChild> H07_Country_ASingleObjectProperty = RegisterProperty<H07_Country_ReChild>(p => p.H07_Country_ASingleObject, "H07 Country ASingle Object");
        /// <summary>
        /// Gets the H07 Country ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The H07 Country ASingle Object.</value>
        public H07_Country_ReChild H07_Country_ASingleObject
        {
            get { return GetProperty(H07_Country_ASingleObjectProperty); }
            private set { LoadProperty(H07_Country_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H07_RegionObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<H07_RegionColl> H07_RegionObjectsProperty = RegisterProperty<H07_RegionColl>(p => p.H07_RegionObjects, "H07 Region Objects");
        /// <summary>
        /// Gets the H07 Region Objects ("self load" child property).
        /// </summary>
        /// <value>The H07 Region Objects.</value>
        public H07_RegionColl H07_RegionObjects
        {
            get { return GetProperty(H07_RegionObjectsProperty); }
            private set { LoadProperty(H07_RegionObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="H06_Country"/> object.</returns>
        internal static H06_Country GetH06_Country(SafeDataReader dr)
        {
            H06_Country obj = new H06_Country();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H06_Country"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H06_Country()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="H06_Country"/> object from the given SafeDataReader.
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
            LoadProperty(H07_Country_SingleObjectProperty, H07_Country_Child.GetH07_Country_Child(Country_ID));
            LoadProperty(H07_Country_ASingleObjectProperty, H07_Country_ReChild.GetH07_Country_ReChild(Country_ID));
            LoadProperty(H07_RegionObjectsProperty, H07_RegionColl.GetH07_RegionColl(Country_ID));
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
