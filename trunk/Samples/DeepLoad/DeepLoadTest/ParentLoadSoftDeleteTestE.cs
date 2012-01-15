using System;
using ParentLoadSoftDelete.Business.ERLevel;

namespace DeepLoadBench
{
    public class ParentLoadTestE
    {
        public void FetchTest()
        {
            var e02Level1 = E02Level1.GetE02Level1(1);
            Console.WriteLine("Continent: " + e02Level1.Level_1_Name);
            Console.WriteLine("- Person = " + e02Level1.E03Level11SingleObject.Level_1_1_Child_Name);
            Console.WriteLine("- People = " + e02Level1.E03Level11ASingleObject.Level_1_1_Child_Name);
            foreach (var e04Level11 in e02Level1.E03Level11Objects)
            {
                Console.WriteLine("\tSub-continent: " + e04Level11.Level_1_1_Name);
                Console.WriteLine("\t- Person = " + e04Level11.E05Level111SingleObject.Level_1_1_1_Child_Name);
                Console.WriteLine("\t- People = " + e04Level11.E05Level111ASingleObject.Level_1_1_1_Child_Name);
                foreach (var e06Level111 in e04Level11.E05Level111Objects)
                {
                    Console.WriteLine("\t\tCountry: " + e06Level111.Level_1_1_1_Name);
                    Console.WriteLine("\t\t- Person = " + e06Level111.E07Level1111SingleObject.Level_1_1_1_1_Child_Name);
                    Console.WriteLine("\t\t- People = " + e06Level111.E07Level1111ASingleObject.Level_1_1_1_1_Child_Name);
                    foreach (var e08Level1111 in e06Level111.E07Level1111Objects)
                    {
                        Console.WriteLine("\t\t\tRegion/State: " + e08Level1111.Level_1_1_1_1_Name);
                        Console.WriteLine("\t\t\t- Person = " + e08Level1111.E09Level11111SingleObject.Level_1_1_1_1_1_Child_Name);
                        Console.WriteLine("\t\t\t- People = " + e08Level1111.E09Level11111ASingleObject.Level_1_1_1_1_1_Child_Name);
                        foreach (var e10Level11111 in e08Level1111.E09Level11111Objects)
                        {
                            Console.WriteLine("\t\t\t\tCity: " + e10Level11111.Level_1_1_1_1_1_Name);
                            Console.WriteLine("\t\t\t\t- Person = " + e10Level11111.E11Level111111SingleObject.Level_1_1_1_1_1_1_Child_Name);
                            Console.WriteLine("\t\t\t\t- People = " + e10Level11111.E11Level111111ASingleObject.Level_1_1_1_1_1_1_Child_Name);
                            foreach (var e12Level111111 in e10Level11111.E11Level111111Objects)
                            {
                                Console.WriteLine("\t\t\t\t\tRoad: " + e12Level111111.Level_1_1_1_1_1_1_Name);
                            }
                        }
                    }
                }
            }
        }
    }
}
