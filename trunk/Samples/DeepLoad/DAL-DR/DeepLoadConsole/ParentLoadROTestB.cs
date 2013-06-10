using System;
using ParentLoadRO.Business.ERCLevel;

namespace DeepLoadBench
{
    public class ParentLoadROTestB
    {
// ReSharper disable InconsistentNaming
        public void FetchTest()
        {
            var b01_ContinentColl = B01_ContinentColl.GetB01_ContinentColl();
            foreach (var b02_Continent in b01_ContinentColl)
            {
                Console.WriteLine("Continent: " + b02_Continent.Continent_Name);
                Console.WriteLine("- Person = " + b02_Continent.B03_Continent_SingleObject.Continent_Child_Name);
                Console.WriteLine("- People = " + b02_Continent.B03_Continent_ASingleObject.Continent_Child_Name);
                foreach (var b04_SubContinent in b02_Continent.B03_SubContinentObjects)
                {
                    Console.WriteLine("\tSub-continent: " + b04_SubContinent.SubContinent_Name);
                    Console.WriteLine("\t- Person = " + b04_SubContinent.B05_SubContinent_SingleObject.SubContinent_Child_Name);
                    Console.WriteLine("\t- People = " + b04_SubContinent.B05_SubContinent_ASingleObject.SubContinent_Child_Name);
                    foreach (var b06_Country in b04_SubContinent.B05_CountryObjects)
                    {
                        Console.WriteLine("\t\tCountry: " + b06_Country.Country_Name);
                        Console.WriteLine("\t\t- Person = " + b06_Country.B07_Country_SingleObject.Country_Child_Name);
                        Console.WriteLine("\t\t- People = " + b06_Country.B07_Country_ASingleObject.Country_Child_Name);
                        foreach (var b08_Region in b06_Country.B07_RegionObjects)
                        {
                            Console.WriteLine("\t\t\tRegion/State: " + b08_Region.Region_Name);
                            Console.WriteLine("\t\t\t- Person = " + b08_Region.B09_Region_SingleObject.Region_Child_Name);
                            Console.WriteLine("\t\t\t- People = " + b08_Region.B09_Region_ASingleObject.Region_Child_Name);
                            foreach (var b10_City in b08_Region.B09_CityObjects)
                            {
                                Console.WriteLine("\t\t\t\tCity: " + b10_City.City_Name);
                                Console.WriteLine("\t\t\t\t- Person = " + b10_City.B11_City_SingleObject.City_Child_Name);
                                Console.WriteLine("\t\t\t\t- People = " + b10_City.B11_City_ASingleObject.City_Child_Name);
                                foreach (var b12_CityRoad in b10_City.B11_CityRoadObjects)
                                {
                                    Console.WriteLine("\t\t\t\t\tCity: " + b12_CityRoad.CityRoad_Name);
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
