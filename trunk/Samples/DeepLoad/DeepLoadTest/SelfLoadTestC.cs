using System;
using SelfLoad.Business.ERLevel;

namespace DeepLoadBench
{
    public class SelfLoadTestC
    {
        public void FetchTest()
        {
            var c02Level1 = C02Level1.GetC02Level1(1);
            Console.WriteLine("Continent: " + c02Level1.Level_1_Name);
            Console.WriteLine("- Person = " + c02Level1.C03Level11SingleObject.Level_1_1_Child_Name);
            Console.WriteLine("- People = " + c02Level1.C03Level11ASingleObject.Level_1_1_Child_Name);
            foreach (var c04Level11 in c02Level1.C03Level11Objects)
            {
                Console.WriteLine("\tSub-continent: " + c04Level11.Level_1_1_Name);
                Console.WriteLine("\t- Person = " + c04Level11.C05Level111SingleObject.Level_1_1_1_Child_Name);
                Console.WriteLine("\t- People = " + c04Level11.C05Level111ASingleObject.Level_1_1_1_Child_Name);
                foreach (var c06Level111 in c04Level11.C05Level111Objects)
                {
                    Console.WriteLine("\t\tCountry: " + c06Level111.Level_1_1_1_Name);
                    Console.WriteLine("\t\t- Person = " + c06Level111.C07Level1111SingleObject.Level_1_1_1_1_Child_Name);
                    Console.WriteLine("\t\t- People = " + c06Level111.C07Level1111ASingleObject.Level_1_1_1_1_Child_Name);
                    foreach (var c08Level1111 in c06Level111.C07Level1111Objects)
                    {
                        Console.WriteLine("\t\t\tRegion/State: " + c08Level1111.Level_1_1_1_1_Name);
                        Console.WriteLine("\t\t\t- Person = " + c08Level1111.C09Level11111SingleObject.Level_1_1_1_1_1_Child_Name);
                        Console.WriteLine("\t\t\t- People = " + c08Level1111.C09Level11111ASingleObject.Level_1_1_1_1_1_Child_Name);
                        foreach (var c10Level11111 in c08Level1111.C09Level11111Objects)
                        {
                            Console.WriteLine("\t\t\t\tCity: " + c10Level11111.Level_1_1_1_1_1_Name);
                            Console.WriteLine("\t\t\t\t- Person = " + c10Level11111.C11Level111111SingleObject.Level_1_1_1_1_1_1_Child_Name);
                            Console.WriteLine("\t\t\t\t- People = " + c10Level11111.C11Level111111ASingleObject.Level_1_1_1_1_1_1_Child_Name);
                            foreach (var c12Level111111 in c10Level11111.C11Level111111Objects)
                            {
                                Console.WriteLine("\t\t\t\t\tRoad: " + c12Level111111.Level_1_1_1_1_1_1_Name);
                            }
                        }
                    }
                }
            }
        }
    }
}
