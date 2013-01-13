using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERCLevel
{

    /// <summary>
    /// B04_SubContinent (read only object).<br/>
    /// This is a generated base class of <see cref="B04_SubContinent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="B05_CountryObjects"/> of type <see cref="B05_CountryColl"/> (1:M relation to <see cref="B06_Country"/>)<br/>
    /// This class is an item of <see cref="B03_SubContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class B04_SubContinent : ReadOnlyBase<B04_SubContinent>
    {

        #region State Fields

        [NotUndoable]
        [NonSerialized]
        internal int parent_Continent_ID = 0;

        #endregion

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
        /// Maintains metadata about child <see cref="B05_SubContinent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B05_SubContinent_Child> B05_SubContinent_SingleObjectProperty = RegisterProperty<B05_SubContinent_Child>(p => p.B05_SubContinent_SingleObject, "B05 SubContinent Single Object");
        /// <summary>
        /// Gets the B05 Sub Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The B05 Sub Continent Single Object.</value>
        public B05_SubContinent_Child B05_SubContinent_SingleObject
        {
            get { return GetProperty(B05_SubContinent_SingleObjectProperty); }
            private set { LoadProperty(B05_SubContinent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B05_SubContinent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<B05_SubContinent_ReChild> B05_SubContinent_ASingleObjectProperty = RegisterProperty<B05_SubContinent_ReChild>(p => p.B05_SubContinent_ASingleObject, "B05 SubContinent ASingle Object");
        /// <summary>
        /// Gets the B05 Sub Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The B05 Sub Continent ASingle Object.</value>
        public B05_SubContinent_ReChild B05_SubContinent_ASingleObject
        {
            get { return GetProperty(B05_SubContinent_ASingleObjectProperty); }
            private set { LoadProperty(B05_SubContinent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="B05_CountryObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<B05_CountryColl> B05_CountryObjectsProperty = RegisterProperty<B05_CountryColl>(p => p.B05_CountryObjects, "B05 Country Objects");
        /// <summary>
        /// Gets the B05 Country Objects ("parent load" child property).
        /// </summary>
        /// <value>The B05 Country Objects.</value>
        public B05_CountryColl B05_CountryObjects
        {
            get { return GetProperty(B05_CountryObjectsProperty); }
            private set { LoadProperty(B05_CountryObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="B04_SubContinent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="B04_SubContinent"/> object.</returns>
        internal static B04_SubContinent GetB04_SubContinent(SafeDataReader dr)
        {
            B04_SubContinent obj = new B04_SubContinent();
            obj.Fetch(dr);
            obj.LoadProperty(B05_CountryObjectsProperty, new B05_CountryColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="B04_SubContinent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private B04_SubContinent()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="B04_SubContinent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(SubContinent_IDProperty, dr.GetInt32("SubContinent_ID"));
            LoadProperty(SubContinent_NameProperty, dr.GetString("SubContinent_Name"));
            // parent properties
            parent_Continent_ID = dr.GetInt32("Parent_Continent_ID");
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="B05_SubContinent_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B05_SubContinent_Child child)
        {
            LoadProperty(B05_SubContinent_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="B05_SubContinent_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(B05_SubContinent_ReChild child)
        {
            LoadProperty(B05_SubContinent_ASingleObjectProperty, child);
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
