using System;
using Csla;
using ParentLoadROSoftDelete.DataAccess;
using ParentLoadROSoftDelete.DataAccess.ERLevel;

namespace ParentLoadROSoftDelete.Business.ERLevel
{

    /// <summary>
    /// E02_Continent (read only object).<br/>
    /// This is a generated base class of <see cref="E02_Continent"/> business object.
    /// This class is a root object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="E03_SubContinentObjects"/> of type <see cref="E03_SubContinentColl"/> (1:M relation to <see cref="E04_SubContinent"/>)
    /// </remarks>
    [Serializable]
    public partial class E02_Continent : ReadOnlyBase<E02_Continent>
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
        /// Maintains metadata about child <see cref="E03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E03_Continent_Child> E03_Continent_SingleObjectProperty = RegisterProperty<E03_Continent_Child>(p => p.E03_Continent_SingleObject, "E03 Continent Single Object");
        /// <summary>
        /// Gets the E03 Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The E03 Continent Single Object.</value>
        public E03_Continent_Child E03_Continent_SingleObject
        {
            get { return GetProperty(E03_Continent_SingleObjectProperty); }
            private set { LoadProperty(E03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<E03_Continent_ReChild> E03_Continent_ASingleObjectProperty = RegisterProperty<E03_Continent_ReChild>(p => p.E03_Continent_ASingleObject, "E03 Continent ASingle Object");
        /// <summary>
        /// Gets the E03 Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The E03 Continent ASingle Object.</value>
        public E03_Continent_ReChild E03_Continent_ASingleObject
        {
            get { return GetProperty(E03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(E03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="E03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<E03_SubContinentColl> E03_SubContinentObjectsProperty = RegisterProperty<E03_SubContinentColl>(p => p.E03_SubContinentObjects, "E03 SubContinent Objects");
        /// <summary>
        /// Gets the E03 Sub Continent Objects ("parent load" child property).
        /// </summary>
        /// <value>The E03 Sub Continent Objects.</value>
        public E03_SubContinentColl E03_SubContinentObjects
        {
            get { return GetProperty(E03_SubContinentObjectsProperty); }
            private set { LoadProperty(E03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="E02_Continent"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID parameter of the E02_Continent to fetch.</param>
        /// <returns>A reference to the fetched <see cref="E02_Continent"/> object.</returns>
        public static E02_Continent GetE02_Continent(int continent_ID)
        {
            return DataPortal.Fetch<E02_Continent>(continent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="E02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public E02_Continent()
        {
            // Use factory methods and do not use direct creation.
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E02_Continent"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        protected void DataPortal_Fetch(int continent_ID)
        {
            var args = new DataPortalHookArgs(continent_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactoryParentLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IE02_ContinentDal>();
                var data = dal.Fetch(continent_ID);
                Fetch(data);
                FetchChildren(dal);
            }
            OnFetchPost(args);
            // check all object rules and property rules
            BusinessRules.CheckRules();
        }

        /// <summary>
        /// Loads a <see cref="E02_Continent"/> object from the given <see cref="E02_ContinentDto"/>.
        /// </summary>
        /// <param name="data">The E02_ContinentDto to use.</param>
        private void Fetch(E02_ContinentDto data)
        {
            // Value properties
            LoadProperty(Continent_IDProperty, data.Continent_ID);
            LoadProperty(Continent_NameProperty, data.Continent_Name);
            var args = new DataPortalHookArgs(data);
            OnFetchRead(args);
        }

        /// <summary>
        /// Loads child objects from the given DAL provider.
        /// </summary>
        /// <param name="dal">The DAL provider to use.</param>
        private void FetchChildren(IE02_ContinentDal dal)
        {
            LoadProperty(E03_Continent_SingleObjectProperty, E03_Continent_Child.GetE03_Continent_Child(dal.E03_Continent_Child));
            LoadProperty(E03_Continent_ASingleObjectProperty, E03_Continent_ReChild.GetE03_Continent_ReChild(dal.E03_Continent_ReChild));
            LoadProperty(E03_SubContinentObjectsProperty, E03_SubContinentColl.GetE03_SubContinentColl(dal.E03_SubContinentColl));
            foreach (var item in dal.E05_SubContinent_Child)
            {
                var child = E05_SubContinent_Child.GetE05_SubContinent_Child(item);
                var obj = E03_SubContinentObjects.FindE04_SubContinentByParentProperties(child.subContinent_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.E05_SubContinent_ReChild)
            {
                var child = E05_SubContinent_ReChild.GetE05_SubContinent_ReChild(item);
                var obj = E03_SubContinentObjects.FindE04_SubContinentByParentProperties(child.subContinent_ID2);
                obj.LoadChild(child);
            }
            var e05_CountryColl = E05_CountryColl.GetE05_CountryColl(dal.E05_CountryColl);
            e05_CountryColl.LoadItems(E03_SubContinentObjects);
            foreach (var item in dal.E07_Country_Child)
            {
                var child = E07_Country_Child.GetE07_Country_Child(item);
                var obj = e05_CountryColl.FindE06_CountryByParentProperties(child.country_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.E07_Country_ReChild)
            {
                var child = E07_Country_ReChild.GetE07_Country_ReChild(item);
                var obj = e05_CountryColl.FindE06_CountryByParentProperties(child.country_ID2);
                obj.LoadChild(child);
            }
            var e07_RegionColl = E07_RegionColl.GetE07_RegionColl(dal.E07_RegionColl);
            e07_RegionColl.LoadItems(e05_CountryColl);
            foreach (var item in dal.E09_Region_Child)
            {
                var child = E09_Region_Child.GetE09_Region_Child(item);
                var obj = e07_RegionColl.FindE08_RegionByParentProperties(child.region_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.E09_Region_ReChild)
            {
                var child = E09_Region_ReChild.GetE09_Region_ReChild(item);
                var obj = e07_RegionColl.FindE08_RegionByParentProperties(child.region_ID2);
                obj.LoadChild(child);
            }
            var e09_CityColl = E09_CityColl.GetE09_CityColl(dal.E09_CityColl);
            e09_CityColl.LoadItems(e07_RegionColl);
            foreach (var item in dal.E11_City_Child)
            {
                var child = E11_City_Child.GetE11_City_Child(item);
                var obj = e09_CityColl.FindE10_CityByParentProperties(child.city_ID1);
                obj.LoadChild(child);
            }
            foreach (var item in dal.E11_City_ReChild)
            {
                var child = E11_City_ReChild.GetE11_City_ReChild(item);
                var obj = e09_CityColl.FindE10_CityByParentProperties(child.city_ID2);
                obj.LoadChild(child);
            }
            var e11_CityRoadColl = E11_CityRoadColl.GetE11_CityRoadColl(dal.E11_CityRoadColl);
            e11_CityRoadColl.LoadItems(e09_CityColl);
        }

        #endregion

        #region DataPortal Hooks

        /// <summary>
        /// Occurs after setting query parameters and before the fetch operation.
        /// </summary>
        partial void OnFetchPre(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the fetch operation (object or collection is fully loaded and set up).
        /// </summary>
        partial void OnFetchPost(DataPortalHookArgs args);

        /// <summary>
        /// Occurs after the low level fetch operation, before the data reader is destroyed.
        /// </summary>
        partial void OnFetchRead(DataPortalHookArgs args);

        #endregion

    }
}
