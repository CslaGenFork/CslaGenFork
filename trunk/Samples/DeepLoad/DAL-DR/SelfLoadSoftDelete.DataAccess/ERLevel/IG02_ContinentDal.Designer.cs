using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G02_Continent type
    /// </summary>
    public partial interface IG02_ContinentDal
    {
        /// <summary>
        /// Loads a G02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <returns>A data reader to the G02_Continent.</returns>
        IDataReader Fetch(int continent_ID);

        /// <summary>
        /// Inserts a new G02_Continent object in the database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <param name="continent_Name">The Continent Name.</param>
        void Insert(out int continent_ID, string continent_Name);

        /// <summary>
        /// Updates in the database all changes made to the G02_Continent object.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <param name="continent_Name">The Continent Name.</param>
        void Update(int continent_ID, string continent_Name);

        /// <summary>
        /// Deletes the G02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        void Delete(int continent_ID);
    }
}
