using System;
using SelfLoadSoftDelete.Business.ERCLevel;

namespace DeepLoadBench
{
    public class SelfLoadTestH
    {
// ReSharper disable InconsistentNaming
        public void FetchTest()
        {
            var h01_ContinentColl = H01_ContinentColl.GetH01_ContinentColl();
            foreach (var h02_Continent in h01_ContinentColl)
            {
                Console.WriteLine("Continent: " + h02_Continent.Continent_Name);
                Console.WriteLine("- Person = " + h02_Continent.H03_Continent_SingleObject.Continent_Child_Name);
                Console.WriteLine("- People = " + h02_Continent.H03_Continent_ASingleObject.Continent_Child_Name);
                foreach (var h04_SubContinent in h02_Continent.H03_SubContinentObjects)
                {
                    Console.WriteLine("\tSub-continent: " + h04_SubContinent.SubContinent_Name);
                    Console.WriteLine("\t- Person = " + h04_SubContinent.H05_SubContinent_SingleObject.SubContinent_Child_Name);
                    Console.WriteLine("\t- People = " + h04_SubContinent.H05_SubContinent_ASingleObject.SubContinent_Child_Name);
                    foreach (var h06_Country in h04_SubContinent.H05_CountryObjects)
                    {
                        Console.WriteLine("\t\tCountry: " + h06_Country.Country_Name);
                        Console.WriteLine("\t\t- Person = " + h06_Country.H07_Country_SingleObject.Country_Child_Name);
                        Console.WriteLine("\t\t- People = " + h06_Country.H07_Country_ASingleObject.Country_Child_Name);
                        foreach (var h08_Region in h06_Country.H07_RegionObjects)
                        {
                            Console.WriteLine("\t\t\tRegion/State: " + h08_Region.Region_Name);
                            Console.WriteLine("\t\t\t- Person = " + h08_Region.H09_Region_SingleObject.Region_Child_Name);
                            Console.WriteLine("\t\t\t- People = " + h08_Region.H09_Region_ASingleObject.Region_Child_Name);
                            foreach (var h10_City in h08_Region.H09_CityObjects)
                            {
                                Console.WriteLine("\t\t\t\tCity: " + h10_City.City_Name);
                                Console.WriteLine("\t\t\t\t- Person = " + h10_City.H11_City_SingleObject.City_Child_Name);
                                Console.WriteLine("\t\t\t\t- People = " + h10_City.H11_City_ASingleObject.City_Child_Name);
                                foreach (var h12_CityRoad in h10_City.H11_CityRoadObjects)
                                {
                                    Console.WriteLine("\t\t\t\t\tCity: " + h12_CityRoad.CityRoad_Name);
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
