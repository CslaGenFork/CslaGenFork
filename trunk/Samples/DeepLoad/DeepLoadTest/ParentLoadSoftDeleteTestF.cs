using System;
using ParentLoadSoftDelete.Business.ERCLevel;

namespace DeepLoadBench
{
    public class ParentLoadTestF
    {
        public void FetchTest()
        {
            var f01Level1Coll = F01Level1Coll.GetF01Level1Coll();
            foreach (var f02Level1 in f01Level1Coll)
            {
                Console.WriteLine("Continent: " + f02Level1.Level_1_Name);
                Console.WriteLine("- Person = " + f02Level1.F03Level11SingleObject.Level_1_1_Child_Name);
                Console.WriteLine("- People = " + f02Level1.F03Level11ASingleObject.Level_1_1_Child_Name);
                foreach (var f04Level11 in f02Level1.F03Level11Objects)
                {
                    Console.WriteLine("\tSub-continent: " + f04Level11.Level_1_1_Name);
                    Console.WriteLine("\t- Person = " + f04Level11.F05Level111SingleObject.Level_1_1_1_Child_Name);
                    Console.WriteLine("\t- People = " + f04Level11.F05Level111ASingleObject.Level_1_1_1_Child_Name);
                    foreach (var f06Level111 in f04Level11.F05Level111Objects)
                    {
                        Console.WriteLine("\t\tCountry: " + f06Level111.Level_1_1_1_Name);
                        Console.WriteLine("\t\t- Person = " + f06Level111.F07Level1111SingleObject.Level_1_1_1_1_Child_Name);
                        Console.WriteLine("\t\t- People = " + f06Level111.F07Level1111ASingleObject.Level_1_1_1_1_Child_Name);
                        foreach (var f08Level1111 in f06Level111.F07Level1111Objects)
                        {
                            Console.WriteLine("\t\t\tRegion/State: " + f08Level1111.Level_1_1_1_1_Name);
                            Console.WriteLine("\t\t\t- Person = " + f08Level1111.F09Level11111SingleObject.Level_1_1_1_1_1_Child_Name);
                            Console.WriteLine("\t\t\t- People = " + f08Level1111.F09Level11111ASingleObject.Level_1_1_1_1_1_Child_Name);
                            foreach (var f10Level11111 in f08Level1111.F09Level11111Objects)
                            {
                                Console.WriteLine("\t\t\t\tCity: " + f10Level11111.Level_1_1_1_1_1_Name);
                                Console.WriteLine("\t\t\t\t- Person = " + f10Level11111.F11Level111111SingleObject.Level_1_1_1_1_1_1_Child_Name);
                                Console.WriteLine("\t\t\t\t- People = " + f10Level11111.F11Level111111ASingleObject.Level_1_1_1_1_1_1_Child_Name);
                                foreach (var f12Level111111 in f10Level11111.F11Level111111Objects)
                                {
                                    Console.WriteLine("\t\t\t\t\tCity: " + f12Level111111.Level_1_1_1_1_1_1_Name);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
