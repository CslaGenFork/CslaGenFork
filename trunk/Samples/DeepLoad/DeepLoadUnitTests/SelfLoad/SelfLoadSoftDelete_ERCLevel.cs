using SelfLoadSoftDelete.Business.ERCLevel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeepLoadUnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class SelfLoadSoftDelete_ERCLevel
    {
        private const string ContinentName = "Dinossauria";
        private const string SubContinentName = "East Dinossauria";
        private const string CountryName = "Dinossaur Republic";
        private const string RegionName = "Central Dino Region";
        private const string CityName = "Dinossaur City";
        private const string CityRoadName = "Main Dino Road";

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            CleanDb.DoClean();
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void ClassCleanup()
        {
            CleanDb.DoClean();
        }

        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }

        #endregion

        // ReSharper disable InconsistentNaming

        #region Continent

        [TestMethod]
        public void Test_01_Create_Continent_To_Delete()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl.AddNew();
            continent.Continent_Name = ContinentName;
            continentColl = continentColl.Save();

            Assert.AreEqual(4, continentColl.Count);
            continent = continentColl[3];
            Assert.AreEqual(4, continent.Continent_ID);

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            Assert.AreEqual(4, continentColl.Count);
            continent = continentColl[3];
            Assert.AreEqual(ContinentName, continent.Continent_Name);
        }

        [TestMethod]
        public void Test_02_Delete_Continent()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(4, continent.Continent_ID);
            continentColl.Remove(4);
            continentColl.Save();

            continent.Continent_Name = "Deleted";
            try
            {
                continentColl.Save();
                Assert.Fail(continent.Continent_Name + " wasn't deleted.");
            }
            catch (Csla.DataPortalException ex)
            {
                //Assert.Fail(ex.GetBaseException().Message);
            }

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl.FindH02_ContinentByContinent_ID(4);
            Assert.IsNull(continent);
        }

        [TestMethod]
        public void Test_03_Create_Continent()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl.AddNew();
            continent.Continent_Name = ContinentName;
            continent.H03_Continent_SingleObject.Continent_Child_Name = ContinentName + " Child";
            continent.H03_Continent_ASingleObject.Continent_Child_Name = ContinentName + " ReChild";
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(5, continent.Continent_ID);

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(ContinentName, continent.Continent_Name);
            Assert.AreEqual(ContinentName + " Child", continent.H03_Continent_SingleObject.Continent_Child_Name);
            Assert.AreEqual(ContinentName + " ReChild", continent.H03_Continent_ASingleObject.Continent_Child_Name);
        }

        [TestMethod]
        public void Test_04_Edit_Continent()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            continent.Continent_Name += " Edited";
            continent.H03_Continent_SingleObject.Continent_Child_Name += " Edited";
            continent.H03_Continent_ASingleObject.Continent_Child_Name += " Edited";
            continentColl.Save();

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(ContinentName + " Edited", continent.Continent_Name);
            Assert.AreEqual(ContinentName + " Child" + " Edited", continent.H03_Continent_SingleObject.Continent_Child_Name);
            Assert.AreEqual(ContinentName + " ReChild" + " Edited", continent.H03_Continent_ASingleObject.Continent_Child_Name);
        }

        #endregion

        #region SubContinent

        [TestMethod]
        public void Test_05_Add_SubContinent_To_Delete()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(0, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects.AddNew();
            subContinent.SubContinent_Name = SubContinentName;
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(7, subContinent.SubContinent_ID);

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(SubContinentName, subContinent.SubContinent_Name);
        }

        [TestMethod]
        public void Test_06_Delete_SubContinent()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(7, subContinent.SubContinent_ID);
            continent.H03_SubContinentObjects.Remove(7);
            continentColl.Save();

            subContinent.SubContinent_Name = "Deleted";
            try
            {
                continentColl.Save();
                Assert.Fail(subContinent.SubContinent_Name + " wasn't deleted.");
            }
            catch (Csla.DataPortalException ex)
            {
                //Assert.Fail(ex.GetBaseException().Message);
            }

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(0, continent.H03_SubContinentObjects.Count);
        }

        [TestMethod]
        public void Test_07_Add_SubContinent()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(0, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects.AddNew();
            subContinent.SubContinent_Name = SubContinentName;
            subContinent.H05_SubContinent_SingleObject.SubContinent_Child_Name = SubContinentName + " Child";
            subContinent.H05_SubContinent_ASingleObject.SubContinent_Child_Name = SubContinentName + " ReChild";
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(8, subContinent.SubContinent_ID);

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(SubContinentName, subContinent.SubContinent_Name);
            Assert.AreEqual(SubContinentName + " Child", subContinent.H05_SubContinent_SingleObject.SubContinent_Child_Name);
            Assert.AreEqual(SubContinentName + " ReChild", subContinent.H05_SubContinent_ASingleObject.SubContinent_Child_Name);
        }

        [TestMethod]
        public void Test_08_Edit_SubContinent()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects.FindH04_SubContinentBySubContinent_ID(8);
            subContinent.SubContinent_Name += " Edited";
            subContinent.H05_SubContinent_SingleObject.SubContinent_Child_Name += " Edited";
            subContinent.H05_SubContinent_ASingleObject.SubContinent_Child_Name += " Edited";
            continentColl.Save();

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(SubContinentName + " Edited", subContinent.SubContinent_Name);
            Assert.AreEqual(SubContinentName + " Child" + " Edited", subContinent.H05_SubContinent_SingleObject.SubContinent_Child_Name);
            Assert.AreEqual(SubContinentName + " ReChild" + " Edited", subContinent.H05_SubContinent_ASingleObject.SubContinent_Child_Name);
        }

        #endregion

        #region Country

        [TestMethod]
        public void Test_09_Add_Country_To_Delete()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(0, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects.AddNew();
            country.Country_Name = CountryName;
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(10, country.Country_ID);

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(CountryName, country.Country_Name);
        }

        [TestMethod]
        public void Test_10_Delete_Country()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(10, country.Country_ID);
            subContinent.H05_CountryObjects.Remove(10);
            continentColl.Save();

            country.Country_Name = "Deleted";
            try
            {
                continentColl.Save();
                Assert.Fail(country.Country_Name + " wasn't deleted.");
            }
            catch (Csla.DataPortalException ex)
            {
                //Assert.Fail(ex.GetBaseException().Message);
            }

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(0, subContinent.H05_CountryObjects.Count);
        }

        [TestMethod]
        public void Test_11_Add_Country()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(0, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects.AddNew();
            country.Country_Name = CountryName;
            country.H07_Country_SingleObject.Country_Child_Name = CountryName + " Child";
            country.H07_Country_ASingleObject.Country_Child_Name = CountryName + " ReChild";
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(11, country.Country_ID);

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(CountryName, country.Country_Name);
            Assert.AreEqual(CountryName + " Child", country.H07_Country_SingleObject.Country_Child_Name);
            Assert.AreEqual(CountryName + " ReChild", country.H07_Country_ASingleObject.Country_Child_Name);
        }

        [TestMethod]
        public void Test_12_Edit_Country()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects.FindH06_CountryByCountry_ID(11);
            country.Country_Name += " Edited";
            country.H07_Country_SingleObject.Country_Child_Name += " Edited";
            country.H07_Country_ASingleObject.Country_Child_Name += " Edited";
            continentColl.Save();

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(CountryName + " Edited", country.Country_Name);
            Assert.AreEqual(CountryName + " Child" + " Edited", country.H07_Country_SingleObject.Country_Child_Name);
            Assert.AreEqual(CountryName + " ReChild" + " Edited", country.H07_Country_ASingleObject.Country_Child_Name);
        }

        #endregion

        #region Region

        [TestMethod]
        public void Test_13_Add_Region_To_Delete()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(0, country.H07_RegionObjects.Count);
            var region = country.H07_RegionObjects.AddNew();
            region.Region_Name = RegionName;
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(28, region.Region_ID);

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(RegionName, region.Region_Name);
        }

        [TestMethod]
        public void Test_14_Delete_Region()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            var region = country.H07_RegionObjects[0];
            Assert.AreEqual(28, region.Region_ID);
            country.H07_RegionObjects.Remove(28);
            continentColl.Save();

            region.Region_Name= "Deleted";
            try
            {
                continentColl.Save();
                Assert.Fail(region.Region_Name + " wasn't deleted.");
            }
            catch (Csla.DataPortalException ex)
            {
                //Assert.Fail(ex.GetBaseException().Message);
            }

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(0, country.H07_RegionObjects.Count);
        }

        [TestMethod]
        public void Test_15_Add_Region()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(0, country.H07_RegionObjects.Count);
            var region = country.H07_RegionObjects.AddNew();
            region.Region_Name = RegionName;
            region.H09_Region_SingleObject.Region_Child_Name = RegionName + " Child";
            region.H09_Region_ASingleObject.Region_Child_Name = RegionName + " ReChild";
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(29, region.Region_ID);

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(RegionName, region.Region_Name);
            Assert.AreEqual(RegionName + " Child", region.H09_Region_SingleObject.Region_Child_Name);
            Assert.AreEqual(RegionName + " ReChild", region.H09_Region_ASingleObject.Region_Child_Name);
        }

        [TestMethod]
        public void Test_16_Edit_Region()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            var region = country.H07_RegionObjects.FindH08_RegionByRegion_ID(29);
            region.Region_Name += " Edited";
            region.H09_Region_SingleObject.Region_Child_Name += " Edited";
            region.H09_Region_ASingleObject.Region_Child_Name += " Edited";
            continentColl.Save();

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(RegionName + " Edited", region.Region_Name);
            Assert.AreEqual(RegionName + " Child" + " Edited", region.H09_Region_SingleObject.Region_Child_Name);
            Assert.AreEqual(RegionName + " ReChild" + " Edited", region.H09_Region_ASingleObject.Region_Child_Name);
        }

        #endregion

        #region City

        [TestMethod]
        public void Test_17_Add_City_To_Delete()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            var region = country.H07_RegionObjects[0];
            Assert.AreEqual(0, region.H09_CityObjects.Count);
            var city = region.H09_CityObjects.AddNew();
            city.City_Name = CityName;
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            city = region.H09_CityObjects[0];
            Assert.AreEqual(28, city.City_ID);

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            city = region.H09_CityObjects[0];
            Assert.AreEqual(CityName, city.City_Name);
        }

        [TestMethod]
        public void Test_18_Delete_City()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            var region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            var city = region.H09_CityObjects[0];
            Assert.AreEqual(28, city.City_ID);
            region.H09_CityObjects.Remove(28);
            continentColl.Save();

            city.City_Name = "Deleted";
            try
            {
                continentColl.Save();
                Assert.Fail(city.City_Name + " wasn't deleted.");
            }
            catch (Csla.DataPortalException ex)
            {
                //Assert.Fail(ex.GetBaseException().Message);
            }

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(0, region.H09_CityObjects.Count);
        }

        [TestMethod]
        public void Test_19_Add_City()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            var region = country.H07_RegionObjects[0];
            Assert.AreEqual(0, region.H09_CityObjects.Count);
            var city = region.H09_CityObjects.AddNew();
            city.City_Name = CityName;
            city.H11_City_SingleObject.City_Child_Name = CityName + " Child";
            city.H11_City_ASingleObject.City_Child_Name = CityName + " ReChild";
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            city = region.H09_CityObjects[0];
            Assert.AreEqual(29, city.City_ID);

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            city = region.H09_CityObjects[0];
            Assert.AreEqual(CityName, city.City_Name);
            Assert.AreEqual(CityName + " Child", city.H11_City_SingleObject.City_Child_Name);
            Assert.AreEqual(CityName + " ReChild", city.H11_City_ASingleObject.City_Child_Name);
        }

        [TestMethod]
        public void Test_20_Edit_City()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            var region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            var city = region.H09_CityObjects.FindH10_CityByCity_ID(29);
            city.City_Name += " Edited";
            city.H11_City_SingleObject.City_Child_Name += " Edited";
            city.H11_City_ASingleObject.City_Child_Name += " Edited";
            continentColl.Save();

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            city = region.H09_CityObjects[0];
            Assert.AreEqual(CityName + " Edited", city.City_Name);
            Assert.AreEqual(CityName + " Child" + " Edited", city.H11_City_SingleObject.City_Child_Name);
            Assert.AreEqual(CityName + " ReChild" + " Edited", city.H11_City_ASingleObject.City_Child_Name);
        }

        #endregion

        #region CityRoad

        [TestMethod]
        public void Test_21_Add_CityRoad_To_Delete()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            var region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            var city = region.H09_CityObjects[0];
            Assert.AreEqual(0, city.H11_CityRoadObjects.Count);
            var cityRoad = city.H11_CityRoadObjects.AddNew();
            cityRoad.CityRoad_Name = CityRoadName;
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            city = region.H09_CityObjects[0];
            Assert.AreEqual(1, city.H11_CityRoadObjects.Count);
            cityRoad = city.H11_CityRoadObjects[0];
            Assert.AreEqual(82, cityRoad.CityRoad_ID);

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            city = region.H09_CityObjects[0];
            Assert.AreEqual(1, city.H11_CityRoadObjects.Count);
            cityRoad = city.H11_CityRoadObjects[0];
            Assert.AreEqual(CityRoadName, cityRoad.CityRoad_Name);
        }

        [TestMethod]
        public void Test_22_Delete_CityRoad()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            var region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            var city = region.H09_CityObjects[0];
            Assert.AreEqual(1, city.H11_CityRoadObjects.Count);
            var cityRoad = city.H11_CityRoadObjects[0];
            Assert.AreEqual(82, cityRoad.CityRoad_ID);
            city.H11_CityRoadObjects.Remove(82);
            continentColl.Save();

            cityRoad.CityRoad_Name = "Deleted";
            try
            {
                continentColl.Save();
                Assert.Fail(cityRoad.CityRoad_Name + " wasn't deleted.");
            }
            catch (Csla.DataPortalException ex)
            {
                //Assert.Fail(ex.GetBaseException().Message);
            }

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            city = region.H09_CityObjects[0];
            Assert.AreEqual(0, city.H11_CityRoadObjects.Count);
        }

        [TestMethod]
        public void Test_23_Add_CityRoad()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            var region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            var city = region.H09_CityObjects[0];
            Assert.AreEqual(0, city.H11_CityRoadObjects.Count);
            var cityRoad = city.H11_CityRoadObjects.AddNew();
            cityRoad.CityRoad_Name = CityRoadName;
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            city = region.H09_CityObjects[0];
            Assert.AreEqual(1, city.H11_CityRoadObjects.Count);
            cityRoad = city.H11_CityRoadObjects[0];
            Assert.AreEqual(83, cityRoad.CityRoad_ID);

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            city = region.H09_CityObjects[0];
            Assert.AreEqual(1, city.H11_CityRoadObjects.Count);
            cityRoad = city.H11_CityRoadObjects[0];
            Assert.AreEqual(CityRoadName, cityRoad.CityRoad_Name);
        }

        [TestMethod]
        public void Test_24_Edit_CityRoad()
        {
            var continentColl = H01_ContinentColl.GetH01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            var subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            var country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            var region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            var city = region.H09_CityObjects[0];
            Assert.AreEqual(1, city.H11_CityRoadObjects.Count);
            var cityRoad = city.H11_CityRoadObjects[0];
            cityRoad.CityRoad_Name += " Edited";
            continentColl.Save();

            continentColl = H01_ContinentColl.GetH01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.H03_SubContinentObjects.Count);
            subContinent = continent.H03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.H05_CountryObjects.Count);
            country = subContinent.H05_CountryObjects[0];
            Assert.AreEqual(1, country.H07_RegionObjects.Count);
            region = country.H07_RegionObjects[0];
            Assert.AreEqual(1, region.H09_CityObjects.Count);
            city = region.H09_CityObjects[0];
            Assert.AreEqual(1, city.H11_CityRoadObjects.Count);
            cityRoad = city.H11_CityRoadObjects[0];
            Assert.AreEqual(CityRoadName + " Edited", cityRoad.CityRoad_Name);
        }

        #endregion

        // ReSharper restore InconsistentNaming
    }
}
