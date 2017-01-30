using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G06_Country (read only object).<br/>
    /// This is a generated base class of <see cref="G06_Country"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="G07_RegionObjects"/> of type <see cref="G07_RegionColl"/> (1:M relation to <see cref="G08_Region"/>)<br/>
    /// This class is an item of <see cref="G05_CountryColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G06_Country : ReadOnlyBase<G06_Country>
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
        /// Maintains metadata about child <see cref="G07_Country_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G07_Country_Child> G07_Country_SingleObjectProperty = RegisterProperty<G07_Country_Child>(p => p.G07_Country_SingleObject, "G07 Country Single Object");
        /// <summary>
        /// Gets the G07 Country Single Object ("self load" child property).
        /// </summary>
        /// <value>The G07 Country Single Object.</value>
        public G07_Country_Child G07_Country_SingleObject
        {
            get { return GetProperty(G07_Country_SingleObjectProperty); }
            private set { LoadProperty(G07_Country_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G07_Country_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G07_Country_ReChild> G07_Country_ASingleObjectProperty = RegisterProperty<G07_Country_ReChild>(p => p.G07_Country_ASingleObject, "G07 Country ASingle Object");
        /// <summary>
        /// Gets the G07 Country ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The G07 Country ASingle Object.</value>
        public G07_Country_ReChild G07_Country_ASingleObject
        {
            get { return GetProperty(G07_Country_ASingleObjectProperty); }
            private set { LoadProperty(G07_Country_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G07_RegionObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<G07_RegionColl> G07_RegionObjectsProperty = RegisterProperty<G07_RegionColl>(p => p.G07_RegionObjects, "G07 Region Objects");
        /// <summary>
        /// Gets the G07 Region Objects ("self load" child property).
        /// </summary>
        /// <value>The G07 Region Objects.</value>
        public G07_RegionColl G07_RegionObjects
        {
            get { return GetProperty(G07_RegionObjectsProperty); }
            private set { LoadProperty(G07_RegionObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G06_Country"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="G06_Country"/> object.</returns>
        internal static G06_Country GetG06_Country(SafeDataReader dr)
        {
            G06_Country obj = new G06_Country();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G06_Country"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public G06_Country()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G06_Country"/> object from the given SafeDataReader.
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
            LoadProperty(G07_Country_SingleObjectProperty, G07_Country_Child.GetG07_Country_Child(Country_ID));
            LoadProperty(G07_Country_ASingleObjectProperty, G07_Country_ReChild.GetG07_Country_ReChild(Country_ID));
            LoadProperty(G07_RegionObjectsProperty, G07_RegionColl.GetG07_RegionColl(Country_ID));
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
