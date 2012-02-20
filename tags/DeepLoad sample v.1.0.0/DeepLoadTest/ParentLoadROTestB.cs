using System;
using ParentLoadRO.Business.ERCLevel;

namespace DeepLoadBench
{
    public class ParentLoadROTestB
    {
        public void FetchTest()
        {
            var b01Level1Coll = B01Level1Coll.GetB01Level1Coll();
            foreach (var b02Level1 in b01Level1Coll)
            {
                Console.WriteLine("Continent: " + b02Level1.Level_1_Name);
                Console.WriteLine("- Person = " + b02Level1.B03Level11SingleObject.Level_1_1_Child_Name);
                Console.WriteLine("- People = " + b02Level1.B03Level11ASingleObject.Level_1_1_Child_Name);
                foreach (var b04Level11 in b02Level1.B03Level11Objects)
                {
                    Console.WriteLine("\tSub-continent: " + b04Level11.Level_1_1_Name);
                    Console.WriteLine("\t- Person = " + b04Level11.B05Level111SingleObject.Level_1_1_1_Child_Name);
                    Console.WriteLine("\t- People = " + b04Level11.B05Level111ASingleObject.Level_1_1_1_Child_Name);
                    foreach (var b06Level111 in b04Level11.B05Level111Objects)
                    {
                        Console.WriteLine("\t\tCountry: " + b06Level111.Level_1_1_1_Name);
                        Console.WriteLine("\t\t- Person = " + b06Level111.B07Level1111SingleObject.Level_1_1_1_1_Child_Name);
                        Console.WriteLine("\t\t- People = " + b06Level111.B07Level1111ASingleObject.Level_1_1_1_1_Child_Name);
                        foreach (var b08Level1111 in b06Level111.B07Level1111Objects)
                        {
                            Console.WriteLine("\t\t\tRegion/State: " + b08Level1111.Level_1_1_1_1_Name);
                            Console.WriteLine("\t\t\t- Person = " + b08Level1111.B09Level11111SingleObject.Level_1_1_1_1_1_Child_Name);
                            Console.WriteLine("\t\t\t- People = " + b08Level1111.B09Level11111ASingleObject.Level_1_1_1_1_1_Child_Name);
                            foreach (var b10Level11111 in b08Level1111.B09Level11111Objects)
                            {
                                Console.WriteLine("\t\t\t\tCity: " + b10Level11111.Level_1_1_1_1_1_Name);
                                Console.WriteLine("\t\t\t\t- Person = " + b10Level11111.B11Level111111SingleObject.Level_1_1_1_1_1_1_Child_Name);
                                Console.WriteLine("\t\t\t\t- People = " + b10Level11111.B11Level111111ASingleObject.Level_1_1_1_1_1_1_Child_Name);
                                foreach (var b12Level111111 in b10Level11111.B11Level111111Objects)
                                {
                                    Console.WriteLine("\t\t\t\t\tCity: " + b12Level111111.Level_1_1_1_1_1_1_Name);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
