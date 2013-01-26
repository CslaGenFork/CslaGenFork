using System;
using System.Collections.Generic;
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
        /// <param name="d06_Country">The D06 Country DTO.</param>
        /// <returns>The new <see cref="D06_CountryDto"/>.</returns>
        D06_CountryDto Insert(D06_CountryDto d06_Country);

        /// <summary>
        /// Updates in the database all changes made to the D06_Country object.
        /// </summary>
        /// <param name="d06_Country">The D06 Country DTO.</param>
        /// <returns>The updated <see cref="D06_CountryDto"/>.</returns>
        D06_CountryDto Update(D06_CountryDto d06_Country);

        /// <summary>
        /// Deletes the D06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        void Delete(int country_ID);
    }
}
