using System;
using ParentLoadSoftDelete.Business.ERLevel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeepLoadUnitTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ParentLoadSoftDelete_ERLevel
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
            var continent = E02_Continent.NewE02_Continent();
            continent.Continent_Name = ContinentName;
            continent = continent.Save();

            Assert.AreEqual(4, continent.Continent_ID);

            continent = E02_Continent.GetE02_Continent(4);
            Assert.AreEqual(ContinentName, continent.Continent_Name);
        }

        [TestMethod]
        public void Test_02_Delete_Continent()
        {
            var continent = E02_Continent.GetE02_Continent(4);
            E02_Continent.DeleteE02_Continent(4);

            continent.Continent_Name = "Deleted";
            try
            {
                continent = continent.Save();
                Assert.Fail(continent.Continent_Name + " wasn't deleted.");
            }
            catch (Csla.DataPortalException ex)
            {
                //Assert.Fail(ex.GetBaseException().Message);
            }

            continent = E02_Continent.GetE02_Continent(4);
            if (continent.Continent_ID == 4)
                Assert.Fail(continent.Continent_Name + " wasn't deleted.");
        }

        [TestMethod]
        public void Test_03_Create_Continent()
        {
            var continent = E02_Continent.NewE02_Continent();
            continent.Continent_Name = ContinentName;
            continent.E03_Continent_SingleObject.Continent_Child_Name = ContinentName + " Child";
            continent.E03_Continent_ASingleObject.Continent_Child_Name = ContinentName + " ReChild";
            continent = continent.Save();

            Assert.AreEqual(5, continent.Continent_ID);

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(ContinentName, continent.Continent_Name);
            Assert.AreEqual(ContinentName + " Child", continent.E03_Continent_SingleObject.Continent_Child_Name);
            Assert.AreEqual(ContinentName + " ReChild", continent.E03_Continent_ASingleObject.Continent_Child_Name);
        }

        [TestMethod]
        public void Test_04_Edit_Continent()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            continent.Continent_Name += " Edited";
            continent.E03_Continent_SingleObject.Continent_Child_Name += " Edited";
            continent.E03_Continent_ASingleObject.Continent_Child_Name += " Edited";
            continent = continent.Save();

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(ContinentName + " Edited", continent.Continent_Name);
            Assert.AreEqual(ContinentName + " Child" + " Edited", continent.E03_Continent_SingleObject.Continent_Child_Name);
            Assert.AreEqual(ContinentName + " ReChild" + " Edited", continent.E03_Continent_ASingleObject.Continent_Child_Name);
        }

        #endregion

        #region SubContinent

        [TestMethod]
        public void Test_05_Add_SubContinent_To_Delete()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(0, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects.AddNew();
            subContinent.SubContinent_Name = SubContinentName;
            continent = continent.Save();

            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(7, subContinent.SubContinent_ID);

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(SubContinentName, subContinent.SubContinent_Name);
        }

        [TestMethod]
        public void Test_06_Delete_SubContinent()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(7, subContinent.SubContinent_ID);
            continent.E03_SubContinentObjects.Remove(7);
            continent = continent.Save();

            subContinent.SubContinent_Name = "Deleted";
            try
            {
                continent = continent.Save();
                Assert.Fail(subContinent.SubContinent_Name + " wasn't deleted.");
            }
            catch (Csla.DataPortalException ex)
            {
                //Assert.Fail(ex.GetBaseException().Message);
            }

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(0, continent.E03_SubContinentObjects.Count);
        }

        [TestMethod]
        public void Test_07_Add_SubContinent()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(0, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects.AddNew();
            subContinent.SubContinent_Name = SubContinentName;
            subContinent.E05_SubContinent_SingleObject.SubContinent_Child_Name = SubContinentName + " Child";
            subContinent.E05_SubContinent_ASingleObject.SubContinent_Child_Name = SubContinentName + " ReChild";
            continent = continent.Save();

            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(8, subContinent.SubContinent_ID);

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(SubContinentName, subContinent.SubContinent_Name);
            Assert.AreEqual(SubContinentName + " Child", subContinent.E05_SubContinent_SingleObject.SubContinent_Child_Name);
            Assert.AreEqual(SubContinentName + " ReChild", subContinent.E05_SubContinent_ASingleObject.SubContinent_Child_Name);
        }

        [TestMethod]
        public void Test_08_Edit_SubContinent()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects.FindE04_SubContinentByParentProperties(8);
            subContinent.SubContinent_Name += " Edited";
            subContinent.E05_SubContinent_SingleObject.SubContinent_Child_Name += " Edited";
            subContinent.E05_SubContinent_ASingleObject.SubContinent_Child_Name += " Edited";
            continent = continent.Save();

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(SubContinentName + " Edited", subContinent.SubContinent_Name);
            Assert.AreEqual(SubContinentName + " Child" + " Edited", subContinent.E05_SubContinent_SingleObject.SubContinent_Child_Name);
            Assert.AreEqual(SubContinentName + " ReChild" + " Edited", subContinent.E05_SubContinent_ASingleObject.SubContinent_Child_Name);
        }

        #endregion

        #region Country

        [TestMethod]
        public void Test_09_Add_Country_To_Delete()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(0, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects.AddNew();
            country.Country_Name = CountryName;
            continent = continent.Save();

            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(10, country.Country_ID);

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(CountryName, country.Country_Name);
        }

        [TestMethod]
        public void Test_10_Delete_Country()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(10, country.Country_ID);
            subContinent.E05_CountryObjects.Remove(10);
            continent = continent.Save();

            country.Country_Name = "Deleted";
            try
            {
                continent = continent.Save();
                Assert.Fail(country.Country_Name + " wasn't deleted.");
            }
            catch (Csla.DataPortalException ex)
            {
                //Assert.Fail(ex.GetBaseException().Message);
            }

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(0, subContinent.E05_CountryObjects.Count);
        }

        [TestMethod]
        public void Test_11_Add_Country()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(0, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects.AddNew();
            country.Country_Name = CountryName;
            country.E07_Country_SingleObject.Country_Child_Name = CountryName + " Child";
            country.E07_Country_ASingleObject.Country_Child_Name = CountryName + " ReChild";
            continent = continent.Save();

            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(11, country.Country_ID);

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(CountryName, country.Country_Name);
            Assert.AreEqual(CountryName + " Child", country.E07_Country_SingleObject.Country_Child_Name);
            Assert.AreEqual(CountryName + " ReChild", country.E07_Country_ASingleObject.Country_Child_Name);
        }

        [TestMethod]
        public void Test_12_Edit_Country()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects.FindE06_CountryByParentProperties(11);
            country.Country_Name += " Edited";
            country.E07_Country_SingleObject.Country_Child_Name += " Edited";
            country.E07_Country_ASingleObject.Country_Child_Name += " Edited";
            continent = continent.Save();

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(CountryName + " Edited", country.Country_Name);
            Assert.AreEqual(CountryName + " Child" + " Edited", country.E07_Country_SingleObject.Country_Child_Name);
            Assert.AreEqual(CountryName + " ReChild" + " Edited", country.E07_Country_ASingleObject.Country_Child_Name);
        }

        #endregion

        #region Region

        [TestMethod]
        public void Test_13_Add_Region_To_Delete()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(0, country.E07_RegionObjects.Count);
            var region = country.E07_RegionObjects.AddNew();
            region.Region_Name = RegionName;
            continent = continent.Save();

            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(28, region.Region_ID);

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(RegionName, region.Region_Name);
        }

        [TestMethod]
        public void Test_14_Delete_Region()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            var region = country.E07_RegionObjects[0];
            Assert.AreEqual(28, region.Region_ID);
            country.E07_RegionObjects.Remove(28);
            continent = continent.Save();

            region.Region_Name = "Deleted";
            try
            {
                continent = continent.Save();
                Assert.Fail(region.Region_Name + " wasn't deleted.");
            }
            catch (Csla.DataPortalException ex)
            {
                //Assert.Fail(ex.GetBaseException().Message);
            }

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(0, country.E07_RegionObjects.Count);
        }

        [TestMethod]
        public void Test_15_Add_Region()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(0, country.E07_RegionObjects.Count);
            var region = country.E07_RegionObjects.AddNew();
            region.Region_Name = RegionName;
            region.E09_Region_SingleObject.Region_Child_Name = RegionName + " Child";
            region.E09_Region_ASingleObject.Region_Child_Name = RegionName + " ReChild";
            continent = continent.Save();

            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(29, region.Region_ID);

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(RegionName, region.Region_Name);
            Assert.AreEqual(RegionName + " Child", region.E09_Region_SingleObject.Region_Child_Name);
            Assert.AreEqual(RegionName + " ReChild", region.E09_Region_ASingleObject.Region_Child_Name);
        }

        [TestMethod]
        public void Test_16_Edit_Region()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            var region = country.E07_RegionObjects.FindE08_RegionByParentProperties(29);
            region.Region_Name += " Edited";
            region.E09_Region_SingleObject.Region_Child_Name += " Edited";
            region.E09_Region_ASingleObject.Region_Child_Name += " Edited";
            continent = continent.Save();

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(RegionName + " Edited", region.Region_Name);
            Assert.AreEqual(RegionName + " Child" + " Edited", region.E09_Region_SingleObject.Region_Child_Name);
            Assert.AreEqual(RegionName + " ReChild" + " Edited", region.E09_Region_ASingleObject.Region_Child_Name);
        }

        #endregion

        #region City

        [TestMethod]
        public void Test_17_Add_City_To_Delete()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            var region = country.E07_RegionObjects[0];
            Assert.AreEqual(0, region.E09_CityObjects.Count);
            var city = region.E09_CityObjects.AddNew();
            city.City_Name = CityName;
            continent = continent.Save();

            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            city = region.E09_CityObjects[0];
            Assert.AreEqual(28, city.City_ID);

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            city = region.E09_CityObjects[0];
            Assert.AreEqual(CityName, city.City_Name);
        }

        [TestMethod]
        public void Test_18_Delete_City()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            var region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            var city = region.E09_CityObjects[0];
            Assert.AreEqual(28, city.City_ID);
            region.E09_CityObjects.Remove(28);
            continent = continent.Save();

            city.City_Name = "Deleted";
            try
            {
                continent = continent.Save();
                Assert.Fail(city.City_Name + " wasn't deleted.");
            }
            catch (Csla.DataPortalException ex)
            {
                //Assert.Fail(ex.GetBaseException().Message);
            }

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(0, region.E09_CityObjects.Count);
        }

        [TestMethod]
        public void Test_19_Add_City()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            var region = country.E07_RegionObjects[0];
            Assert.AreEqual(0, region.E09_CityObjects.Count);
            var city = region.E09_CityObjects.AddNew();
            city.City_Name = CityName;
            city.E11_City_SingleObject.City_Child_Name = CityName + " Child";
            city.E11_City_ASingleObject.City_Child_Name = CityName + " ReChild";
            continent = continent.Save();

            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            city = region.E09_CityObjects[0];
            Assert.AreEqual(29, city.City_ID);

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            city = region.E09_CityObjects[0];
            Assert.AreEqual(CityName, city.City_Name);
            Assert.AreEqual(CityName + " Child", city.E11_City_SingleObject.City_Child_Name);
            Assert.AreEqual(CityName + " ReChild", city.E11_City_ASingleObject.City_Child_Name);
        }

        [TestMethod]
        public void Test_20_Edit_City()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            var region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            var city = region.E09_CityObjects.FindE10_CityByParentProperties(29);
            city.City_Name += " Edited";
            city.E11_City_SingleObject.City_Child_Name += " Edited";
            city.E11_City_ASingleObject.City_Child_Name += " Edited";
            continent = continent.Save();

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            city = region.E09_CityObjects[0];
            Assert.AreEqual(CityName + " Edited", city.City_Name);
            Assert.AreEqual(CityName + " Child" + " Edited", city.E11_City_SingleObject.City_Child_Name);
            Assert.AreEqual(CityName + " ReChild" + " Edited", city.E11_City_ASingleObject.City_Child_Name);
        }

        #endregion

        #region CityRoad

        [TestMethod]
        public void Test_21_Add_CityRoad_To_Delete()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            var region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            var city = region.E09_CityObjects[0];
            Assert.AreEqual(0, city.E11_CityRoadObjects.Count);
            var cityRoad = city.E11_CityRoadObjects.AddNew();
            cityRoad.CityRoad_Name = CityRoadName;
            continent = continent.Save();

            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            city = region.E09_CityObjects[0];
            Assert.AreEqual(1, city.E11_CityRoadObjects.Count);
            cityRoad = city.E11_CityRoadObjects[0];
            Assert.AreEqual(82, cityRoad.CityRoad_ID);

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            city = region.E09_CityObjects[0];
            Assert.AreEqual(1, city.E11_CityRoadObjects.Count);
            cityRoad = city.E11_CityRoadObjects[0];
            Assert.AreEqual(CityRoadName, cityRoad.CityRoad_Name);
        }

        [TestMethod]
        public void Test_22_Delete_CityRoad()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            var region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            var city = region.E09_CityObjects[0];
            Assert.AreEqual(1, city.E11_CityRoadObjects.Count);
            var cityRoad = city.E11_CityRoadObjects[0];
            Assert.AreEqual(82, cityRoad.CityRoad_ID);
            city.E11_CityRoadObjects.Remove(82);
            continent = continent.Save();

            cityRoad.CityRoad_Name = "Deleted";
            try
            {
                continent = continent.Save();
                Assert.Fail(cityRoad.CityRoad_Name + " wasn't deleted.");
            }
            catch (Csla.DataPortalException ex)
            {
                //Assert.Fail(ex.GetBaseException().Message);
            }

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            city = region.E09_CityObjects[0];
            Assert.AreEqual(0, city.E11_CityRoadObjects.Count);
        }

        [TestMethod]
        public void Test_23_Add_CityRoad()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            var region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            var city = region.E09_CityObjects[0];
            Assert.AreEqual(0, city.E11_CityRoadObjects.Count);
            var cityRoad = city.E11_CityRoadObjects.AddNew();
            cityRoad.CityRoad_Name = CityRoadName;
            continent = continent.Save();

            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            city = region.E09_CityObjects[0];
            Assert.AreEqual(1, city.E11_CityRoadObjects.Count);
            cityRoad = city.E11_CityRoadObjects[0];
            Assert.AreEqual(83, cityRoad.CityRoad_ID);

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            city = region.E09_CityObjects[0];
            Assert.AreEqual(1, city.E11_CityRoadObjects.Count);
            cityRoad = city.E11_CityRoadObjects[0];
            Assert.AreEqual(CityRoadName, cityRoad.CityRoad_Name);
        }

        [TestMethod]
        public void Test_24_Edit_CityRoad()
        {
            var continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            var subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            var country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            var region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            var city = region.E09_CityObjects[0];
            Assert.AreEqual(1, city.E11_CityRoadObjects.Count);
            var cityRoad = city.E11_CityRoadObjects[0];
            cityRoad.CityRoad_Name += " Edited";
            continent = continent.Save();

            continent = E02_Continent.GetE02_Continent(5);
            Assert.AreEqual(1, continent.E03_SubContinentObjects.Count);
            subContinent = continent.E03_SubContinentObjects[0];
            Assert.AreEqual(1, subContinent.E05_CountryObjects.Count);
            country = subContinent.E05_CountryObjects[0];
            Assert.AreEqual(1, country.E07_RegionObjects.Count);
            region = country.E07_RegionObjects[0];
            Assert.AreEqual(1, region.E09_CityObjects.Count);
            city = region.E09_CityObjects[0];
            Assert.AreEqual(1, city.E11_CityRoadObjects.Count);
            cityRoad = city.E11_CityRoadObjects[0];
            Assert.AreEqual(CityRoadName + " Edited", cityRoad.CityRoad_Name);
        }

        #endregion

        // ReSharper restore InconsistentNaming
    }
}
