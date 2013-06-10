using ParentLoad.Business.ERCLevel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeepLoadUnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ParentLoad_ERCLevel
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
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl.AddNew();
            continent.Continent_Name = ContinentName;
            continentColl = continentColl.Save();

            Assert.AreEqual(4, continentColl.Count);
            continent = continentColl[3];
            Assert.AreEqual(4, continent.Continent_ID);

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            Assert.AreEqual(4, continentColl.Count);
            continent = continentColl[3];
            Assert.AreEqual(ContinentName, continent.Continent_Name);
        }

        [TestMethod]
        public void Test_02_Delete_Continent()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(4, continent.Continent_ID);
            continentColl.Remove(4);
            continentColl = continentColl.Save();

            continent = continentColl.FindB02_ContinentByParentProperties(4);
            Assert.IsNull(continent);
        }

        [TestMethod]
        public void Test_03_Create_Continent()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl.AddNew();
            continent.Continent_Name = ContinentName;
            continent.B03_Continent_SingleObject.Continent_Child_Name = ContinentName + " Child";
            continent.B03_Continent_ASingleObject.Continent_Child_Name = ContinentName + " ReChild";
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(5, continent.Continent_ID);

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(ContinentName, continent.Continent_Name);
            Assert.AreEqual(ContinentName + " Child", continent.B03_Continent_SingleObject.Continent_Child_Name);
            Assert.AreEqual(ContinentName + " ReChild", continent.B03_Continent_ASingleObject.Continent_Child_Name);
        }

        [TestMethod]
        public void Test_04_Edit_Continent()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            continent.Continent_Name += " Edited";
            continent.B03_Continent_SingleObject.Continent_Child_Name += " Edited";
            continent.B03_Continent_ASingleObject.Continent_Child_Name += " Edited";
            continentColl.Save();

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(ContinentName + " Edited", continent.Continent_Name);
            Assert.AreEqual(ContinentName + " Child" + " Edited", continent.B03_Continent_SingleObject.Continent_Child_Name);
            Assert.AreEqual(ContinentName + " ReChild" + " Edited", continent.B03_Continent_ASingleObject.Continent_Child_Name);
        }

        #endregion

        #region SubContinent

        [TestMethod]
        public void Test_05_Add_SubContinent_To_Delete()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(0, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects.AddNew();
            subContinent.SubContinent_Name = SubContinentName;
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(7, subContinent.SubContinent_ID);

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(SubContinentName, subContinent.SubContinent_Name);
        }

        [TestMethod]
        public void Test_06_Delete_SubContinent()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(7, subContinent.SubContinent_ID);
            continent.B03_SubContinentObjects.Remove(7);
            continentColl.Save();

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(0, continent.B03_SubContinentObjects.Count);
        }

        [TestMethod]
        public void Test_07_Add_SubContinent()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(0, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects.AddNew();
            subContinent.SubContinent_Name = SubContinentName;
            subContinent.B05_SubContinent_SingleObject.SubContinent_Child_Name = SubContinentName + " Child";
            subContinent.B05_SubContinent_ASingleObject.SubContinent_Child_Name = SubContinentName + " ReChild";
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(8, subContinent.SubContinent_ID);

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(SubContinentName, subContinent.SubContinent_Name);
            Assert.AreEqual(SubContinentName + " Child", subContinent.B05_SubContinent_SingleObject.SubContinent_Child_Name);
            Assert.AreEqual(SubContinentName + " ReChild", subContinent.B05_SubContinent_ASingleObject.SubContinent_Child_Name);
        }

        [TestMethod]
        public void Test_08_Edit_SubContinent()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects.FindB04_SubContinentByParentProperties(8);
            subContinent.SubContinent_Name += " Edited";
            subContinent.B05_SubContinent_SingleObject.SubContinent_Child_Name += " Edited";
            subContinent.B05_SubContinent_ASingleObject.SubContinent_Child_Name += " Edited";
            continentColl.Save();

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(SubContinentName + " Edited", subContinent.SubContinent_Name);
            Assert.AreEqual(SubContinentName + " Child" + " Edited", subContinent.B05_SubContinent_SingleObject.SubContinent_Child_Name);
            Assert.AreEqual(SubContinentName + " ReChild" + " Edited", subContinent.B05_SubContinent_ASingleObject.SubContinent_Child_Name);
        }

        #endregion

        #region Country

        [TestMethod]
        public void Test_09_Add_Country_To_Delete()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(0, subContinent.B05_CountryObjects.Count);
            var country = subContinent.B05_CountryObjects.AddNew();
            country.Country_Name = CountryName;
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(10, country.Country_ID);

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(CountryName, country.Country_Name);
        }

        [TestMethod]
        public void Test_10_Delete_Country()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            var country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(10, country.Country_ID);
            subContinent.B05_CountryObjects.Remove(10);
            continentColl.Save();

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(0, subContinent.B05_CountryObjects.Count);
        }

        [TestMethod]
        public void Test_11_Add_Country()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(0, subContinent.B05_CountryObjects.Count);
            var country = subContinent.B05_CountryObjects.AddNew();
            country.Country_Name = CountryName;
            country.B07_Country_SingleObject.Country_Child_Name = CountryName + " Child";
            country.B07_Country_ASingleObject.Country_Child_Name = CountryName + " ReChild";
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(11, country.Country_ID);

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(CountryName, country.Country_Name);
            Assert.AreEqual(CountryName + " Child", country.B07_Country_SingleObject.Country_Child_Name);
            Assert.AreEqual(CountryName + " ReChild", country.B07_Country_ASingleObject.Country_Child_Name);
        }

        [TestMethod]
        public void Test_12_Edit_Country()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            var country = subContinent.B05_CountryObjects.FindB06_CountryByParentProperties(11);
            country.Country_Name += " Edited";
            country.B07_Country_SingleObject.Country_Child_Name += " Edited";
            country.B07_Country_ASingleObject.Country_Child_Name += " Edited";
            continentColl.Save();

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(CountryName + " Edited", country.Country_Name);
            Assert.AreEqual(CountryName + " Child" + " Edited", country.B07_Country_SingleObject.Country_Child_Name);
            Assert.AreEqual(CountryName + " ReChild" + " Edited", country.B07_Country_ASingleObject.Country_Child_Name);
        }

        #endregion

        #region Region

        [TestMethod]
        public void Test_13_Add_Region_To_Delete()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            var country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(0, country.B07_RegionObjects.Count);
            var region = country.B07_RegionObjects.AddNew();
            region.Region_Name = RegionName;
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(28, region.Region_ID);

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(RegionName, region.Region_Name);
        }

        [TestMethod]
        public void Test_14_Delete_Region()
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
            country.B07_RegionObjects.Remove(28);
            continentColl.Save();

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(0, country.B07_RegionObjects.Count);
        }

        [TestMethod]
        public void Test_15_Add_Region()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            var country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(0, country.B07_RegionObjects.Count);
            var region = country.B07_RegionObjects.AddNew();
            region.Region_Name = RegionName;
            region.B09_Region_SingleObject.Region_Child_Name = RegionName + " Child";
            region.B09_Region_ASingleObject.Region_Child_Name = RegionName + " ReChild";
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(29, region.Region_ID);

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(RegionName, region.Region_Name);
            Assert.AreEqual(RegionName + " Child", region.B09_Region_SingleObject.Region_Child_Name);
            Assert.AreEqual(RegionName + " ReChild", region.B09_Region_ASingleObject.Region_Child_Name);
        }

        [TestMethod]
        public void Test_16_Edit_Region()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            var country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            var region = country.B07_RegionObjects.FindB08_RegionByParentProperties(29);
            region.Region_Name += " Edited";
            region.B09_Region_SingleObject.Region_Child_Name += " Edited";
            region.B09_Region_ASingleObject.Region_Child_Name += " Edited";
            continentColl.Save();

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(RegionName + " Edited", region.Region_Name);
            Assert.AreEqual(RegionName + " Child" + " Edited", region.B09_Region_SingleObject.Region_Child_Name);
            Assert.AreEqual(RegionName + " ReChild" + " Edited", region.B09_Region_ASingleObject.Region_Child_Name);
        }

        #endregion

        #region City

        [TestMethod]
        public void Test_17_Add_City_To_Delete()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            var country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            var region = country.B07_RegionObjects[0];
            Assert.AreEqual(0, region.B09_CityObjects.Count);
            var city = region.B09_CityObjects.AddNew();
            city.City_Name = CityName;
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(1, region.B09_CityObjects.Count);
            city = region.B09_CityObjects[0];
            Assert.AreEqual(28, city.City_ID);

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(1, region.B09_CityObjects.Count);
            city = region.B09_CityObjects[0];
            Assert.AreEqual(CityName, city.City_Name);
        }

        [TestMethod]
        public void Test_18_Delete_City()
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
            region.B09_CityObjects.Remove(28);
            continentColl.Save();

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(0, region.B09_CityObjects.Count);
        }

        [TestMethod]
        public void Test_19_Add_City()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();
            var continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            var subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            var country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            var region = country.B07_RegionObjects[0];
            Assert.AreEqual(0, region.B09_CityObjects.Count);
            var city = region.B09_CityObjects.AddNew();
            city.City_Name = CityName;
            city.B11_City_SingleObject.City_Child_Name = CityName + " Child";
            city.B11_City_ASingleObject.City_Child_Name = CityName + " ReChild";
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(1, region.B09_CityObjects.Count);
            city = region.B09_CityObjects[0];
            Assert.AreEqual(29, city.City_ID);

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(1, region.B09_CityObjects.Count);
            city = region.B09_CityObjects[0];
            Assert.AreEqual(CityName, city.City_Name);
            Assert.AreEqual(CityName + " Child", city.B11_City_SingleObject.City_Child_Name);
            Assert.AreEqual(CityName + " ReChild", city.B11_City_ASingleObject.City_Child_Name);
        }

        [TestMethod]
        public void Test_20_Edit_City()
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
            var city = region.B09_CityObjects.FindB10_CityByParentProperties(29);
            city.City_Name += " Edited";
            city.B11_City_SingleObject.City_Child_Name += " Edited";
            city.B11_City_ASingleObject.City_Child_Name += " Edited";
            continentColl.Save();

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(1, region.B09_CityObjects.Count);
            city = region.B09_CityObjects[0];
            Assert.AreEqual(CityName + " Edited", city.City_Name);
            Assert.AreEqual(CityName + " Child" + " Edited", city.B11_City_SingleObject.City_Child_Name);
            Assert.AreEqual(CityName + " ReChild" + " Edited", city.B11_City_ASingleObject.City_Child_Name);
        }

        #endregion

        #region CityRoad

        [TestMethod]
        public void Test_21_Add_CityRoad_To_Delete()
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
            Assert.AreEqual(0, city.B11_CityRoadObjects.Count);
            var cityRoad = city.B11_CityRoadObjects.AddNew();
            cityRoad.CityRoad_Name = CityRoadName;
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(1, region.B09_CityObjects.Count);
            city = region.B09_CityObjects[0];
            Assert.AreEqual(1, city.B11_CityRoadObjects.Count);
            cityRoad = city.B11_CityRoadObjects[0];
            Assert.AreEqual(82, cityRoad.CityRoad_ID);

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(1, region.B09_CityObjects.Count);
            city = region.B09_CityObjects[0];
            Assert.AreEqual(1, city.B11_CityRoadObjects.Count);
            cityRoad = city.B11_CityRoadObjects[0];
            Assert.AreEqual(CityRoadName, cityRoad.CityRoad_Name);
        }

        [TestMethod]
        public void Test_22_Delete_CityRoad()
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
            city.B11_CityRoadObjects.Remove(82);
            continentColl.Save();

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(1, region.B09_CityObjects.Count);
            city = region.B09_CityObjects[0];
            Assert.AreEqual(0, city.B11_CityRoadObjects.Count);
        }

        [TestMethod]
        public void Test_23_Add_CityRoad()
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
            Assert.AreEqual(0, city.B11_CityRoadObjects.Count);
            var cityRoad = city.B11_CityRoadObjects.AddNew();
            cityRoad.CityRoad_Name = CityRoadName;
            continentColl = continentColl.Save();

            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(1, region.B09_CityObjects.Count);
            city = region.B09_CityObjects[0];
            Assert.AreEqual(1, city.B11_CityRoadObjects.Count);
            cityRoad = city.B11_CityRoadObjects[0];
            Assert.AreEqual(83, cityRoad.CityRoad_ID);

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(1, region.B09_CityObjects.Count);
            city = region.B09_CityObjects[0];
            Assert.AreEqual(1, city.B11_CityRoadObjects.Count);
            cityRoad = city.B11_CityRoadObjects[0];
            Assert.AreEqual(CityRoadName, cityRoad.CityRoad_Name);
        }

        [TestMethod]
        public void Test_24_Edit_CityRoad()
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
            cityRoad.CityRoad_Name += " Edited";
            continentColl.Save();

            continentColl = B01_ContinentColl.GetB01_ContinentColl();
            continent = continentColl[3];
            Assert.AreEqual(1, continent.B03_SubContinentObjects.Count);
            subContinent = continent.B03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.B05_CountryObjects.Count);
            country = subContinent.B05_CountryObjects[0];
            Assert.AreEqual(1, country.B07_RegionObjects.Count);
            region = country.B07_RegionObjects[0];
            Assert.AreEqual(1, region.B09_CityObjects.Count);
            city = region.B09_CityObjects[0];
            Assert.AreEqual(1, city.B11_CityRoadObjects.Count);
            cityRoad = city.B11_CityRoadObjects[0];
            Assert.AreEqual(CityRoadName + " Edited", cityRoad.CityRoad_Name);
        }

        #endregion

        // ReSharper restore InconsistentNaming
    }
}
