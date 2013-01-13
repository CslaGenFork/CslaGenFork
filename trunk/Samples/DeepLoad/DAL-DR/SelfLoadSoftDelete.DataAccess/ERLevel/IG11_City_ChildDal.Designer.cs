using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G11_City_Child type
    /// </summary>
    public partial interface IG11_City_ChildDal
    {
        /// <summary>
        /// Loads a G11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The City ID1.</param>
        /// <returns>A data reader to the G11_City_Child.</returns>
        IDataReader Fetch(int city_ID1);

        /// <summary>
        /// Inserts a new G11_City_Child object in the database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        void Insert(int city_ID, string city_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the G11_City_Child object.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        void Update(int city_ID, string city_Child_Name);

        /// <summary>
        /// Deletes the G11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID">The parent City ID.</param>
        void Delete(int city_ID);
    }
}
