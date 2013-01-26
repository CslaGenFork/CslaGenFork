using System;
using System.Data;
using Csla;
using Csla.Data;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A04_SubContinent (read only object).<br/>
    /// This is a generated base class of <see cref="A04_SubContinent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="A05_CountryObjects"/> of type <see cref="A05_CountryColl"/> (1:M relation to <see cref="A06_Country"/>)<br/>
    /// This class is an item of <see cref="A03_SubContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class A04_SubContinent : ReadOnlyBase<A04_SubContinent>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> SubContinent_IDProperty = RegisterProperty<int>(p => p.SubContinent_ID, "Sub Continent ID", -1);
        /// <summary>
        /// Gets the Sub Continent ID.
        /// </summary>
        /// <value>The Sub Continent ID.</value>
        public int SubContinent_ID
        {
            get { return GetProperty(SubContinent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="SubContinent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> SubContinent_NameProperty = RegisterProperty<string>(p => p.SubContinent_Name, "Sub Continent Name");
        /// <summary>
        /// Gets the Sub Continent Name.
        /// </summary>
        /// <value>The Sub Continent Name.</value>
        public string SubContinent_Name
        {
            get { return GetProperty(SubContinent_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A05_SubContinent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A05_SubContinent_Child> A05_SubContinent_SingleObjectProperty = RegisterProperty<A05_SubContinent_Child>(p => p.A05_SubContinent_SingleObject, "A05 SubContinent Single Object");
        /// <summary>
        /// Gets the A05 Sub Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The A05 Sub Continent Single Object.</value>
        public A05_SubContinent_Child A05_SubContinent_SingleObject
        {
            get { return GetProperty(A05_SubContinent_SingleObjectProperty); }
            private set { LoadProperty(A05_SubContinent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A05_SubContinent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A05_SubContinent_ReChild> A05_SubContinent_ASingleObjectProperty = RegisterProperty<A05_SubContinent_ReChild>(p => p.A05_SubContinent_ASingleObject, "A05 SubContinent ASingle Object");
        /// <summary>
        /// Gets the A05 Sub Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The A05 Sub Continent ASingle Object.</value>
        public A05_SubContinent_ReChild A05_SubContinent_ASingleObject
        {
            get { return GetProperty(A05_SubContinent_ASingleObjectProperty); }
            private set { LoadProperty(A05_SubContinent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A05_CountryObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<A05_CountryColl> A05_CountryObjectsProperty = RegisterProperty<A05_CountryColl>(p => p.A05_CountryObjects, "A05 Country Objects");
        /// <summary>
        /// Gets the A05 Country Objects ("parent load" child property).
        /// </summary>
        /// <value>The A05 Country Objects.</value>
        public A05_CountryColl A05_CountryObjects
        {
            get { return GetProperty(A05_CountryObjectsProperty); }
            private set { LoadProperty(A05_CountryObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A04_SubContinent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="A04_SubContinent"/> object.</returns>
        internal static A04_SubContinent GetA04_SubContinent(SafeDataReader dr)
        {
            A04_SubContinent obj = new A04_SubContinent();
            obj.Fetch(dr);
            obj.LoadProperty(A05_CountryObjectsProperty, new A05_CountryColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A04_SubContinent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A04_SubContinent()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="A04_SubContinent"/> object from the given SafeDataReader.
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
        /// Loads child <see cref="A05_SubContinent_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A05_SubContinent_Child child)
        {
            LoadProperty(A05_SubContinent_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="A05_SubContinent_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(A05_SubContinent_ReChild child)
        {
            LoadProperty(A05_SubContinent_ASingleObjectProperty, child);
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
