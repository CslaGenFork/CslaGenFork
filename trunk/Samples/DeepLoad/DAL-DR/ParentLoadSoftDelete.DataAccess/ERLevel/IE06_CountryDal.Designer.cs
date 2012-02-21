using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E06_Country type
    /// </summary>
    public partial interface IE06_CountryDal
    {

        /// <summary>
        /// Inserts a new E06_Country object in the database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="country_ID">The Country ID.</param>
        /// <param name="country_Name">The Country Name.</param>
        /// <returns>The Row Version of the new E06_Country.</returns>
        byte[] Insert(int subContinent_ID, out int country_ID, string country_Name);

        /// <summary>
        /// Updates in the database all changes made to the E06_Country object.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        /// <param name="country_Name">The Country Name.</param>
        /// <param name="parent_SubContinent_ID">The Parent Sub Continent ID.</param>
        /// <param name="rowVersion">The Row Version.</param>
        /// <returns>The updated Row Version.</returns>
        byte[] Update(int country_ID, string country_Name, int parent_SubContinent_ID, byte[] rowVersion);

        /// <summary>
        /// Deletes the E06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        void Delete(int country_ID);
    }
}
