using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D02_Continent type
    /// </summary>
    public partial interface ID02_ContinentDal
    {

        /// <summary>
        /// Inserts a new D02_Continent object in the database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <param name="continent_Name">The Continent Name.</param>
        
        void Insert(out int continent_ID, string continent_Name);

        /// <summary>
        /// Updates in the database all changes made to the D02_Continent object.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <param name="continent_Name">The Continent Name.</param>
        
        void Update(int continent_ID, string continent_Name);

        /// <summary>
        /// Deletes the D02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        void Delete(int continent_ID);
    }
}
