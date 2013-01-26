using System;
using ParentLoadROSoftDelete.Business.ERLevel;

namespace DeepLoadBench
{
    public class ParentLoadROTestE
    {
// ReSharper disable InconsistentNaming
        public void FetchTest()
        {
            var e02_Continent = E02_Continent.GetE02_Continent(1);
            Console.WriteLine("Continent: " + e02_Continent.Continent_Name);
            Console.WriteLine("- Person = " + e02_Continent.E03_Continent_SingleObject.Continent_Child_Name);
            Console.WriteLine("- People = " + e02_Continent.E03_Continent_ASingleObject.Continent_Child_Name);
            foreach (var e04_SubContinent in e02_Continent.E03_SubContinentObjects)
            {
                Console.WriteLine("\tSub-continent: " + e04_SubContinent.SubContinent_Name);
                Console.WriteLine("\t- Person = " + e04_SubContinent.E05_SubContinent_SingleObject.SubContinent_Child_Name);
                Console.WriteLine("\t- People = " + e04_SubContinent.E05_SubContinent_ASingleObject.SubContinent_Child_Name);
                foreach (var e06_Country in e04_SubContinent.E05_CountryObjects)
                {
                    Console.WriteLine("\t\tCountry: " + e06_Country.Country_Name);
                    Console.WriteLine("\t\t- Person = " + e06_Country.E07_Country_SingleObject.Country_Child_Name);
                    Console.WriteLine("\t\t- People = " + e06_Country.E07_Country_ASingleObject.Country_Child_Name);
                    foreach (var e08_Region in e06_Country.E07_RegionObjects)
                    {
                        Console.WriteLine("\t\t\tRegion/State: " + e08_Region.Region_Name);
                        Console.WriteLine("\t\t\t- Person = " + e08_Region.E09_Region_SingleObject.Region_Child_Name);
                        Console.WriteLine("\t\t\t- People = " + e08_Region.E09_Region_ASingleObject.Region_Child_Name);
                        foreach (var e10_City in e08_Region.E09_CityObjects)
                        {
                            Console.WriteLine("\t\t\t\tCity: " + e10_City.City_Name);
                            Console.WriteLine("\t\t\t\t- Person = " + e10_City.E11_City_SingleObject.City_Child_Name);
                            Console.WriteLine("\t\t\t\t- People = " + e10_City.E11_City_ASingleObject.City_Child_Name);
                            foreach (var e12_CityRoad in e10_City.E11_CityRoadObjects)
                            {
                                Console.WriteLine("\t\t\t\t\tRoad: " + e12_CityRoad.CityRoad_Name);
                            }
                        }
                    }
                }
            }
        }
// ReSharper restore InconsistentNaming
    }
}
