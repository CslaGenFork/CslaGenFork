using System;
using System.Data;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A11_City_Child type
    /// </summary>
    public partial interface IA11_City_ChildDal
    {
        /// <summary>
        /// Inserts a new A11_City_Child object in the database.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        void Insert(int city_ID1, string city_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the A11_City_Child object.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        void Update(int city_ID1, string city_Child_Name);

        /// <summary>
        /// Deletes the A11_City_Child object from database.
        /// </summary>
        /// <param name="city_ID1">The parent City ID1.</param>
        void Delete(int city_ID1);
    }
}
