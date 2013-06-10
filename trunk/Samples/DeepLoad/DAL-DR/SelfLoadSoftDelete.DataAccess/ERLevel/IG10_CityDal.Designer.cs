using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G10_City type
    /// </summary>
    public partial interface IG10_CityDal
    {
        /// <summary>
        /// Inserts a new G10_City object in the database.
        /// </summary>
        /// <param name="parent_Region_ID">The parent Parent Region ID.</param>
        /// <param name="city_ID">The City ID.</param>
        /// <param name="city_Name">The City Name.</param>
        void Insert(int parent_Region_ID, out int city_ID, string city_Name);

        /// <summary>
        /// Updates in the database all changes made to the G10_City object.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        /// <param name="city_Name">The City Name.</param>
        void Update(int city_ID, string city_Name);

        /// <summary>
        /// Deletes the G10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        void Delete(int city_ID);
    }
}
