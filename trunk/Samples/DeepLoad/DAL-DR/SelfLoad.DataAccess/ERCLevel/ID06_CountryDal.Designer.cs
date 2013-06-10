using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D06_Country type
    /// </summary>
    public partial interface ID06_CountryDal
    {
        /// <summary>
        /// Inserts a new D06_Country object in the database.
        /// </summary>
        /// <param name="parent_SubContinent_ID">The parent Parent Sub Continent ID.</param>
        /// <param name="country_ID">The Country ID.</param>
        /// <param name="country_Name">The Country Name.</param>
        void Insert(int parent_SubContinent_ID, out int country_ID, string country_Name);

        /// <summary>
        /// Updates in the database all changes made to the D06_Country object.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        /// <param name="country_Name">The Country Name.</param>
        void Update(int country_ID, string country_Name);

        /// <summary>
        /// Deletes the D06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        void Delete(int country_ID);
    }
}
