using System;
using ParentLoadSoftDelete.Business.ERCLevel;

namespace DeepLoadBench
{
    public class ParentLoadTestF
    {
// ReSharper disable InconsistentNaming
        public void FetchTest()
        {
            var f01_ContinentColl = F01_ContinentColl.GetF01_ContinentColl();
            foreach (var f02_Continent in f01_ContinentColl)
            {
                Console.WriteLine("Continent: " + f02_Continent.Continent_Name);
                Console.WriteLine("- Person = " + f02_Continent.F03_Continent_SingleObject.Continent_Child_Name);
                Console.WriteLine("- People = " + f02_Continent.F03_Continent_ASingleObject.Continent_Child_Name);
                foreach (var f04_SubContinent in f02_Continent.F03_SubContinentObjects)
                {
                    Console.WriteLine("\tSub-continent: " + f04_SubContinent.SubContinent_Name);
                    Console.WriteLine("\t- Person = " + f04_SubContinent.F05_SubContinent_SingleObject.SubContinent_Child_Name);
                    Console.WriteLine("\t- People = " + f04_SubContinent.F05_SubContinent_ASingleObject.SubContinent_Child_Name);
                    foreach (var f06_Country in f04_SubContinent.F05_CountryObjects)
                    {
                        Console.WriteLine("\t\tCountry: " + f06_Country.Country_Name);
                        Console.WriteLine("\t\t- Person = " + f06_Country.F07_Country_SingleObject.Country_Child_Name);
                        Console.WriteLine("\t\t- People = " + f06_Country.F07_Country_ASingleObject.Country_Child_Name);
                        foreach (var f08_Region in f06_Country.F07_RegionObjects)
                        {
                            Console.WriteLine("\t\t\tRegion/State: " + f08_Region.Region_Name);
                            Console.WriteLine("\t\t\t- Person = " + f08_Region.F09_Region_SingleObject.Region_Child_Name);
                            Console.WriteLine("\t\t\t- People = " + f08_Region.F09_Region_ASingleObject.Region_Child_Name);
                            foreach (var f10_City in f08_Region.F09_CityObjects)
                            {
                                Console.WriteLine("\t\t\t\tCity: " + f10_City.City_Name);
                                Console.WriteLine("\t\t\t\t- Person = " + f10_City.F11_City_SingleObject.City_Child_Name);
                                Console.WriteLine("\t\t\t\t- People = " + f10_City.F11_City_ASingleObject.City_Child_Name);
                                foreach (var f12_CityRoad in f10_City.F11_CityRoadObjects)
                                {
                                    Console.WriteLine("\t\t\t\t\tCity: " + f12_CityRoad.CityRoad_Name);
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
