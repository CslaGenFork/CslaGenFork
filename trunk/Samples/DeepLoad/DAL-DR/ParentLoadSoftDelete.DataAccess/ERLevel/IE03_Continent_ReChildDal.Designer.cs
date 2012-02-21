using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E03_Continent_ReChild type
    /// </summary>
    public partial interface IE03_Continent_ReChildDal
    {

        /// <summary>
        /// Inserts a new E03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        
        void Insert(int continent_ID, string continent_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the E03_Continent_ReChild object.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        
        void Update(int continent_ID, string continent_Child_Name);

        /// <summary>
        /// Deletes the E03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        void Delete(int continent_ID);
    }
}
