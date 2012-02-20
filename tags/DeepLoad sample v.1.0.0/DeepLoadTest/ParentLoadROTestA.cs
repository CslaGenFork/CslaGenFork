using System;
using ParentLoadRO.Business.ERLevel;

namespace DeepLoadBench
{
    public class ParentLoadROTestA
    {
        public void FetchTest()
        {
            var a02Level1 = A02Level1.GetA02Level1(1);
            Console.WriteLine("Continent: " + a02Level1.Level_1_Name);
            Console.WriteLine("- Person = " + a02Level1.A03Level11SingleObject.Level_1_1_Child_Name);
            Console.WriteLine("- People = " + a02Level1.A03Level11ASingleObject.Level_1_1_Child_Name);
            foreach (var a04Level11 in a02Level1.A03Level11Objects)
            {
                Console.WriteLine("\tSub-continent: " + a04Level11.Level_1_1_Name);
                Console.WriteLine("\t- Person = " + a04Level11.A05Level111SingleObject.Level_1_1_1_Child_Name);
                Console.WriteLine("\t- People = " + a04Level11.A05Level111ASingleObject.Level_1_1_1_Child_Name);
                foreach (var a06Level111 in a04Level11.A05Level111Objects)
                {
                    Console.WriteLine("\t\tCountry: " + a06Level111.Level_1_1_1_Name);
                    Console.WriteLine("\t\t- Person = " + a06Level111.A07Level1111SingleObject.Level_1_1_1_1_Child_Name);
                    Console.WriteLine("\t\t- People = " + a06Level111.A07Level1111ASingleObject.Level_1_1_1_1_Child_Name);
                    foreach (var a08Level1111 in a06Level111.A07Level1111Objects)
                    {
                        Console.WriteLine("\t\t\tRegion/State: " + a08Level1111.Level_1_1_1_1_Name);
                        Console.WriteLine("\t\t\t- Person = " + a08Level1111.A09Level11111SingleObject.Level_1_1_1_1_1_Child_Name);
                        Console.WriteLine("\t\t\t- People = " + a08Level1111.A09Level11111ASingleObject.Level_1_1_1_1_1_Child_Name);
                        foreach (var a10Level11111 in a08Level1111.A09Level11111Objects)
                        {
                            Console.WriteLine("\t\t\t\tCity: " + a10Level11111.Level_1_1_1_1_1_Name);
                            Console.WriteLine("\t\t\t\t- Person = " + a10Level11111.A11Level111111SingleObject.Level_1_1_1_1_1_1_Child_Name);
                            Console.WriteLine("\t\t\t\t- People = " + a10Level11111.A11Level111111ASingleObject.Level_1_1_1_1_1_1_Child_Name);
                            foreach (var a12Level111111 in a10Level11111.A11Level111111Objects)
                            {
                                Console.WriteLine("\t\t\t\t\tRoad: " + a12Level111111.Level_1_1_1_1_1_1_Name);
                            }
                        }
                    }
                }
            }
        }
    }
}
