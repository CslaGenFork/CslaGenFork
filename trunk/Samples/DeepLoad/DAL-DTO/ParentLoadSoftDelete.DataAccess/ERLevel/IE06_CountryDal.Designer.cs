using System;
using System.Collections.Generic;
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
        /// <param name="e06_Country">The E06 Country DTO.</param>
        /// <returns>The new <see cref="E06_CountryDto"/>.</returns>
        E06_CountryDto Insert(E06_CountryDto e06_Country);

        /// <summary>
        /// Updates in the database all changes made to the E06_Country object.
        /// </summary>
        /// <param name="e06_Country">The E06 Country DTO.</param>
        /// <returns>The updated <see cref="E06_CountryDto"/>.</returns>
        E06_CountryDto Update(E06_CountryDto e06_Country);

        /// <summary>
        /// Deletes the E06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        void Delete(int country_ID);
    }
}
