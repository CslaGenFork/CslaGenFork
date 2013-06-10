using System;
using SelfLoadSoftDelete.Business.ERLevel;

namespace DeepLoadBench
{
    public class SelfLoadTestG
    {
// ReSharper disable InconsistentNaming
        public void FetchTest()
        {
            var g02_Continent = G02_Continent.GetG02_Continent(1);
            Console.WriteLine("Continent: " + g02_Continent.Continent_Name);
            Console.WriteLine("- Person = " + g02_Continent.G03_Continent_SingleObject.Continent_Child_Name);
            Console.WriteLine("- People = " + g02_Continent.G03_Continent_ASingleObject.Continent_Child_Name);
            foreach (var g04_SubContinent in g02_Continent.G03_SubContinentObjects)
            {
                Console.WriteLine("\tSub-continent: " + g04_SubContinent.SubContinent_Name);
                Console.WriteLine("\t- Person = " + g04_SubContinent.G05_SubContinent_SingleObject.SubContinent_Child_Name);
                Console.WriteLine("\t- People = " + g04_SubContinent.G05_SubContinent_ASingleObject.SubContinent_Child_Name);
                foreach (var g06_Country in g04_SubContinent.G05_CountryObjects)
                {
                    Console.WriteLine("\t\tCountry: " + g06_Country.Country_Name);
                    Console.WriteLine("\t\t- Person = " + g06_Country.G07_Country_SingleObject.Country_Child_Name);
                    Console.WriteLine("\t\t- People = " + g06_Country.G07_Country_ASingleObject.Country_Child_Name);
                    foreach (var g08_Region in g06_Country.G07_RegionObjects)
                    {
                        Console.WriteLine("\t\t\tRegion/State: " + g08_Region.Region_Name);
                        Console.WriteLine("\t\t\t- Person = " + g08_Region.G09_Region_SingleObject.Region_Child_Name);
                        Console.WriteLine("\t\t\t- People = " + g08_Region.G09_Region_ASingleObject.Region_Child_Name);
                        foreach (var g10_City in g08_Region.G09_CityObjects)
                        {
                            Console.WriteLine("\t\t\t\tCity: " + g10_City.City_Name);
                            Console.WriteLine("\t\t\t\t- Person = " + g10_City.G11_City_SingleObject.City_Child_Name);
                            Console.WriteLine("\t\t\t\t- People = " + g10_City.G11_City_ASingleObject.City_Child_Name);
                            foreach (var g12_CityRoad in g10_City.G11_CityRoadObjects)
                            {
                                Console.WriteLine("\t\t\t\t\tRoad: " + g12_CityRoad.CityRoad_Name);
                            }
                        }
                    }
                }
            }
        }
// ReSharper restore InconsistentNaming
    }
}
