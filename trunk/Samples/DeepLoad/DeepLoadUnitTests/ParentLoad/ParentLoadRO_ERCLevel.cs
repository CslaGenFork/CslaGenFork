using ParentLoadRO.Business.ERCLevel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeepLoadUnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ParentLoadRO_ERCLevel
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
            PopulateForReadOnly.DoPopulate();
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

        [TestMethod]
        public void Test_1_Continent()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(4, continent.Continent_ID);
            Assert.AreEqual(ContinentName, continent.Continent_Name);
            Assert.AreEqual(ContinentName + " Child", continent.B03_Continent_SingleObject.Continent_Child_Name);
            Assert.AreEqual(ContinentName + " ReChild", continent.B03_Continent_ASingleObject.Continent_Child_Name);
        }

        [TestMethod]
        public void Test_2_SubContinent()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(7, subContinent.SubContinent_ID);
            Assert.AreEqual(SubContinentName, subContinent.SubContinent_Name);
            Assert.AreEqual(SubContinentName + " Child", subContinent.B05_SubContinent_SingleObject.SubContinent_Child_Name);
            Assert.AreEqual(SubContinentName + " ReChild", subContinent.B05_SubContinent_ASingleObject.SubContinent_Child_Name);
        }

        [TestMethod]
        public void Test_3_Country()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            var country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(10, country.Country_ID);
            Assert.AreEqual(CountryName, country.Country_Name);
            Assert.AreEqual(CountryName + " Child", country.B07_Country_SingleObject.Country_Child_Name);
            Assert.AreEqual(CountryName + " ReChild", country.B07_Country_ASingleObject.Country_Child_Name);
        }

        [TestMethod]
        public void Test_4_Region()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            var country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            var region = country.B07_RegionObjects[0];
            Assert.AreEqual(28, region.Region_ID);
            Assert.AreEqual(RegionName, region.Region_Name);
            Assert.AreEqual(RegionName + " Child", region.B09_Region_SingleObject.Region_Child_Name);
            Assert.AreEqual(RegionName + " ReChild", region.B09_Region_ASingleObject.Region_Child_Name);
        }

        [TestMethod]
        public void Test_5_City()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            var country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            var region = country.B07_RegionObjects[0];
            Assert.AreEqual(1, region.B09_CityObjects.Count);
            var city = region.B09_CityObjects[0];
            Assert.AreEqual(28, city.City_ID);
            Assert.AreEqual(CityName, city.City_Name);
            Assert.AreEqual(CityName + " Child", city.B11_City_SingleObject.City_Child_Name);
            Assert.AreEqual(CityName + " ReChild", city.B11_City_ASingleObject.City_Child_Name);
        }

        [TestMethod]
        public void Test_6_CityRoad()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            var country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            var region = country.B07_RegionObjects[0];
            Assert.AreEqual(1, region.B09_CityObjects.Count);
            var city = region.B09_CityObjects[0];
            Assert.AreEqual(1, city.B11_CityRoadObjects.Count);
            var cityRoad = city.B11_CityRoadObjects[0];
            Assert.AreEqual(82, cityRoad.CityRoad_ID);
            Assert.AreEqual(CityRoadName, cityRoad.CityRoad_Name);
        }

        // ReSharper restore InconsistentNaming
    }
}
