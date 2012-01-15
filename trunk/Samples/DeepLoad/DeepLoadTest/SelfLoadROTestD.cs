using System;
using SelfLoadRO.Business.ERCLevel;

namespace DeepLoadBench
{
    public class SelfLoadROTestD
    {
        public void FetchTest()
        {
            var d01Level1Coll = D01Level1Coll.GetD01Level1Coll();
            foreach (var d02Level1 in d01Level1Coll)
            {
                Console.WriteLine("Continent: " + d02Level1.Level_1_Name);
                Console.WriteLine("- Person = " + d02Level1.D03Level11SingleObject.Level_1_1_Child_Name);
                Console.WriteLine("- People = " + d02Level1.D03Level11ASingleObject.Level_1_1_Child_Name);
                foreach (var d04Level11 in d02Level1.D03Level11Objects)
                {
                    Console.WriteLine("\tSub-continent: " + d04Level11.Level_1_1_Name);
                    Console.WriteLine("\t- Person = " + d04Level11.D05Level111SingleObject.Level_1_1_1_Child_Name);
                    Console.WriteLine("\t- People = " + d04Level11.D05Level111ASingleObject.Level_1_1_1_Child_Name);
                    foreach (var d06Level111 in d04Level11.D05Level111Objects)
                    {
                        Console.WriteLine("\t\tCountry: " + d06Level111.Level_1_1_1_Name);
                        Console.WriteLine("\t\t- Person = " + d06Level111.D07Level1111SingleObject.Level_1_1_1_1_Child_Name);
                        Console.WriteLine("\t\t- People = " + d06Level111.D07Level1111ASingleObject.Level_1_1_1_1_Child_Name);
                        foreach (var d08Level1111 in d06Level111.D07Level1111Objects)
                        {
                            Console.WriteLine("\t\t\tRegion/State: " + d08Level1111.Level_1_1_1_1_Name);
                            Console.WriteLine("\t\t\t- Person = " + d08Level1111.D09Level11111SingleObject.Level_1_1_1_1_1_Child_Name);
                            Console.WriteLine("\t\t\t- People = " + d08Level1111.D09Level11111ASingleObject.Level_1_1_1_1_1_Child_Name);
                            foreach (var d10Level11111 in d08Level1111.D09Level11111Objects)
                            {
                                Console.WriteLine("\t\t\t\tCity: " + d10Level11111.Level_1_1_1_1_1_Name);
                                Console.WriteLine("\t\t\t\t- Person = " + d10Level11111.D11Level111111SingleObject.Level_1_1_1_1_1_1_Child_Name);
                                Console.WriteLine("\t\t\t\t- People = " + d10Level11111.D11Level111111ASingleObject.Level_1_1_1_1_1_1_Child_Name);
                                foreach (var d12Level111111 in d10Level11111.D11Level111111Objects)
                                {
                                    Console.WriteLine("\t\t\t\t\tCity: " + d12Level111111.Level_1_1_1_1_1_1_Name);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
