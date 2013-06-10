using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G06_Country type
    /// </summary>
    public partial interface IG06_CountryDal
    {
        /// <summary>
        /// Inserts a new G06_Country object in the database.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The parent Parent Sub Continent ID.</param>
        /// <param name="country_ID">The Country ID.</param>
        /// <param name="country_Name">The Country Name.</param>
        /// <returns>The Row Version of the new G06_Country.</returns>
        byte[] Insert(int parent_SubContinent_ID, out int country_ID, string country_Name);

        /// <summary>
        /// Updates in the database all changes made to the G06_Country object.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        /// <param name="country_Name">The Country Name.</param>
        /// <param name="parentSubContinentID">The Parent Sub Continent ID.</param>
        /// <param name="rowVersion">The Row Version.</param>
        /// <returns>The updated Row Version.</returns>
        byte[] Update(int country_ID, string country_Name, int parentSubContinentID, byte[] rowVersion);

        /// <summary>
        /// Deletes the G06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        void Delete(int country_ID);
    }
}
