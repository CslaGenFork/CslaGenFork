using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadRO.DataAccess;
using ParentLoadRO.DataAccess.ERLevel;

namespace ParentLoadRO.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IA02_ContinentDal"/>
    /// </summary>
    public partial class A02_ContinentDal : IA02_ContinentDal
    {
        private A03_Continent_ChildDto _a03_Continent_Child = new A03_Continent_ChildDto();
        private A03_Continent_ReChildDto _a03_Continent_ReChild = new A03_Continent_ReChildDto();
        private List<A04_SubContinentDto> _a03_SubContinentColl = new List<A04_SubContinentDto>();
        private List<A05_SubContinent_ChildDto> _a05_SubContinent_Child = new List<A05_SubContinent_ChildDto>();
        private List<A05_SubContinent_ReChildDto> _a05_SubContinent_ReChild = new List<A05_SubContinent_ReChildDto>();
        private List<A06_CountryDto> _a05_CountryColl = new List<A06_CountryDto>();
        private List<A07_Country_ChildDto> _a07_Country_Child = new List<A07_Country_ChildDto>();
        private List<A07_Country_ReChildDto> _a07_Country_ReChild = new List<A07_Country_ReChildDto>();
        private List<A08_RegionDto> _a07_RegionColl = new List<A08_RegionDto>();
        private List<A09_Region_ChildDto> _a09_Region_Child = new List<A09_Region_ChildDto>();
        private List<A09_Region_ReChildDto> _a09_Region_ReChild = new List<A09_Region_ReChildDto>();
        private List<A10_CityDto> _a09_CityColl = new List<A10_CityDto>();
        private List<A11_City_ChildDto> _a11_City_Child = new List<A11_City_ChildDto>();
        private List<A11_City_ReChildDto> _a11_City_ReChild = new List<A11_City_ReChildDto>();
        private List<A12_CityRoadDto> _a11_CityRoadColl = new List<A12_CityRoadDto>();

        /// <summary>
        /// Gets the A03 Continent Single Object.
        /// </summary>
        /// <value>A <see cref="A03_Continent_ChildDto"/> object.</value>
        public A03_Continent_ChildDto A03_Continent_Child
        {
            get { return _a03_Continent_Child; }
        }

        /// <summary>
        /// Gets the A03 Continent ASingle Object.
        /// </summary>
        /// <value>A <see cref="A03_Continent_ReChildDto"/> object.</value>
        public A03_Continent_ReChildDto A03_Continent_ReChild
        {
            get { return _a03_Continent_ReChild; }
        }

        /// <summary>
        /// Gets the A03 SubContinent Objects.
        /// </summary>
        /// <value>A list of <see cref="A04_SubContinentDto"/>.</value>
        public List<A04_SubContinentDto> A03_SubContinentColl
        {
            get { return _a03_SubContinentColl; }
        }

        /// <summary>
        /// Gets the A05 SubContinent Single Object.
        /// </summary>
        /// <value>A list of <see cref="A05_SubContinent_ChildDto"/>.</value>
        public List<A05_SubContinent_ChildDto> A05_SubContinent_Child
        {
            get { return _a05_SubContinent_Child; }
        }

        /// <summary>
        /// Gets the A05 SubContinent ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="A05_SubContinent_ReChildDto"/>.</value>
        public List<A05_SubContinent_ReChildDto> A05_SubContinent_ReChild
        {
            get { return _a05_SubContinent_ReChild; }
        }

        /// <summary>
        /// Gets the A05 Country Objects.
        /// </summary>
        /// <value>A list of <see cref="A06_CountryDto"/>.</value>
        public List<A06_CountryDto> A05_CountryColl
        {
            get { return _a05_CountryColl; }
        }

        /// <summary>
        /// Gets the A07 Country Single Object.
        /// </summary>
        /// <value>A list of <see cref="A07_Country_ChildDto"/>.</value>
        public List<A07_Country_ChildDto> A07_Country_Child
        {
            get { return _a07_Country_Child; }
        }

        /// <summary>
        /// Gets the A07 Country ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="A07_Country_ReChildDto"/>.</value>
        public List<A07_Country_ReChildDto> A07_Country_ReChild
        {
            get { return _a07_Country_ReChild; }
        }

        /// <summary>
        /// Gets the A07 Region Objects.
        /// </summary>
        /// <value>A list of <see cref="A08_RegionDto"/>.</value>
        public List<A08_RegionDto> A07_RegionColl
        {
            get { return _a07_RegionColl; }
        }

        /// <summary>
        /// Gets the A09 Region Single Object.
        /// </summary>
        /// <value>A list of <see cref="A09_Region_ChildDto"/>.</value>
        public List<A09_Region_ChildDto> A09_Region_Child
        {
            get { return _a09_Region_Child; }
        }

        /// <summary>
        /// Gets the A09 Region ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="A09_Region_ReChildDto"/>.</value>
        public List<A09_Region_ReChildDto> A09_Region_ReChild
        {
            get { return _a09_Region_ReChild; }
        }

        /// <summary>
        /// Gets the A09 City Objects.
        /// </summary>
        /// <value>A list of <see cref="A10_CityDto"/>.</value>
        public List<A10_CityDto> A09_CityColl
        {
            get { return _a09_CityColl; }
        }

        /// <summary>
        /// Gets the A11 City Single Object.
        /// </summary>
        /// <value>A list of <see cref="A11_City_ChildDto"/>.</value>
        public List<A11_City_ChildDto> A11_City_Child
        {
            get { return _a11_City_Child; }
        }

        /// <summary>
        /// Gets the A11 City ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="A11_City_ReChildDto"/>.</value>
        public List<A11_City_ReChildDto> A11_City_ReChild
        {
            get { return _a11_City_ReChild; }
        }

        /// <summary>
        /// Gets the A11 CityRoad Objects.
        /// </summary>
        /// <value>A list of <see cref="A12_CityRoadDto"/>.</value>
        public List<A12_CityRoadDto> A11_CityRoadColl
        {
            get { return _a11_CityRoadColl; }
        }

        /// <summary>
        /// Loads a A02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The fetch criteria.</param>
        /// <returns>A A02_ContinentDto object.</returns>
        public A02_ContinentDto Fetch(int continent_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetA02_Continent", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID", continent_ID).DbType = DbType.Int32;
                    var dr = cmd.ExecuteReader();
                    return Fetch(dr);
                }
            }
        }

        private A02_ContinentDto Fetch(IDataReader data)
        {
            var a02_Continent = new A02_ContinentDto();
            using (var dr = new SafeDataReader(data))
            {
                if (dr.Read())
                {
                    a02_Continent.Continent_ID = dr.GetInt32("Continent_ID");
                    a02_Continent.Continent_Name = dr.GetString("Continent_Name");
                }
                FetchChildren(dr);
            }
            return a02_Continent;
        }

        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            if (dr.Read())
                FetchA03_Continent_Child(dr);
            dr.NextResult();
            if (dr.Read())
                FetchA03_Continent_ReChild(dr);
            dr.NextResult();
            while (dr.Read())
            {
                _a03_SubContinentColl.Add(FetchA04_SubContinent(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _a05_SubContinent_Child.Add(FetchA05_SubContinent_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _a05_SubContinent_ReChild.Add(FetchA05_SubContinent_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _a05_CountryColl.Add(FetchA06_Country(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _a07_Country_Child.Add(FetchA07_Country_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _a07_Country_ReChild.Add(FetchA07_Country_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _a07_RegionColl.Add(FetchA08_Region(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _a09_Region_Child.Add(FetchA09_Region_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _a09_Region_ReChild.Add(FetchA09_Region_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _a09_CityColl.Add(FetchA10_City(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _a11_City_Child.Add(FetchA11_City_Child(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _a11_City_ReChild.Add(FetchA11_City_ReChild(dr));
            }
            dr.NextResult();
            while (dr.Read())
            {
                _a11_CityRoadColl.Add(FetchA12_CityRoad(dr));
            }
        }

        private void FetchA03_Continent_Child(SafeDataReader dr)
        {
            // Value properties
            _a03_Continent_Child.Continent_Child_Name = dr.GetString("Continent_Child_Name");
        }

        private void FetchA03_Continent_ReChild(SafeDataReader dr)
        {
            // Value properties
            _a03_Continent_ReChild.Continent_Child_Name = dr.GetString("Continent_Child_Name");
        }

        private A04_SubContinentDto FetchA04_SubContinent(SafeDataReader dr)
        {
            var a04_SubContinent = new A04_SubContinentDto();
            // Value properties
            a04_SubContinent.SubContinent_ID = dr.GetInt32("SubContinent_ID");
            a04_SubContinent.SubContinent_Name = dr.GetString("SubContinent_Name");

            return a04_SubContinent;
        }

        private A05_SubContinent_ChildDto FetchA05_SubContinent_Child(SafeDataReader dr)
        {
            var a05_SubContinent_Child = new A05_SubContinent_ChildDto();
            // Value properties
            a05_SubContinent_Child.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
            a05_SubContinent_Child.SubContinent_ID1 = dr.GetInt32("SubContinent_ID1");
            a05_SubContinent_Child.RowVersion = dr.GetValue("RowVersion") as byte[];
            // parent properties
            a05_SubContinent_Child.Parent_SubContinent_ID = dr.GetInt32("SubContinent_ID1");

            return a05_SubContinent_Child;
        }

        private A05_SubContinent_ReChildDto FetchA05_SubContinent_ReChild(SafeDataReader dr)
        {
            var a05_SubContinent_ReChild = new A05_SubContinent_ReChildDto();
            // Value properties
            a05_SubContinent_ReChild.SubContinent_Child_Name = dr.GetString("SubContinent_Child_Name");
            a05_SubContinent_ReChild.RowVersion = dr.GetValue("RowVersion") as byte[];
            // parent properties
            a05_SubContinent_ReChild.Parent_SubContinent_ID = dr.GetInt32("SubContinent_ID2");

            return a05_SubContinent_ReChild;
        }

        private A06_CountryDto FetchA06_Country(SafeDataReader dr)
        {
            var a06_Country = new A06_CountryDto();
            // Value properties
            a06_Country.Country_ID = dr.GetInt32("Country_ID");
            a06_Country.Country_Name = dr.GetString("Country_Name");
            a06_Country.ParentSubContinentID = dr.GetInt32("Parent_SubContinent_ID");
            a06_Country.RowVersion = dr.GetValue("RowVersion") as byte[];
            // parent properties
            a06_Country.Parent_SubContinent_ID = dr.GetInt32("Parent_SubContinent_ID");

            return a06_Country;
        }

        private A07_Country_ChildDto FetchA07_Country_Child(SafeDataReader dr)
        {
            var a07_Country_Child = new A07_Country_ChildDto();
            // Value properties
            a07_Country_Child.Country_Child_Name = dr.GetString("Country_Child_Name");
            // parent properties
            a07_Country_Child.Parent_Country_ID = dr.GetInt32("Country_ID1");

            return a07_Country_Child;
        }

        private A07_Country_ReChildDto FetchA07_Country_ReChild(SafeDataReader dr)
        {
            var a07_Country_ReChild = new A07_Country_ReChildDto();
            // Value properties
            a07_Country_ReChild.Country_Child_Name = dr.GetString("Country_Child_Name");
            // parent properties
            a07_Country_ReChild.Parent_Country_ID = dr.GetInt32("Country_ID2");

            return a07_Country_ReChild;
        }

        private A08_RegionDto FetchA08_Region(SafeDataReader dr)
        {
            var a08_Region = new A08_RegionDto();
            // Value properties
            a08_Region.Region_ID = dr.GetInt32("Region_ID");
            a08_Region.Region_Name = dr.GetString("Region_Name");
            // parent properties
            a08_Region.Parent_Country_ID = dr.GetInt32("Parent_Country_ID");

            return a08_Region;
        }

        private A09_Region_ChildDto FetchA09_Region_Child(SafeDataReader dr)
        {
            var a09_Region_Child = new A09_Region_ChildDto();
            // Value properties
            a09_Region_Child.Region_Child_Name = dr.GetString("Region_Child_Name");
            // parent properties
            a09_Region_Child.Parent_Region_ID = dr.GetInt32("Region_ID1");

            return a09_Region_Child;
        }

        private A09_Region_ReChildDto FetchA09_Region_ReChild(SafeDataReader dr)
        {
            var a09_Region_ReChild = new A09_Region_ReChildDto();
            // Value properties
            a09_Region_ReChild.Region_Child_Name = dr.GetString("Region_Child_Name");
            // parent properties
            a09_Region_ReChild.Parent_Region_ID = dr.GetInt32("Region_ID2");

            return a09_Region_ReChild;
        }

        private A10_CityDto FetchA10_City(SafeDataReader dr)
        {
            var a10_City = new A10_CityDto();
            // Value properties
            a10_City.City_ID = dr.GetInt32("City_ID");
            a10_City.City_Name = dr.GetString("City_Name");
            // parent properties
            a10_City.Parent_Region_ID = dr.GetInt32("Parent_Region_ID");

            return a10_City;
        }

        private A11_City_ChildDto FetchA11_City_Child(SafeDataReader dr)
        {
            var a11_City_Child = new A11_City_ChildDto();
            // Value properties
            a11_City_Child.City_Child_Name = dr.GetString("City_Child_Name");
            // parent properties
            a11_City_Child.Parent_City_ID = dr.GetInt32("City_ID1");

            return a11_City_Child;
        }

        private A11_City_ReChildDto FetchA11_City_ReChild(SafeDataReader dr)
        {
            var a11_City_ReChild = new A11_City_ReChildDto();
            // Value properties
            a11_City_ReChild.City_Child_Name = dr.GetString("City_Child_Name");
            // parent properties
            a11_City_ReChild.Parent_City_ID = dr.GetInt32("City_ID2");

            return a11_City_ReChild;
        }

        private A12_CityRoadDto FetchA12_CityRoad(SafeDataReader dr)
        {
            var a12_CityRoad = new A12_CityRoadDto();
            // Value properties
            a12_CityRoad.CityRoad_ID = dr.GetInt32("CityRoad_ID");
            a12_CityRoad.CityRoad_Name = dr.GetString("CityRoad_Name");
            // parent properties
            a12_CityRoad.Parent_City_ID = dr.GetInt32("Parent_City_ID");

            return a12_CityRoad;
        }
    }
}
