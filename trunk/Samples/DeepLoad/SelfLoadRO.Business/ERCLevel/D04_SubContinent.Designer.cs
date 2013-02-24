using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D04_SubContinent (read only object).<br/>
    /// This is a generated base class of <see cref="D04_SubContinent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="D05_CountryObjects"/> of type <see cref="D05_CountryColl"/> (1:M relation to <see cref="D06_Country"/>)<br/>
    /// This class is an item of <see cref="D03_SubContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D04_SubContinent : ReadOnlyBase<D04_SubContinent>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SubContinent_IDProperty = RegisterProperty<int>(p => p.SubContinent_ID, "SubContinents ID", -1);
        /// <summary>
        /// Gets the SubContinents ID.
        /// </summary>
        /// <value>The SubContinents ID.</value>
        public int SubContinent_ID
        {
            get { return GetProperty(SubContinent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_NameProperty = RegisterProperty<string>(p => p.SubContinent_Name, "SubContinents Name");
        /// <summary>
        /// Gets the SubContinents Name.
        /// </summary>
        /// <value>The SubContinents Name.</value>
        public string SubContinent_Name
        {
            get { return GetProperty(SubContinent_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D05_SubContinent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D05_SubContinent_Child> D05_SubContinent_SingleObjectProperty = RegisterProperty<D05_SubContinent_Child>(p => p.D05_SubContinent_SingleObject, "D05 SubContinent Single Object");
        /// <summary>
        /// Gets the D05 Sub Continent Single Object ("self load" child property).
        /// </summary>
        /// <value>The D05 Sub Continent Single Object.</value>
        public D05_SubContinent_Child D05_SubContinent_SingleObject
        {
            get { return GetProperty(D05_SubContinent_SingleObjectProperty); }
            private set { LoadProperty(D05_SubContinent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D05_SubContinent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D05_SubContinent_ReChild> D05_SubContinent_ASingleObjectProperty = RegisterProperty<D05_SubContinent_ReChild>(p => p.D05_SubContinent_ASingleObject, "D05 SubContinent ASingle Object");
        /// <summary>
        /// Gets the D05 Sub Continent ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The D05 Sub Continent ASingle Object.</value>
        public D05_SubContinent_ReChild D05_SubContinent_ASingleObject
        {
            get { return GetProperty(D05_SubContinent_ASingleObjectProperty); }
            private set { LoadProperty(D05_SubContinent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D05_CountryObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<D05_CountryColl> D05_CountryObjectsProperty = RegisterProperty<D05_CountryColl>(p => p.D05_CountryObjects, "D05 Country Objects");
        /// <summary>
        /// Gets the D05 Country Objects ("self load" child property).
        /// </summary>
        /// <value>The D05 Country Objects.</value>
        public D05_CountryColl D05_CountryObjects
        {
            get { return GetProperty(D05_CountryObjectsProperty); }
            private set { LoadProperty(D05_CountryObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D04_SubContinent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="D04_SubContinent"/> object.</returns>
        internal static D04_SubContinent GetD04_SubContinent(SafeDataReader dr)
        {
            D04_SubContinent obj = new D04_SubContinent();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D04_SubContinent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private D04_SubContinent()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="D04_SubContinent"/> object from the given SafeDataReader.
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
            LoadProperty(D05_SubContinent_SingleObjectProperty, D05_SubContinent_Child.GetD05_SubContinent_Child(SubContinent_ID));
            LoadProperty(D05_SubContinent_ASingleObjectProperty, D05_SubContinent_ReChild.GetD05_SubContinent_ReChild(SubContinent_ID));
            LoadProperty(D05_CountryObjectsProperty, D05_CountryColl.GetD05_CountryColl(SubContinent_ID));
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
