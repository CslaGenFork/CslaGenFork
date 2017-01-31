using System;
using System.Data;
using Csla;
using Csla.Data;

namespace SelfLoadRO.Business.ERCLevel
{

    /// <summary>
    /// D02_Continent (read only object).<br/>
    /// This is a generated base class of <see cref="D02_Continent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="D03_SubContinentObjects"/> of type <see cref="D03_SubContinentColl"/> (1:M relation to <see cref="D04_SubContinent"/>)<br/>
    /// This class is an item of <see cref="D01_ContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class D02_Continent : ReadOnlyBase<D02_Continent>
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
        /// Maintains metadata about child <see cref="D03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D03_Continent_Child> D03_Continent_SingleObjectProperty = RegisterProperty<D03_Continent_Child>(p => p.D03_Continent_SingleObject, "D03 Continent Single Object");
        /// <summary>
        /// Gets the D03 Continent Single Object ("self load" child property).
        /// </summary>
        /// <value>The D03 Continent Single Object.</value>
        public D03_Continent_Child D03_Continent_SingleObject
        {
            get { return GetProperty(D03_Continent_SingleObjectProperty); }
            private set { LoadProperty(D03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<D03_Continent_ReChild> D03_Continent_ASingleObjectProperty = RegisterProperty<D03_Continent_ReChild>(p => p.D03_Continent_ASingleObject, "D03 Continent ASingle Object");
        /// <summary>
        /// Gets the D03 Continent ASingle Object ("self load" child property).
        /// </summary>
        /// <value>The D03 Continent ASingle Object.</value>
        public D03_Continent_ReChild D03_Continent_ASingleObject
        {
            get { return GetProperty(D03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(D03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="D03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<D03_SubContinentColl> D03_SubContinentObjectsProperty = RegisterProperty<D03_SubContinentColl>(p => p.D03_SubContinentObjects, "D03 SubContinent Objects");
        /// <summary>
        /// Gets the D03 Sub Continent Objects ("self load" child property).
        /// </summary>
        /// <value>The D03 Sub Continent Objects.</value>
        public D03_SubContinentColl D03_SubContinentObjects
        {
            get { return GetProperty(D03_SubContinentObjectsProperty); }
            private set { LoadProperty(D03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="D02_Continent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="D02_Continent"/> object.</returns>
        internal static D02_Continent GetD02_Continent(SafeDataReader dr)
        {
            D02_Continent obj = new D02_Continent();
            obj.Fetch(dr);
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="D02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public D02_Continent()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="D02_Continent"/> object from the given SafeDataReader.
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
            LoadProperty(D03_Continent_SingleObjectProperty, D03_Continent_Child.GetD03_Continent_Child(Continent_ID));
            LoadProperty(D03_Continent_ASingleObjectProperty, D03_Continent_ReChild.GetD03_Continent_ReChild(Continent_ID));
            LoadProperty(D03_SubContinentObjectsProperty, D03_SubContinentColl.GetD03_SubContinentColl(Continent_ID));
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
