using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C02_Continent type
    /// </summary>
    public partial interface IC02_ContinentDal
    {

        /// <summary>
        /// Loads a C02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <returns>A data reader to the C02_Continent.</returns>
        IDataReader Fetch(int continent_ID);

        /// <summary>
        /// Inserts a new C02_Continent object in the database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <param name="continent_Name">The Continent Name.</param>
        
        void Insert(out int continent_ID, string continent_Name);

        /// <summary>
        /// Updates in the database all changes made to the C02_Continent object.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        /// <param name="continent_Name">The Continent Name.</param>
        
        void Update(int continent_ID, string continent_Name);


        /// <summary>
        /// Deletes the C02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The Continent ID.</param>
        void Delete(int continent_ID);
    }
}
