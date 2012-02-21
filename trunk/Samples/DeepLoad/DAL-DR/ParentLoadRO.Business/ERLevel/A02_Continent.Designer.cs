using System;
using System.Data;
using Csla;
using Csla.Data;
using ParentLoadRO.DataAccess.ERLevel;
using ParentLoadRO.DataAccess;

namespace ParentLoadRO.Business.ERLevel
{

    /// <summary>
    /// A02_Continent (read only object).<br/>
    /// This is a generated base class of <see cref="A02_Continent"/> business object.
    /// This class is a root object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="A03_SubContinentObjects"/> of type <see cref="A03_SubContinentColl"/> (1:M relation to <see cref="A04_SubContinent"/>)
    /// </remarks>
    [Serializable]
    public partial class A02_Continent : ReadOnlyBase<A02_Continent>
    {

        #region Business Properties

        /// <summary>
        /// Maintains metadata about <see cref="Continent_ID"/> property.
        /// </summary>
        public static readonly PropertyInfo<int> Continent_IDProperty = RegisterProperty<int>(p => p.Continent_ID, "1_Continents ID", -1);
        /// <summary>
        /// Gets the 1_Continents ID.
        /// </summary>
        /// <value>The 1_Continents ID.</value>
        public int Continent_ID
        {
            get { return GetProperty(Continent_IDProperty); }
        }

        /// <summary>
        /// Maintains metadata about <see cref="Continent_Name"/> property.
        /// </summary>
        public static readonly PropertyInfo<string> Continent_NameProperty = RegisterProperty<string>(p => p.Continent_Name, "1_Continents Name");
        /// <summary>
        /// Gets the 1_Continents Name.
        /// </summary>
        /// <value>The 1_Continents Name.</value>
        public string Continent_Name
        {
            get { return GetProperty(Continent_NameProperty); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A03_Continent_Child> A03_Continent_SingleObjectProperty = RegisterProperty<A03_Continent_Child>(p => p.A03_Continent_SingleObject, "A03 Continent Single Object");
        /// <summary>
        /// Gets the A03 Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The A03 Continent Single Object.</value>
        public A03_Continent_Child A03_Continent_SingleObject
        {
            get { return GetProperty(A03_Continent_SingleObjectProperty); }
            private set { LoadProperty(A03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<A03_Continent_ReChild> A03_Continent_ASingleObjectProperty = RegisterProperty<A03_Continent_ReChild>(p => p.A03_Continent_ASingleObject, "A03 Continent ASingle Object");
        /// <summary>
        /// Gets the A03 Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The A03 Continent ASingle Object.</value>
        public A03_Continent_ReChild A03_Continent_ASingleObject
        {
            get { return GetProperty(A03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(A03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="A03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<A03_SubContinentColl> A03_SubContinentObjectsProperty = RegisterProperty<A03_SubContinentColl>(p => p.A03_SubContinentObjects, "A03 SubContinent Objects");
        /// <summary>
        /// Gets the A03 Sub Continent Objects ("parent load" child property).
        /// </summary>
        /// <value>The A03 Sub Continent Objects.</value>
        public A03_SubContinentColl A03_SubContinentObjects
        {
            get { return GetProperty(A03_SubContinentObjectsProperty); }
            private set { LoadProperty(A03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="A02_Continent"/> object, based on given parameters.
        /// </summary>
        /// <param name="continent_ID">The Continent_ID parameter of the A02_Continent to fetch.</param>
        /// <returns>A reference to the fetched <see cref="A02_Continent"/> object.</returns>
        public static A02_Continent GetA02_Continent(int continent_ID)
        {
            return DataPortal.Fetch<A02_Continent>(continent_ID);
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="A02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private A02_Continent()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="A02_Continent"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        protected void DataPortal_Fetch(int continent_ID)
        {
            var args = new DataPortalHookArgs(continent_ID);
            OnFetchPre(args);
            using (var dalManager = DalFactoryParentLoadRO.GetManager())
            {
                var dal = dalManager.GetProvider<IA02_ContinentDal>();
                var data = dal.Fetch(continent_ID);
                Fetch(data);
            }
            OnFetchPost(args);
        }

        private void Fetch(IDataReader data)
        {
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    Fetch(dr);
                    FetchChildren(dr);
                }
                BusinessRules.CheckRules();
            }
        }

        /// <summary>
        /// Loads a <see cref="A02_Continent"/> object from the given SafeDataReader.
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
        /// Loads child objects from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            if (dr.Read())
                LoadProperty(A03_Continent_SingleObjectProperty, A03_Continent_Child.GetA03_Continent_Child(dr));
            dr.NextResult();
            if (dr.Read())
                LoadProperty(A03_Continent_ASingleObjectProperty, A03_Continent_ReChild.GetA03_Continent_ReChild(dr));
            dr.NextResult();
            LoadProperty(A03_SubContinentObjectsProperty, A03_SubContinentColl.GetA03_SubContinentColl(dr));
            dr.NextResult();
            while (dr.Read())
            {
                var child = A05_SubContinent_Child.GetA05_SubContinent_Child(dr);
                var obj = A03_SubContinentObjects.FindA04_SubContinentByParentProperties(child.subContinent_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = A05_SubContinent_ReChild.GetA05_SubContinent_ReChild(dr);
                var obj = A03_SubContinentObjects.FindA04_SubContinentByParentProperties(child.subContinent_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var a05_CountryColl = A05_CountryColl.GetA05_CountryColl(dr);
            a05_CountryColl.LoadItems(A03_SubContinentObjects);
            dr.NextResult();
            while (dr.Read())
            {
                var child = A07_Country_Child.GetA07_Country_Child(dr);
                var obj = a05_CountryColl.FindA06_CountryByParentProperties(child.country_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = A07_Country_ReChild.GetA07_Country_ReChild(dr);
                var obj = a05_CountryColl.FindA06_CountryByParentProperties(child.country_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var a07_RegionColl = A07_RegionColl.GetA07_RegionColl(dr);
            a07_RegionColl.LoadItems(a05_CountryColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = A09_Region_Child.GetA09_Region_Child(dr);
                var obj = a07_RegionColl.FindA08_RegionByParentProperties(child.region_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = A09_Region_ReChild.GetA09_Region_ReChild(dr);
                var obj = a07_RegionColl.FindA08_RegionByParentProperties(child.region_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var a09_CityColl = A09_CityColl.GetA09_CityColl(dr);
            a09_CityColl.LoadItems(a07_RegionColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = A11_City_Child.GetA11_City_Child(dr);
                var obj = a09_CityColl.FindA10_CityByParentProperties(child.city_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = A11_City_ReChild.GetA11_City_ReChild(dr);
                var obj = a09_CityColl.FindA10_CityByParentProperties(child.city_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var a11_CityRoadColl = A11_CityRoadColl.GetA11_CityRoadColl(dr);
            a11_CityRoadColl.LoadItems(a09_CityColl);
        }

        #endregion

        #region Pseudo Events

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
