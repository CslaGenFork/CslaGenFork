using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ParentLoadROSoftDelete.Business.ERCLevel
{

    /// <summary>
    /// F02_Continent (read only object).<br/>
    /// This is a generated base class of <see cref="F02_Continent"/> business object.
    /// </summary>
    /// <remarks>
    /// This class contains one child collection:<br/>
    /// - <see cref="F03_SubContinentObjects"/> of type <see cref="F03_SubContinentColl"/> (1:M relation to <see cref="F04_SubContinent"/>)<br/>
    /// This class is an item of <see cref="F01_ContinentColl"/> collection.
    /// </remarks>
    [Serializable]
    public partial class F02_Continent : ReadOnlyBase<F02_Continent>
    {

        #region ParentList Property

        /// <summary>
        /// Maintains metadata about <see cref="ParentList"/> property.
        /// </summary>
        public static readonly PropertyInfo<F01_ContinentColl> ParentListProperty = RegisterProperty<F01_ContinentColl>(p => p.ParentList);
        /// <summary>
        /// Provide access to the parent list reference for use in child object code.
        /// </summary>
        /// <value>The parent list reference.</value>
        public F01_ContinentColl ParentList
        {
            get { return ReadProperty(ParentListProperty); }
            internal set { LoadProperty(ParentListProperty, value); }
        }

        #endregion

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
        /// Maintains metadata about child <see cref="F03_Continent_SingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F03_Continent_Child> F03_Continent_SingleObjectProperty = RegisterProperty<F03_Continent_Child>(p => p.F03_Continent_SingleObject, "F03 Continent Single Object");
        /// <summary>
        /// Gets the F03 Continent Single Object ("parent load" child property).
        /// </summary>
        /// <value>The F03 Continent Single Object.</value>
        public F03_Continent_Child F03_Continent_SingleObject
        {
            get { return GetProperty(F03_Continent_SingleObjectProperty); }
            private set { LoadProperty(F03_Continent_SingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F03_Continent_ASingleObject"/> property.
        /// </summary>
        public static readonly PropertyInfo<F03_Continent_ReChild> F03_Continent_ASingleObjectProperty = RegisterProperty<F03_Continent_ReChild>(p => p.F03_Continent_ASingleObject, "F03 Continent ASingle Object");
        /// <summary>
        /// Gets the F03 Continent ASingle Object ("parent load" child property).
        /// </summary>
        /// <value>The F03 Continent ASingle Object.</value>
        public F03_Continent_ReChild F03_Continent_ASingleObject
        {
            get { return GetProperty(F03_Continent_ASingleObjectProperty); }
            private set { LoadProperty(F03_Continent_ASingleObjectProperty, value); }
        }

        /// <summary>
        /// Maintains metadata about child <see cref="F03_SubContinentObjects"/> property.
        /// </summary>
        public static readonly PropertyInfo<F03_SubContinentColl> F03_SubContinentObjectsProperty = RegisterProperty<F03_SubContinentColl>(p => p.F03_SubContinentObjects, "F03 SubContinent Objects");
        /// <summary>
        /// Gets the F03 Sub Continent Objects ("parent load" child property).
        /// </summary>
        /// <value>The F03 Sub Continent Objects.</value>
        public F03_SubContinentColl F03_SubContinentObjects
        {
            get { return GetProperty(F03_SubContinentObjectsProperty); }
            private set { LoadProperty(F03_SubContinentObjectsProperty, value); }
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Factory method. Loads a <see cref="F02_Continent"/> object from the given SafeDataReader.
        /// </summary>
        /// <param name="dr">The SafeDataReader to use.</param>
        /// <returns>A reference to the fetched <see cref="F02_Continent"/> object.</returns>
        internal static F02_Continent GetF02_Continent(SafeDataReader dr)
        {
            F02_Continent obj = new F02_Continent();
            obj.Fetch(dr);
            obj.LoadProperty(F03_SubContinentObjectsProperty, new F03_SubContinentColl());
            return obj;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="F02_Continent"/> class.
        /// </summary>
        /// <remarks> Do not use to create a Csla object. Use factory methods instead.</remarks>
        private F02_Continent()
        {
            // Prevent direct creation
        }

        #endregion

        #region Data Access

        /// <summary>
        /// Loads a <see cref="F02_Continent"/> object from the given SafeDataReader.
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
        internal void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            while (dr.Read())
            {
                var child = F03_Continent_Child.GetF03_Continent_Child(dr);
                var obj = ParentList.FindF02_ContinentByParentProperties(child.continent_ID1);
                obj.LoadProperty(F03_Continent_SingleObjectProperty, child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F03_Continent_ReChild.GetF03_Continent_ReChild(dr);
                var obj = ParentList.FindF02_ContinentByParentProperties(child.continent_ID2);
                obj.LoadProperty(F03_Continent_ASingleObjectProperty, child);
            }
            dr.NextResult();
            var f03_SubContinentColl = F03_SubContinentColl.GetF03_SubContinentColl(dr);
            f03_SubContinentColl.LoadItems(ParentList);
            dr.NextResult();
            while (dr.Read())
            {
                var child = F05_SubContinent_Child.GetF05_SubContinent_Child(dr);
                var obj = f03_SubContinentColl.FindF04_SubContinentByParentProperties(child.subContinent_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F05_SubContinent_ReChild.GetF05_SubContinent_ReChild(dr);
                var obj = f03_SubContinentColl.FindF04_SubContinentByParentProperties(child.subContinent_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var f05_CountryColl = F05_CountryColl.GetF05_CountryColl(dr);
            f05_CountryColl.LoadItems(f03_SubContinentColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = F07_Country_Child.GetF07_Country_Child(dr);
                var obj = f05_CountryColl.FindF06_CountryByParentProperties(child.country_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F07_Country_ReChild.GetF07_Country_ReChild(dr);
                var obj = f05_CountryColl.FindF06_CountryByParentProperties(child.country_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var f07_RegionColl = F07_RegionColl.GetF07_RegionColl(dr);
            f07_RegionColl.LoadItems(f05_CountryColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = F09_Region_Child.GetF09_Region_Child(dr);
                var obj = f07_RegionColl.FindF08_RegionByParentProperties(child.region_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F09_Region_ReChild.GetF09_Region_ReChild(dr);
                var obj = f07_RegionColl.FindF08_RegionByParentProperties(child.region_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var f09_CityColl = F09_CityColl.GetF09_CityColl(dr);
            f09_CityColl.LoadItems(f07_RegionColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = F11_City_Child.GetF11_City_Child(dr);
                var obj = f09_CityColl.FindF10_CityByParentProperties(child.city_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = F11_City_ReChild.GetF11_City_ReChild(dr);
                var obj = f09_CityColl.FindF10_CityByParentProperties(child.city_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var f11_CityRoadColl = F11_CityRoadColl.GetF11_CityRoadColl(dr);
            f11_CityRoadColl.LoadItems(f09_CityColl);
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
