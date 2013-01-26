using System;
using Csla;
using ParentLoadROSoftDelete.DataAccess.ERLevel;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E04_SubContinent (read only object).<br/>
    /// This is a generated base class of <see cref="E04_SubContinent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="E05_CountryObjects"/> of type <see cref="E05_CountryColl"/> (1:M relation to <see cref="E06_Country"/>)<br/>
    /// This class is an item of <see cref="E03_SubContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class E04_SubContinent : ReadOnlyBase<E04_SubContinent>
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
        /// Maintains metadata about child <see cref="E05_SubContinent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E05_SubContinent_Child> E05_SubContinent_SingleObjectProperty = RegisterProperty<E05_SubContinent_Child>(p => p.E05_SubContinent_SingleObject, "E05 SubContinent Single Object");
        /// <summary>
        /// Gets the E05 Sub Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The E05 Sub Continent Single Object.</value>
        public E05_SubContinent_Child E05_SubContinent_SingleObject
        {
            get { return GetProperty(E05_SubContinent_SingleObjectProperty); }
            private set { LoadProperty(E05_SubContinent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E05_SubContinent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E05_SubContinent_ReChild> E05_SubContinent_ASingleObjectProperty = RegisterProperty<E05_SubContinent_ReChild>(p => p.E05_SubContinent_ASingleObject, "E05 SubContinent ASingle Object");
        /// <summary>
        /// Gets the E05 Sub Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The E05 Sub Continent ASingle Object.</value>
        public E05_SubContinent_ReChild E05_SubContinent_ASingleObject
        {
            get { return GetProperty(E05_SubContinent_ASingleObjectProperty); }
            private set { LoadProperty(E05_SubContinent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E05_CountryObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<E05_CountryColl> E05_CountryObjectsProperty = RegisterProperty<E05_CountryColl>(p => p.E05_CountryObjects, "E05 Country Objects");
        /// <summary>
        /// Gets the E05 Country Objects ("parent load" child property).
        /// </summary>
        /// <value>The E05 Country Objects.</value>
        public E05_CountryColl E05_CountryObjects
        {
            get { return GetProperty(E05_CountryObjectsProperty); }
            private set { LoadProperty(E05_CountryObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E04_SubContinent"/> object from the given E04_SubContinentDto.
        /// </summary>
        /// <param name="data">The <see cref="E04_SubContinentDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="E04_SubContinent"/> object.</returns>
        internal static E04_SubContinent GetE04_SubContinent(E04_SubContinentDto data)
        {
            E04_SubContinent obj = new E04_SubContinent();
            obj.Fetch(data);
            obj.LoadProperty(E05_CountryObjectsProperty, new E05_CountryColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E04_SubContinent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private E04_SubContinent()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E04_SubContinent"/> object from the given <see cref="E04_SubContinentDto"/>.
        /// </summary>
        /// <param name="data">The E04_SubContinentDto to use.</param>
        private void Fetch(E04_SubContinentDto data)
        {
            // Value properties
            LoadProperty(SubContinent_IDProperty, data.SubContinent_ID);
            LoadProperty(SubContinent_NameProperty, data.SubContinent_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child <see cref="E05_SubContinent_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E05_SubContinent_Child child)
        {
            LoadProperty(E05_SubContinent_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="E05_SubContinent_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(E05_SubContinent_ReChild child)
        {
            LoadProperty(E05_SubContinent_ASingleObjectProperty, child);
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
