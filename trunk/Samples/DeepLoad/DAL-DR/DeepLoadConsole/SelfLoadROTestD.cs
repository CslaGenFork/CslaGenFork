using System;
using SelfLoadRO.Business.ERCLevel;

namespace DeepLoadBench
{
    public class SelfLoadROTestD
    {
// ReSharper disable InconsistentNaming
        public void FetchTest()
        {
            var d01_ContinentColl = D01_ContinentColl.GetD01_ContinentColl();
            foreach (var d02_Continent in d01_ContinentColl)
            {
                Console.WriteLine("Continent: " + d02_Continent.Continent_Name);
                Console.WriteLine("- Person = " + d02_Continent.D03_Continent_SingleObject.Continent_Child_Name);
                Console.WriteLine("- People = " + d02_Continent.D03_Continent_ASingleObject.Continent_Child_Name);
                foreach (var d04_SubContinent in d02_Continent.D03_SubContinentObjects)
                {
                    Console.WriteLine("\tSub-continent: " + d04_SubContinent.SubContinent_Name);
                    Console.WriteLine("\t- Person = " + d04_SubContinent.D05_SubContinent_SingleObject.SubContinent_Child_Name);
                    Console.WriteLine("\t- People = " + d04_SubContinent.D05_SubContinent_ASingleObject.SubContinent_Child_Name);
                    foreach (var d06_Country in d04_SubContinent.D05_CountryObjects)
                    {
                        Console.WriteLine("\t\tCountry: " + d06_Country.Country_Name);
                        Console.WriteLine("\t\t- Person = " + d06_Country.D07_Country_SingleObject.Country_Child_Name);
                        Console.WriteLine("\t\t- People = " + d06_Country.D07_Country_ASingleObject.Country_Child_Name);
                        foreach (var d08_Region in d06_Country.D07_RegionObjects)
                        {
                            Console.WriteLine("\t\t\tRegion/State: " + d08_Region.Region_Name);
                            Console.WriteLine("\t\t\t- Person = " + d08_Region.D09_Region_SingleObject.Region_Child_Name);
                            Console.WriteLine("\t\t\t- People = " + d08_Region.D09_Region_ASingleObject.Region_Child_Name);
                            foreach (var d10_City in d08_Region.D09_CityObjects)
                            {
                                Console.WriteLine("\t\t\t\tCity: " + d10_City.City_Name);
                                Console.WriteLine("\t\t\t\t- Person = " + d10_City.D11_City_SingleObject.City_Child_Name);
                                Console.WriteLine("\t\t\t\t- People = " + d10_City.D11_City_ASingleObject.City_Child_Name);
                                foreach (var d12_CityRoad in d10_City.D11_CityRoadObjects)
                                {
                                    Console.WriteLine("\t\t\t\t\tCity: " + d12_CityRoad.CityRoad_Name);
                                }
                            }
                        }
                    }
                }
            }
        }
// ReSharper restore InconsistentNaming
    }
}
