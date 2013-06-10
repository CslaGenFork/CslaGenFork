using System;
using System.Data;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A03_Continent_Child type
    /// </summary>
    public partial interface IA03_Continent_ChildDal
    {
        /// <summary>
        /// Inserts a new A03_Continent_Child object in the database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        void Insert(int continent_ID1, string continent_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the A03_Continent_Child object.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        void Update(int continent_ID1, string continent_Child_Name);

        /// <summary>
        /// Deletes the A03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        void Delete(int continent_ID1);
    }
}
