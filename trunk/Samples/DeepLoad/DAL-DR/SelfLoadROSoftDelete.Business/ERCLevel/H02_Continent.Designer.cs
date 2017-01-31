using System;
using System.Data;
using Csla;
using Csla.Data;

namespace SelfLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// H02_Continent (read only object).<br/>
    /// This is a generated base class of <see cref="H02_Continent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="H03_SubContinentObjects"/> of type <see cref="H03_SubContinentColl"/> (1:M relation to <see cref="H04_SubContinent"/>)<br/>
    /// This class is an item of <see cref="H01_ContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class H02_Continent : ReadOnlyBase<H02_Continent>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Continent_IDProperty = RegisterProperty<int>(p => p.Continent_ID, "Continents ID", -1);
        /// <summary>
        /// Gets the Continents ID.
        /// </summary>
        /// <value>The Continents ID.</value>
        public int Continent_ID
        {
            get { return GetProperty(Continent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_NameProperty = RegisterProperty<string>(p => p.Continent_Name, "Continents Name");
        /// <summary>
        /// Gets the Continents Name.
        /// </summary>
        /// <value>The Continents Name.</value>
        public string Continent_Name
        {
            get { return GetProperty(Continent_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H03_Continent_Child> H03_Continent_SingleObjectProperty = RegisterProperty<H03_Continent_Child>(p => p.H03_Continent_SingleObject, "H03 Continent Single Object");
        /// <summary>
        /// Gets the H03 Continent Single Object ("self load" child property).
        /// </summary>
        /// <value>The H03 Continent Single Object.</value>
        public H03_Continent_Child H03_Continent_SingleObject
        {
            get { return GetProperty(H03_Continent_SingleObjectProperty); }
            private set { LoadProperty(H03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<H03_Continent_ReChild> H03_Continent_ASingleObjectProperty = RegisterProperty<H03_Continent_ReChild>(p => p.H03_Continent_ASingleObject, "H03 Continent ASingle Object");
        /// <summary>
        /// Gets the H03 Continent ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The H03 Continent ASingle Object.</value>
        public H03_Continent_ReChild H03_Continent_ASingleObject
        {
            get { return GetProperty(H03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(H03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="H03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<H03_SubContinentColl> H03_SubContinentObjectsProperty = RegisterProperty<H03_SubContinentColl>(p => p.H03_SubContinentObjects, "H03 SubContinent Objects");
        /// <summary>
        /// Gets the H03 Sub Continent Objects ("self load" child property).
        /// </summary>
        /// <value>The H03 Sub Continent Objects.</value>
        public H03_SubContinentColl H03_SubContinentObjects
        {
            get { return GetProperty(H03_SubContinentObjectsProperty); }
            private set { LoadProperty(H03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="H02_Continent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="H02_Continent"/> object.</returns>
        internal static H02_Continent GetH02_Continent(SafeDataReader dr)
        {
            H02_Continent obj = new H02_Continent();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="H02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public H02_Continent()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="H02_Continent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void Fetch(SafeDataReader dr)
        {
            // Value properties
            LoadProperty(Continent_IDProperty, dr.GetInt32("Continent_ID"));
            LoadProperty(Continent_NameProperty, dr.GetString("Continent_Name"));
            var args = new DataPortalHookArgs(dr);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(H03_Continent_SingleObjectProperty, H03_Continent_Child.GetH03_Continent_Child(Continent_ID));
            LoadProperty(H03_Continent_ASingleObjectProperty, H03_Continent_ReChild.GetH03_Continent_ReChild(Continent_ID));
            LoadProperty(H03_SubContinentObjectsProperty, H03_SubContinentColl.GetH03_SubContinentColl(Continent_ID));
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
