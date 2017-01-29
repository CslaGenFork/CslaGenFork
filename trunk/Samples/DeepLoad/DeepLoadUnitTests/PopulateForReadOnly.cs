using ParentLoad.Business.ERCLevel;

namespace DeepLoadUnitTests
{
    internal static class PopulateForReadOnly
    {
        private const string ContinentName = "Dinossauria";
        private const string SubContinentName = "East Dinossauria";
        private const string CountryName = "Dinossaur Republic";
        private const string RegionName = "Central Dino Region";
        private const string CityName = "Dinossaur City";
        private const string CityRoadName = "Main Dino Road";

        internal static void DoPopulate()
        {
            var continentColl = B01_ContinentColl.GetB01_ContinentColl();

            var continent = continentColl.AddNew();
            continent.Continent_Name = ContinentName;
            continent.B03_Continent_SingleObject.Continent_Child_Name = ContinentName + " Child";
            continent.B03_Continent_ASingleObject.Continent_Child_Name = ContinentName + " ReChild";

            var subContinent = continent.B03_SubContinentObjects.AddNew();
            subContinent.SubContinent_Name = SubContinentName;
            subContinent.B05_SubContinent_SingleObject.SubContinent_Child_Name = SubContinentName + " Child";
            subContinent.B05_SubContinent_ASingleObject.SubContinent_Child_Name = SubContinentName + " ReChild";

            var country = subContinent.B05_CountryObjects.AddNew();
            country.Country_Name = CountryName;
            country.B07_Country_SingleObject.Country_Child_Name = CountryName + " Child";
            country.B07_Country_ASingleObject.Country_Child_Name = CountryName + " ReChild";

            var region = country.B07_RegionObjects.AddNew();
            region.Region_Name = RegionName;
            region.B09_Region_SingleObject.Region_Child_Name = RegionName + " Child";
            region.B09_Region_ASingleObject.Region_Child_Name = RegionName + " ReChild";

            var city = region.B09_CityObjects.AddNew();
            city.City_Name = CityName;
            city.B11_City_SingleObject.City_Child_Name = CityName + " Child";
            city.B11_City_ASingleObject.City_Child_Name = CityName + " ReChild";

            var cityRoad = city.B11_CityRoadObjects.AddNew();
            cityRoad.CityRoad_Name = CityRoadName;
            
            continentColl = continentColl.Save();
        }
    }
}
