using System;
using SelfLoadRO.Business.ERLevel;

namespace DeepLoadBench
{
    public class SelfLoadROTestC
    {
// ReSharper disable InconsistentNaming
        public void FetchTest()
        {
            var c02_Continent = C02_Continent.GetC02_Continent(1);
            Console.WriteLine("Continent: " + c02_Continent.Continent_Name);
            Console.WriteLine("- Person = " + c02_Continent.C03_Continent_SingleObject.Continent_Child_Name);
            Console.WriteLine("- People = " + c02_Continent.C03_Continent_ASingleObject.Continent_Child_Name);
            foreach (var c04_SubContinent in c02_Continent.C03_SubContinentObjects)
            {
                Console.WriteLine("\tSub-continent: " + c04_SubContinent.SubContinent_Name);
                Console.WriteLine("\t- Person = " + c04_SubContinent.C05_SubContinent_SingleObject.SubContinent_Child_Name);
                Console.WriteLine("\t- People = " + c04_SubContinent.C05_SubContinent_ASingleObject.SubContinent_Child_Name);
                foreach (var c06_Country in c04_SubContinent.C05_CountryObjects)
                {
                    Console.WriteLine("\t\tCountry: " + c06_Country.Country_Name);
                    Console.WriteLine("\t\t- Person = " + c06_Country.C07_Country_SingleObject.Country_Child_Name);
                    Console.WriteLine("\t\t- People = " + c06_Country.C07_Country_ASingleObject.Country_Child_Name);
                    foreach (var c08_Region in c06_Country.C07_RegionObjects)
                    {
                        Console.WriteLine("\t\t\tRegion/State: " + c08_Region.Region_Name);
                        Console.WriteLine("\t\t\t- Person = " + c08_Region.C09_Region_SingleObject.Region_Child_Name);
                        Console.WriteLine("\t\t\t- People = " + c08_Region.C09_Region_ASingleObject.Region_Child_Name);
                        foreach (var c10_City in c08_Region.C09_CityObjects)
                        {
                            Console.WriteLine("\t\t\t\tCity: " + c10_City.City_Name);
                            Console.WriteLine("\t\t\t\t- Person = " + c10_City.C11_City_SingleObject.City_Child_Name);
                            Console.WriteLine("\t\t\t\t- People = " + c10_City.C11_City_ASingleObject.City_Child_Name);
                            foreach (var c12_CityRoad in c10_City.C11_CityRoadObjects)
                            {
                                Console.WriteLine("\t\t\t\t\tRoad: " + c12_CityRoad.CityRoad_Name);
                            }
                        }
                    }
                }
            }
        }
// ReSharper restore InconsistentNaming
    }
}
