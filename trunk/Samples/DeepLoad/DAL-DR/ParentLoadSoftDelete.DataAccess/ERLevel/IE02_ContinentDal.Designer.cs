using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E02_Continent type
    /// </summary>
    public partial interface IE02_ContinentDal
    {

        /// <summary>
        /// Loads a E02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <returns>A data reader to the E02_Continent.</returns>
        IDataReader Fetch(int continent_ID);

        /// <summary>
        /// Inserts a new E02_Continent object in the database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <param name="continent_Name">The Continent Name.</param>
        
        void Insert(out int continent_ID, string continent_Name);

        /// <summary>
        /// Updates in the database all changes made to the E02_Continent object.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <param name="continent_Name">The Continent Name.</param>
        
        void Update(int continent_ID, string continent_Name);


        /// <summary>
        /// Deletes the E02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        void Delete(int continent_ID);
    }
}
