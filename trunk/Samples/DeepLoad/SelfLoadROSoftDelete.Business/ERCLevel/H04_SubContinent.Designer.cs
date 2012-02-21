using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H04_SubContinent (read only object).<br/>
    /// This is a generated base class of <see cref="H04_SubContinent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="H05_CountryObjects"/> of type <see cref="H05_CountryColl"/> (1:M relation to <see cref="H06_Country"/>)<br/>
    /// This class is an item of <see cref="H03_SubContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H04_SubContinent : ReadOnlyBase<H04_SubContinent>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SubContinent_IDProperty = RegisterProperty<int>(p => p.SubContinent_ID, "2_SubContinents ID", -1);
        /// <summary>
        /// Gets the 2_SubContinents ID.
        /// </summary>
        /// <value>The 2_SubContinents ID.</value>
        public int SubContinent_ID
        {
            get { return GetProperty(SubContinent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_NameProperty = RegisterProperty<string>(p => p.SubContinent_Name, "2_SubContinents Name");
        /// <summary>
        /// Gets the 2_SubContinents Name.
        /// </summary>
        /// <value>The 2_SubContinents Name.</value>
        public string SubContinent_Name
        {
            get { return GetProperty(SubContinent_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H05_SubContinent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H05_SubContinent_Child> H05_SubContinent_SingleObjectProperty = RegisterProperty<H05_SubContinent_Child>(p => p.H05_SubContinent_SingleObject, "H05 SubContinent Single Object");
        /// <summary>
        /// Gets the H05 Sub Continent Single Object ("self load" child property).
        /// </summary>
        /// <value>The H05 Sub Continent Single Object.</value>
        public H05_SubContinent_Child H05_SubContinent_SingleObject
        {
            get { return GetProperty(H05_SubContinent_SingleObjectProperty); }
            private set { LoadProperty(H05_SubContinent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H05_SubContinent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H05_SubContinent_ReChild> H05_SubContinent_ASingleObjectProperty = RegisterProperty<H05_SubContinent_ReChild>(p => p.H05_SubContinent_ASingleObject, "H05 SubContinent ASingle Object");
        /// <summary>
        /// Gets the H05 Sub Continent ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The H05 Sub Continent ASingle Object.</value>
        public H05_SubContinent_ReChild H05_SubContinent_ASingleObject
        {
            get { return GetProperty(H05_SubContinent_ASingleObjectProperty); }
            private set { LoadProperty(H05_SubContinent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H05_CountryObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<H05_CountryColl> H05_CountryObjectsProperty = RegisterProperty<H05_CountryColl>(p => p.H05_CountryObjects, "H05 Country Objects");
        /// <summary>
        /// Gets the H05 Country Objects ("self load" child property).
        /// </summary>
        /// <value>The H05 Country Objects.</value>
        public H05_CountryColl H05_CountryObjects
        {
            get { return GetProperty(H05_CountryObjectsProperty); }
            private set { LoadProperty(H05_CountryObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H04_SubContinent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="H04_SubContinent"/> object.</returns>
        internal static H04_SubContinent GetH04_SubContinent(SafeDataReader dr)
        {
            H04_SubContinent obj = new H04_SubContinent();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H04_SubContinent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private H04_SubContinent()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="H04_SubContinent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(SubContinent_IDProperty, dr.GetInt32("SubContinent_ID"));
            LoadProperty(SubContinent_NameProperty, dr.GetString("SubContinent_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(H05_SubContinent_SingleObjectProperty, H05_SubContinent_Child.GetH05_SubContinent_Child(SubContinent_ID));
            LoadProperty(H05_SubContinent_ASingleObjectProperty, H05_SubContinent_ReChild.GetH05_SubContinent_ReChild(SubContinent_ID));
            LoadProperty(H05_CountryObjectsProperty, H05_CountryColl.GetH05_CountryColl(SubContinent_ID));
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
