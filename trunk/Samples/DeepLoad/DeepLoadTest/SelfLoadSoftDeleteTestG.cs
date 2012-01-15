using System;
using SelfLoadSoftDelete.Business.ERLevel;

namespace DeepLoadBench
{
    public class SelfLoadTestG
    {
        public void FetchTest()
        {
            var g02Level1 = G02Level1.GetG02Level1(1);
            Console.WriteLine("Continent: " + g02Level1.Level_1_Name);
            Console.WriteLine("- Person = " + g02Level1.G03Level11SingleObject.Level_1_1_Child_Name);
            Console.WriteLine("- People = " + g02Level1.G03Level11ASingleObject.Level_1_1_Child_Name);
            foreach (var g04Level11 in g02Level1.G03Level11Objects)
            {
                Console.WriteLine("\tSub-continent: " + g04Level11.Level_1_1_Name);
                Console.WriteLine("\t- Person = " + g04Level11.G05Level111SingleObject.Level_1_1_1_Child_Name);
                Console.WriteLine("\t- People = " + g04Level11.G05Level111ASingleObject.Level_1_1_1_Child_Name);
                foreach (var g06Level111 in g04Level11.G05Level111Objects)
                {
                    Console.WriteLine("\t\tCountry: " + g06Level111.Level_1_1_1_Name);
                    Console.WriteLine("\t\t- Person = " + g06Level111.G07Level1111SingleObject.Level_1_1_1_1_Child_Name);
                    Console.WriteLine("\t\t- People = " + g06Level111.G07Level1111ASingleObject.Level_1_1_1_1_Child_Name);
                    foreach (var g08Level1111 in g06Level111.G07Level1111Objects)
                    {
                        Console.WriteLine("\t\t\tRegion/State: " + g08Level1111.Level_1_1_1_1_Name);
                        Console.WriteLine("\t\t\t- Person = " + g08Level1111.G09Level11111SingleObject.Level_1_1_1_1_1_Child_Name);
                        Console.WriteLine("\t\t\t- People = " + g08Level1111.G09Level11111ASingleObject.Level_1_1_1_1_1_Child_Name);
                        foreach (var g10Level11111 in g08Level1111.G09Level11111Objects)
                        {
                            Console.WriteLine("\t\t\t\tCity: " + g10Level11111.Level_1_1_1_1_1_Name);
                            Console.WriteLine("\t\t\t\t- Person = " + g10Level11111.G11Level111111SingleObject.Level_1_1_1_1_1_1_Child_Name);
                            Console.WriteLine("\t\t\t\t- People = " + g10Level11111.G11Level111111ASingleObject.Level_1_1_1_1_1_1_Child_Name);
                            foreach (var g12Level111111 in g10Level11111.G11Level111111Objects)
                            {
                                Console.WriteLine("\t\t\t\t\tRoad: " + g12Level111111.Level_1_1_1_1_1_1_Name);
                            }
                        }
                    }
                }
            }
        }
    }
}
