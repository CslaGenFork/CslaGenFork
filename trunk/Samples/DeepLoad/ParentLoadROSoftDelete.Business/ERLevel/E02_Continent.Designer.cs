using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

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
        private E02_Continent()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="E02_Continent"/> object from the database, based on given criteria.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        protected void DataPortal_Fetch(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetE02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var args = new DataPortalHookArgs(cmd, continent_ID);
                    OnFetchPre(args);
                    Fetch(cmd);
                    OnFetchPost(args);
                }
            }
        }

        private void Fetch(SqlCommand cmd)
        {
            using (var dr = new SafeDataReader(cmd.ExecuteReader()))
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
        /// Loads a <see cref="E02_Continent"/> object from the given SafeDataReader.
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
                LoadProperty(E03_Continent_SingleObjectProperty, E03_Continent_Child.GetE03_Continent_Child(dr));
            dr.NextResult();
            if (dr.Read())
                LoadProperty(E03_Continent_ASingleObjectProperty, E03_Continent_ReChild.GetE03_Continent_ReChild(dr));
            dr.NextResult();
            LoadProperty(E03_SubContinentObjectsProperty, E03_SubContinentColl.GetE03_SubContinentColl(dr));
            dr.NextResult();
            while (dr.Read())
            {
                var child = E05_SubContinent_Child.GetE05_SubContinent_Child(dr);
                var obj = E03_SubContinentObjects.FindE04_SubContinentByParentProperties(child.subContinent_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = E05_SubContinent_ReChild.GetE05_SubContinent_ReChild(dr);
                var obj = E03_SubContinentObjects.FindE04_SubContinentByParentProperties(child.subContinent_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var e05_CountryColl = E05_CountryColl.GetE05_CountryColl(dr);
            e05_CountryColl.LoadItems(E03_SubContinentObjects);
            dr.NextResult();
            while (dr.Read())
            {
                var child = E07_Country_Child.GetE07_Country_Child(dr);
                var obj = e05_CountryColl.FindE06_CountryByParentProperties(child.country_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = E07_Country_ReChild.GetE07_Country_ReChild(dr);
                var obj = e05_CountryColl.FindE06_CountryByParentProperties(child.country_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var e07_RegionColl = E07_RegionColl.GetE07_RegionColl(dr);
            e07_RegionColl.LoadItems(e05_CountryColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = E09_Region_Child.GetE09_Region_Child(dr);
                var obj = e07_RegionColl.FindE08_RegionByParentProperties(child.region_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = E09_Region_ReChild.GetE09_Region_ReChild(dr);
                var obj = e07_RegionColl.FindE08_RegionByParentProperties(child.region_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var e09_CityColl = E09_CityColl.GetE09_CityColl(dr);
            e09_CityColl.LoadItems(e07_RegionColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = E11_City_Child.GetE11_City_Child(dr);
                var obj = e09_CityColl.FindE10_CityByParentProperties(child.city_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = E11_City_ReChild.GetE11_City_ReChild(dr);
                var obj = e09_CityColl.FindE10_CityByParentProperties(child.city_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var e11_CityRoadColl = E11_CityRoadColl.GetE11_CityRoadColl(dr);
            e11_CityRoadColl.LoadItems(e09_CityColl);
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
