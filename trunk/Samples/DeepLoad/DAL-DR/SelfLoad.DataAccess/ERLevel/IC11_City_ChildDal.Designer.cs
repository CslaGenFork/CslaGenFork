using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C11_City_Child type
    /// </summary>
    public partial interface IC11_City_ChildDal
    {
        /// <summary>
        /// Loads a C11_City_Child object from the database.
        /// </summary>
        /// <param name="city_ID1">The City ID1.</param>
        /// <returns>A data reader to the C11_City_Child.</returns>
        IDataReader Fetch(int city_ID1);

        /// <summary>
        /// Inserts a new C11_City_Child object in the database.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        void Insert(int city_ID1, string city_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the C11_City_Child object.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        void Update(int city_ID1, string city_Child_Name);

        /// <summary>
        /// Deletes the C11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        void Delete(int city_ID1);
    }
}
