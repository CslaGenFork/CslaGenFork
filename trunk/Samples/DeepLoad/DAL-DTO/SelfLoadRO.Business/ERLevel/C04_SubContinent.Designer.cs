using System;
using Csla;
using SelfLoadRO.DataAccess.ERLevel;

namespace SelfLoadRO.Business.ERLevel
{

    /// <summary>
    /// C04_SubContinent (read only object).<br/>
    /// This is a generated base class of <see cref="C04_SubContinent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="C05_CountryObjects"/> of type <see cref="C05_CountryColl"/> (1:M relation to <see cref="C06_Country"/>)<br/>
    /// This class is an item of <see cref="C03_SubContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class C04_SubContinent : ReadOnlyBase<C04_SubContinent>
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
        /// Maintains metadata about child <see cref="C05_SubContinent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C05_SubContinent_Child> C05_SubContinent_SingleObjectProperty = RegisterProperty<C05_SubContinent_Child>(p => p.C05_SubContinent_SingleObject, "C05 SubContinent Single Object");
        /// <summary>
        /// Gets the C05 Sub Continent Single Object ("self load" child property).
        /// </summary>
        /// <value>The C05 Sub Continent Single Object.</value>
        public C05_SubContinent_Child C05_SubContinent_SingleObject
        {
            get { return GetProperty(C05_SubContinent_SingleObjectProperty); }
            private set { LoadProperty(C05_SubContinent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C05_SubContinent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<C05_SubContinent_ReChild> C05_SubContinent_ASingleObjectProperty = RegisterProperty<C05_SubContinent_ReChild>(p => p.C05_SubContinent_ASingleObject, "C05 SubContinent ASingle Object");
        /// <summary>
        /// Gets the C05 Sub Continent ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The C05 Sub Continent ASingle Object.</value>
        public C05_SubContinent_ReChild C05_SubContinent_ASingleObject
        {
            get { return GetProperty(C05_SubContinent_ASingleObjectProperty); }
            private set { LoadProperty(C05_SubContinent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="C05_CountryObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<C05_CountryColl> C05_CountryObjectsProperty = RegisterProperty<C05_CountryColl>(p => p.C05_CountryObjects, "C05 Country Objects");
        /// <summary>
        /// Gets the C05 Country Objects ("self load" child property).
        /// </summary>
        /// <value>The C05 Country Objects.</value>
        public C05_CountryColl C05_CountryObjects
        {
            get { return GetProperty(C05_CountryObjectsProperty); }
            private set { LoadProperty(C05_CountryObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="C04_SubContinent"/> object from the given C04_SubContinentDto.
        /// </summary>
        /// <param name="data">The <see cref="C04_SubContinentDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="C04_SubContinent"/> object.</returns>
        internal static C04_SubContinent GetC04_SubContinent(C04_SubContinentDto data)
        {
            C04_SubContinent obj = new C04_SubContinent();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="C04_SubContinent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public C04_SubContinent()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="C04_SubContinent"/> object from the given <see cref="C04_SubContinentDto"/>.
        /// </summary>
        /// <param name="data">The C04_SubContinentDto to use.</param>
        private void Fetch(C04_SubContinentDto data)
        {
            // Value properties
            LoadProperty(SubContinent_IDProperty, data.SubContinent_ID);
            LoadProperty(SubContinent_NameProperty, data.SubContinent_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects.
        /// </summary>
        internal void FetchChildren()
        {
            LoadProperty(C05_SubContinent_SingleObjectProperty, C05_SubContinent_Child.GetC05_SubContinent_Child(SubContinent_ID));
            LoadProperty(C05_SubContinent_ASingleObjectProperty, C05_SubContinent_ReChild.GetC05_SubContinent_ReChild(SubContinent_ID));
            LoadProperty(C05_CountryObjectsProperty, C05_CountryColl.GetC05_CountryColl(SubContinent_ID));
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
