using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H03_Continent_Child type
    /// </summary>
    public partial interface IH03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a H03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The Continent ID1.</param>
        /// <returns>A data reader to the H03_Continent_Child.</returns>
        IDataReader Fetch(int continent_ID1);

        /// <summary>
        /// Inserts a new H03_Continent_Child object in the database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        void Insert(int continent_ID, string continent_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the H03_Continent_Child object.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        void Update(int continent_ID, string continent_Child_Name);

        /// <summary>
        /// Deletes the H03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        void Delete(int continent_ID);
    }
}
