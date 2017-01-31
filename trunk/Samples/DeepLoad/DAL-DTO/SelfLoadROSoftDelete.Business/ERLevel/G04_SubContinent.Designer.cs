using System;
using Csla;
using SelfLoadROSoftDelete.DataAccess.ERLevel;

namespace SelfLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// G04_SubContinent (read only object).<br/>
    /// This is a generated base class of <see cref="G04_SubContinent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="G05_CountryObjects"/> of type <see cref="G05_CountryColl"/> (1:M relation to <see cref="G06_Country"/>)<br/>
    /// This class is an item of <see cref="G03_SubContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class G04_SubContinent : ReadOnlyBase<G04_SubContinent>
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
        /// Maintains metadata about child <see cref="G05_SubContinent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G05_SubContinent_Child> G05_SubContinent_SingleObjectProperty = RegisterProperty<G05_SubContinent_Child>(p => p.G05_SubContinent_SingleObject, "G05 SubContinent Single Object");
        /// <summary>
        /// Gets the G05 Sub Continent Single Object ("self load" child property).
        /// </summary>
        /// <value>The G05 Sub Continent Single Object.</value>
        public G05_SubContinent_Child G05_SubContinent_SingleObject
        {
            get { return GetProperty(G05_SubContinent_SingleObjectProperty); }
            private set { LoadProperty(G05_SubContinent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G05_SubContinent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<G05_SubContinent_ReChild> G05_SubContinent_ASingleObjectProperty = RegisterProperty<G05_SubContinent_ReChild>(p => p.G05_SubContinent_ASingleObject, "G05 SubContinent ASingle Object");
        /// <summary>
        /// Gets the G05 Sub Continent ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The G05 Sub Continent ASingle Object.</value>
        public G05_SubContinent_ReChild G05_SubContinent_ASingleObject
        {
            get { return GetProperty(G05_SubContinent_ASingleObjectProperty); }
            private set { LoadProperty(G05_SubContinent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="G05_CountryObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<G05_CountryColl> G05_CountryObjectsProperty = RegisterProperty<G05_CountryColl>(p => p.G05_CountryObjects, "G05 Country Objects");
        /// <summary>
        /// Gets the G05 Country Objects ("self load" child property).
        /// </summary>
        /// <value>The G05 Country Objects.</value>
        public G05_CountryColl G05_CountryObjects
        {
            get { return GetProperty(G05_CountryObjectsProperty); }
            private set { LoadProperty(G05_CountryObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="G04_SubContinent"/> object from the given G04_SubContinentDto.
        /// </summary>
        /// <param name="data">The <see cref="G04_SubContinentDto"/>.</param>
        /// <returns>A reference to the fetched <see cref="G04_SubContinent"/> object.</returns>
        internal static G04_SubContinent GetG04_SubContinent(G04_SubContinentDto data)
        {
            G04_SubContinent obj = new G04_SubContinent();
            obj.Fetch(data);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="G04_SubContinent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public G04_SubContinent()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="G04_SubContinent"/> object from the given <see cref="G04_SubContinentDto"/>.
        /// </summary>
        /// <param name="data">The G04_SubContinentDto to use.</param>
        private void Fetch(G04_SubContinentDto data)
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
            LoadProperty(G05_SubContinent_SingleObjectProperty, G05_SubContinent_Child.GetG05_SubContinent_Child(SubContinent_ID));
            LoadProperty(G05_SubContinent_ASingleObjectProperty, G05_SubContinent_ReChild.GetG05_SubContinent_ReChild(SubContinent_ID));
            LoadProperty(G05_CountryObjectsProperty, G05_CountryColl.GetG05_CountryColl(SubContinent_ID));
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
