using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F04_SubContinent (read only object).<br/>
    /// This is a generated base class of <see cref="F04_SubContinent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="F05_CountryObjects"/> of type <see cref="F05_CountryColl"/> (1:M relation to <see cref="F06_Country"/>)<br/>
    /// This class is an item of <see cref="F03_SubContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F04_SubContinent : ReadOnlyBase<F04_SubContinent>
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
        /// Maintains metadata about child <see cref="F05_SubContinent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F05_SubContinent_Child> F05_SubContinent_SingleObjectProperty = RegisterProperty<F05_SubContinent_Child>(p => p.F05_SubContinent_SingleObject, "F05 SubContinent Single Object");
        /// <summary>
        /// Gets the F05 Sub Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The F05 Sub Continent Single Object.</value>
        public F05_SubContinent_Child F05_SubContinent_SingleObject
        {
            get { return GetProperty(F05_SubContinent_SingleObjectProperty); }
            private set { LoadProperty(F05_SubContinent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F05_SubContinent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F05_SubContinent_ReChild> F05_SubContinent_ASingleObjectProperty = RegisterProperty<F05_SubContinent_ReChild>(p => p.F05_SubContinent_ASingleObject, "F05 SubContinent ASingle Object");
        /// <summary>
        /// Gets the F05 Sub Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The F05 Sub Continent ASingle Object.</value>
        public F05_SubContinent_ReChild F05_SubContinent_ASingleObject
        {
            get { return GetProperty(F05_SubContinent_ASingleObjectProperty); }
            private set { LoadProperty(F05_SubContinent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F05_CountryObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<F05_CountryColl> F05_CountryObjectsProperty = RegisterProperty<F05_CountryColl>(p => p.F05_CountryObjects, "F05 Country Objects");
        /// <summary>
        /// Gets the F05 Country Objects ("parent load" child property).
        /// </summary>
        /// <value>The F05 Country Objects.</value>
        public F05_CountryColl F05_CountryObjects
        {
            get { return GetProperty(F05_CountryObjectsProperty); }
            private set { LoadProperty(F05_CountryObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F04_SubContinent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F04_SubContinent"/> object.</returns>
        internal static F04_SubContinent GetF04_SubContinent(SafeDataReader dr)
        {
            F04_SubContinent obj = new F04_SubContinent();
            obj.Fetch(dr);
            obj.LoadProperty(F05_CountryObjectsProperty, new F05_CountryColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F04_SubContinent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public F04_SubContinent()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F04_SubContinent"/> object from the given SafeDataReader.
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
        /// Loads child <see cref="F05_SubContinent_Child"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F05_SubContinent_Child child)
        {
            LoadProperty(F05_SubContinent_SingleObjectProperty, child);
        }

        /// <summary>
        /// Loads child <see cref="F05_SubContinent_ReChild"/> object.
        /// </summary>
        /// <param name="child">The child object to load.</param>
        internal void LoadChild(F05_SubContinent_ReChild child)
        {
            LoadProperty(F05_SubContinent_ASingleObjectProperty, child);
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
