using System;
using SelfLoadSoftDelete.Business.ERCLevel;

namespace DeepLoadBench
{
    public class SelfLoadTestH
    {
        public void FetchTest()
        {
            var h01Level1Coll = H01Level1Coll.GetH01Level1Coll();
            foreach (var h02Level1 in h01Level1Coll)
            {
                Console.WriteLine("Continent: " + h02Level1.Level_1_Name);
                Console.WriteLine("- Person = " + h02Level1.H03Level11SingleObject.Level_1_1_Child_Name);
                Console.WriteLine("- People = " + h02Level1.H03Level11ASingleObject.Level_1_1_Child_Name);
                foreach (var h04Level11 in h02Level1.H03Level11Objects)
                {
                    Console.WriteLine("\tSub-continent: " + h04Level11.Level_1_1_Name);
                    Console.WriteLine("\t- Person = " + h04Level11.H05Level111SingleObject.Level_1_1_1_Child_Name);
                    Console.WriteLine("\t- People = " + h04Level11.H05Level111ASingleObject.Level_1_1_1_Child_Name);
                    foreach (var h06Level111 in h04Level11.H05Level111Objects)
                    {
                        Console.WriteLine("\t\tCountry: " + h06Level111.Level_1_1_1_Name);
                        Console.WriteLine("\t\t- Person = " + h06Level111.H07Level1111SingleObject.Level_1_1_1_1_Child_Name);
                        Console.WriteLine("\t\t- People = " + h06Level111.H07Level1111ASingleObject.Level_1_1_1_1_Child_Name);
                        foreach (var h08Level1111 in h06Level111.H07Level1111Objects)
                        {
                            Console.WriteLine("\t\t\tRegion/State: " + h08Level1111.Level_1_1_1_1_Name);
                            Console.WriteLine("\t\t\t- Person = " + h08Level1111.H09Level11111SingleObject.Level_1_1_1_1_1_Child_Name);
                            Console.WriteLine("\t\t\t- People = " + h08Level1111.H09Level11111ASingleObject.Level_1_1_1_1_1_Child_Name);
                            foreach (var h10Level11111 in h08Level1111.H09Level11111Objects)
                            {
                                Console.WriteLine("\t\t\t\tCity: " + h10Level11111.Level_1_1_1_1_1_Name);
                                Console.WriteLine("\t\t\t\t- Person = " + h10Level11111.H11Level111111SingleObject.Level_1_1_1_1_1_1_Child_Name);
                                Console.WriteLine("\t\t\t\t- People = " + h10Level11111.H11Level111111ASingleObject.Level_1_1_1_1_1_1_Child_Name);
                                foreach (var h12Level111111 in h10Level11111.H11Level111111Objects)
                                {
                                    Console.WriteLine("\t\t\t\t\tCity: " + h12Level111111.Level_1_1_1_1_1_1_Name);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
