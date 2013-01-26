using System;
using ParentLoad.Business.ERLevel;

namespace DeepLoadBench
{
    public class ParentLoadTestA
    {
        public void FetchTest()
        {
            var a02_Continent = A02_Continent.GetA02_Continent(1);
            Console.WriteLine("Continent: " + a02_Continent.Continent_Name);
            Console.WriteLine("- Person = " + a02_Continent.A03_Continent_SingleObject.Continent_Child_Name);
            Console.WriteLine("- People = " + a02_Continent.A03_Continent_ASingleObject.Continent_Child_Name);
            foreach (var a04_SubContinent in a02_Continent.A03_SubContinentObjects)
            {
                Console.WriteLine("\tSub-continent: " + a04_SubContinent.SubContinent_Name);
                Console.WriteLine("\t- Person = " + a04_SubContinent.A05_SubContinent_SingleObject.SubContinent_Child_Name);
                Console.WriteLine("\t- People = " + a04_SubContinent.A05_SubContinent_ASingleObject.SubContinent_Child_Name);
                foreach (var a06_Country in a04_SubContinent.A05_CountryObjects)
                {
                    Console.WriteLine("\t\tCountry: " + a06_Country.Country_Name);
                    Console.WriteLine("\t\t- Person = " + a06_Country.A07_Country_SingleObject.Country_Child_Name);
                    Console.WriteLine("\t\t- People = " + a06_Country.A07_Country_ASingleObject.Country_Child_Name);
                    foreach (var a08_Region in a06_Country.A07_RegionObjects)
                    {
                        Console.WriteLine("\t\t\tRegion/State: " + a08_Region.Region_Name);
                        Console.WriteLine("\t\t\t- Person = " + a08_Region.A09_Region_SingleObject.Region_Child_Name);
                        Console.WriteLine("\t\t\t- People = " + a08_Region.A09_Region_ASingleObject.Region_Child_Name);
                        foreach (var a10_City in a08_Region.A09_CityObjects)
                        {
                            Console.WriteLine("\t\t\t\tCity: " + a10_City.City_Name);
                            Console.WriteLine("\t\t\t\t- Person = " + a10_City.A11_City_SingleObject.City_Child_Name);
                            Console.WriteLine("\t\t\t\t- People = " + a10_City.A11_City_ASingleObject.City_Child_Name);
                            foreach (var a12_CityRoad in a10_City.A11_CityRoadObjects)
                            {
                                Console.WriteLine("\t\t\t\t\tRoad: " + a12_CityRoad.CityRoad_Name);
                            }
                        }
                    }
                }
            }
        }
    }
}
