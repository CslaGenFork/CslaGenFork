using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C10_City type
    /// </summary>
    public partial interface IC10_CityDal
    {

        /// <summary>
        /// Inserts a new C10_City object in the database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        /// <param name="city_ID">The City ID.</param>
        /// <param name="city_Name">The City Name.</param>
        
        void Insert(int region_ID, out int city_ID, string city_Name);

        /// <summary>
        /// Updates in the database all changes made to the C10_City object.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        /// <param name="city_Name">The City Name.</param>
        
        void Update(int city_ID, string city_Name);

        /// <summary>
        /// Deletes the C10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        void Delete(int city_ID);
    }
}
