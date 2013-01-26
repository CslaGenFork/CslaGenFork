using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IF01_ContinentCollDal"/>
    /// </summary>
    public partial class F01_ContinentCollDal : IF01_ContinentCollDal
    {
        private List<F03_Continent_ChildDto> _f03_Continent_Child = new List<F03_Continent_ChildDto>();
        private List<F03_Continent_ReChildDto> _f03_Continent_ReChild = new List<F03_Continent_ReChildDto>();
        private List<F04_SubContinentDto> _f03_SubContinentColl = new List<F04_SubContinentDto>();
        private List<F05_SubContinent_ChildDto> _f05_SubContinent_Child = new List<F05_SubContinent_ChildDto>();
        private List<F05_SubContinent_ReChildDto> _f05_SubContinent_ReChild = new List<F05_SubContinent_ReChildDto>();
        private List<F06_CountryDto> _f05_CountryColl = new List<F06_CountryDto>();
        private List<F07_Country_ChildDto> _f07_Country_Child = new List<F07_Country_ChildDto>();
        private List<F07_Country_ReChildDto> _f07_Country_ReChild = new List<F07_Country_ReChildDto>();
        private List<F08_RegionDto> _f07_RegionColl = new List<F08_RegionDto>();
        private List<F09_Region_ChildDto> _f09_Region_Child = new List<F09_Region_ChildDto>();
        private List<F09_Region_ReChildDto> _f09_Region_ReChild = new List<F09_Region_ReChildDto>();
        private List<F10_CityDto> _f09_CityColl = new List<F10_CityDto>();
        private List<F11_City_ChildDto> _f11_City_Child = new List<F11_City_ChildDto>();
        private List<F11_City_ReChildDto> _f11_City_ReChild = new List<F11_City_ReChildDto>();
        private List<F12_CityRoadDto> _f11_CityRoadColl = new List<F12_CityRoadDto>();

        /// <summary>
        /// Gets the F03 Continent Single Object.
        /// </summary>
        /// <value>A list of <see cref="F03_Continent_ChildDto"/>.</value>
        public List<F03_Continent_ChildDto> F03_Continent_Child
        {
            get { return _f03_Continent_Child; }
        }

        /// <summary>
        /// Gets the F03 Continent ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="F03_Continent_ReChildDto"/>.</value>
        public List<F03_Continent_ReChildDto> F03_Continent_ReChild
        {
            get { return _f03_Continent_ReChild; }
        }

        /// <summary>
        /// Gets the F03 SubContinent Objects.
        /// </summary>
        /// <value>A list of <see cref="F04_SubContinentDto"/>.</value>
        public List<F04_SubContinentDto> F03_SubContinentColl
        {
            get { return _f03_SubContinentColl; }
        }

        /// <summary>
        /// Gets the F05 SubContinent Single Object.
        /// </summary>
        /// <value>A list of <see cref="F05_SubContinent_ChildDto"/>.</value>
        public List<F05_SubContinent_ChildDto> F05_SubContinent_Child
        {
            get { return _f05_SubContinent_Child; }
        }

        /// <summary>
        /// Gets the F05 SubContinent ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="F05_SubContinent_ReChildDto"/>.</value>
        public List<F05_SubContinent_ReChildDto> F05_SubContinent_ReChild
        {
            get { return _f05_SubContinent_ReChild; }
        }

        /// <summary>
        /// Gets the F05 Country Objects.
        /// </summary>
        /// <value>A list of <see cref="F06_CountryDto"/>.</value>
        public List<F06_CountryDto> F05_CountryColl
        {
            get { return _f05_CountryColl; }
        }

        /// <summary>
        /// Gets the F07 Country Single Object.
        /// </summary>
        /// <value>A list of <see cref="F07_Country_ChildDto"/>.</value>
        public List<F07_Country_ChildDto> F07_Country_Child
        {
            get { return _f07_Country_Child; }
        }

        /// <summary>
        /// Gets the F07 Country ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="F07_Country_ReChildDto"/>.</value>
        public List<F07_Country_ReChildDto> F07_Country_ReChild
        {
            get { return _f07_Country_ReChild; }
        }

        /// <summary>
        /// Gets the F07 Region Objects.
        /// </summary>
        /// <value>A list of <see cref="F08_RegionDto"/>.</value>
        public List<F08_RegionDto> F07_RegionColl
        {
            get { return _f07_RegionColl; }
        }

        /// <summary>
        /// Gets the F09 Region Single Object.
        /// </summary>
        /// <value>A list of <see cref="F09_Region_ChildDto"/>.</value>
        public List<F09_Region_ChildDto> F09_Region_Child
        {
            get { return _f09_Region_Child; }
        }

        /// <summary>
        /// Gets the F09 Region ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="F09_Region_ReChildDto"/>.</value>
        public List<F09_Region_ReChildDto> F09_Region_ReChild
        {
            get { return _f09_Region_ReChild; }
        }

        /// <summary>
        /// Gets the F09 City Objects.
        /// </summary>
        /// <value>A list of <see cref="F10_CityDto"/>.</value>
        public List<F10_CityDto> F09_CityColl
        {
            get { return _f09_CityColl; }
        }

        /// <summary>
        /// Gets the F11 City Single Object.
        /// </summary>
        /// <value>A list of <see cref="F11_City_ChildDto"/>.</value>
        public List<F11_City_ChildDto> F11_City_Child
        {
            get { return _f11_City_Child; }
        }

        /// <summary>
        /// Gets the F11 City ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="F11_City_ReChildDto"/>.</value>
        public List<F11_City_ReChildDto> F11_City_ReChild
        {
            get { return _f11_City_ReChild; }
        }

        /// <summary>
        /// Gets the F11 CityRoad Objects.
        /// </summary>
        /// <value>A list of <see cref="F12_CityRoadDto"/>.</value>
        public List<F12_CityRoadDto> F11_CityRoadColl
        {
            get { return _f11_CityRoadColl; }
        }

        /// <summary>
        /// Loads a F01_ContinentColl collection from the database.
        /// </summary>
        /// <returns>A list of <see cref="F02_ContinentDto"/>.</returns>
        public List<F02_ContinentDto> Fetch()
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetF01_ContinentColl", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var dr = cmd.ExecuteReader();
                    return LoadCollection(dr);
                }
            }
        }

        private List<F02_ContinentDto> LoadCollection(IDataReader data)
        {
            var f01_ContinentColl = new List<F02_ContinentDto>();
            using (var dr = new SafeDataReader(data))
            {
                while (dr.Read())
                {
                    f01_ContinentColl.Add(Fetch(dr));
                }
                if (f01_ContinentColl.Count > 0)
                    FetchChildren(dr);
            }
            return f01_ContinentColl;
        }

        private F02_ContinentDto Fetch(SafeDataReader dr)
        {
            var f02_Continent = new F02_ContinentDto();
            // Value properties
            f02_Continent.Continent_ID = dr.GetInt32("Continent_ID");
            f02_Continent.Continent_Name = dr.GetString("Continent_Name");

            return f02_Continent;
        }

        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            while (dr.Read())
            {
                _f03_Continent_Child.Add(FetchF03_Continent_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f03_Continent_ReChild.Add(FetchF03_Continent_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f03_SubContinentColl.Add(FetchF04_SubContinent(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f05_SubContinent_Child.Add(FetchF05_SubContinent_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f05_SubContinent_ReChild.Add(FetchF05_SubContinent_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f05_CountryColl.Add(FetchF06_Country(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f07_Country_Child.Add(FetchF07_Country_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f07_Country_ReChild.Add(FetchF07_Country_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f07_RegionColl.Add(FetchF08_Region(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f09_Region_Child.Add(FetchF09_Region_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f09_Region_ReChild.Add(FetchF09_Region_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f09_CityColl.Add(FetchF10_City(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f11_City_Child.Add(FetchF11_City_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f11_City_ReChild.Add(FetchF11_City_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _f11_CityRoadColl.Add(FetchF12_CityRoad(dr));
            }
        }

        private F03_Continent_ChildDto FetchF03_Continent_Child(SafeDataReader dr)
        {
            var f03_Continent_Child = new F03_Continent_ChildDto();
            // Value properties
            f03_Continent_Child.Continent_Child_Name = dr.GetString("Continent_Child_Name");
            // parent properties
            f03_Continent_Child.Parent_Continent_ID = dr.GetInt32("Continent_ID1");

            return f03_Continent_Child;
        }

        private F03_Continent_ReChildDto FetchF03_Continent_ReChild(SafeDataReader dr)
        {
            var f03_Continent_ReChild = new F03_Continent_ReChildDto();
            // Value properties
            f03_Continent_ReChild.Continent_Child_Name = dr.GetString("Continent_Child_Name");
            // parent properties
            f03_Continent_ReChild.Parent_Continent_ID = dr.GetInt32("Continent_ID2");

            return f03_Continent_ReChild;
        }

        private F04_SubContinentDto FetchF04_SubContinent(SafeDataReader dr)
        {
            var f04_SubContinent = new F04_SubContinentDto();
            // Value properties
            f04_SubContinent.SubContinent_ID = dr.GetInt32("SubContinent_ID");
            f04_SubContinent.SubContinent_Name = dr.GetString("SubContinent_Name");
            // parent properties
            f04_SubContinent.Parent_Continent_ID = dr.GetInt32("Parent_Continent_ID");

            return f04_SubContinent;
        }

        private F05_SubContinent_ChildDto FetchF05_SubContinent_Child(SafeDataReader dr)
        {
            var f05_SubContinent_Child = new F05_SubContinent_ChildDto();
            // Value properties
            f05_SubContinent_Child.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
            // parent properties
            f05_SubContinent_Child.Parent_SubContinent_ID = dr.GetInt32("SubContinent_ID1");

            return f05_SubContinent_Child;
        }

        private F05_SubContinent_ReChildDto FetchF05_SubContinent_ReChild(SafeDataReader dr)
        {
            var f05_SubContinent_ReChild = new F05_SubContinent_ReChildDto();
            // Value properties
            f05_SubContinent_ReChild.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
            // parent properties
            f05_SubContinent_ReChild.Parent_SubContinent_ID = dr.GetInt32("SubContinent_ID2");

            return f05_SubContinent_ReChild;
        }

        private F06_CountryDto FetchF06_Country(SafeDataReader dr)
        {
            var f06_Country = new F06_CountryDto();
            // Value properties
            f06_Country.Country_ID = dr.GetInt32("Country_ID");
            f06_Country.Country_Name = dr.GetString("Country_Name");
            // parent properties
            f06_Country.Parent_SubContinent_ID = dr.GetInt32("Parent_SubContinent_ID");

            return f06_Country;
        }

        private F07_Country_ChildDto FetchF07_Country_Child(SafeDataReader dr)
        {
            var f07_Country_Child = new F07_Country_ChildDto();
            // Value properties
            f07_Country_Child.Country_Child_Name = dr.GetString("Country_Child_Name");
            // parent properties
            f07_Country_Child.Parent_Country_ID = dr.GetInt32("Country_ID1");

            return f07_Country_Child;
        }

        private F07_Country_ReChildDto FetchF07_Country_ReChild(SafeDataReader dr)
        {
            var f07_Country_ReChild = new F07_Country_ReChildDto();
            // Value properties
            f07_Country_ReChild.Country_Child_Name = dr.GetString("Country_Child_Name");
            // parent properties
            f07_Country_ReChild.Parent_Country_ID = dr.GetInt32("Country_ID2");

            return f07_Country_ReChild;
        }

        private F08_RegionDto FetchF08_Region(SafeDataReader dr)
        {
            var f08_Region = new F08_RegionDto();
            // Value properties
            f08_Region.Region_ID = dr.GetInt32("Region_ID");
            f08_Region.Region_Name = dr.GetString("Region_Name");
            // parent properties
            f08_Region.Parent_Country_ID = dr.GetInt32("Parent_Country_ID");

            return f08_Region;
        }

        private F09_Region_ChildDto FetchF09_Region_Child(SafeDataReader dr)
        {
            var f09_Region_Child = new F09_Region_ChildDto();
            // Value properties
            f09_Region_Child.Region_Child_Name = dr.GetString("Region_Child_Name");
            // parent properties
            f09_Region_Child.Parent_Region_ID = dr.GetInt32("Region_ID1");

            return f09_Region_Child;
        }

        private F09_Region_ReChildDto FetchF09_Region_ReChild(SafeDataReader dr)
        {
            var f09_Region_ReChild = new F09_Region_ReChildDto();
            // Value properties
            f09_Region_ReChild.Region_Child_Name = dr.GetString("Region_Child_Name");
            // parent properties
            f09_Region_ReChild.Parent_Region_ID = dr.GetInt32("Region_ID2");

            return f09_Region_ReChild;
        }

        private F10_CityDto FetchF10_City(SafeDataReader dr)
        {
            var f10_City = new F10_CityDto();
            // Value properties
            f10_City.City_ID = dr.GetInt32("City_ID");
            f10_City.City_Name = dr.GetString("City_Name");
            // parent properties
            f10_City.Parent_Region_ID = dr.GetInt32("Parent_Region_ID");

            return f10_City;
        }

        private F11_City_ChildDto FetchF11_City_Child(SafeDataReader dr)
        {
            var f11_City_Child = new F11_City_ChildDto();
            // Value properties
            f11_City_Child.City_Child_Name = dr.GetString("City_Child_Name");
            // parent properties
            f11_City_Child.Parent_City_ID = dr.GetInt32("City_ID1");

            return f11_City_Child;
        }

        private F11_City_ReChildDto FetchF11_City_ReChild(SafeDataReader dr)
        {
            var f11_City_ReChild = new F11_City_ReChildDto();
            // Value properties
            f11_City_ReChild.City_Child_Name = dr.GetString("City_Child_Name");
            // parent properties
            f11_City_ReChild.Parent_City_ID = dr.GetInt32("City_ID2");

            return f11_City_ReChild;
        }

        private F12_CityRoadDto FetchF12_CityRoad(SafeDataReader dr)
        {
            var f12_CityRoad = new F12_CityRoadDto();
            // Value properties
            f12_CityRoad.CityRoad_ID = dr.GetInt32("CityRoad_ID");
            f12_CityRoad.CityRoad_Name = dr.GetString("CityRoad_Name");
            // parent properties
            f12_CityRoad.Parent_City_ID = dr.GetInt32("Parent_City_ID");

            return f12_CityRoad;
        }
    }
}
