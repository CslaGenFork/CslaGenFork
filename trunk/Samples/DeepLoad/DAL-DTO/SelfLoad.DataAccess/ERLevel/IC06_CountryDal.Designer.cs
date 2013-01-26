using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C06_Country type
    /// </summary>
    public partial interface IC06_CountryDal
    {
        /// <summary>
        /// Inserts a new C06_Country object in the database.
        /// </summary>
        /// <param name="c06_Country">The C06 Country DTO.</param>
        /// <returns>The new <see cref="C06_CountryDto"/>.</returns>
        C06_CountryDto Insert(C06_CountryDto c06_Country);

        /// <summary>
        /// Updates in the database all changes made to the C06_Country object.
        /// </summary>
        /// <param name="c06_Country">The C06 Country DTO.</param>
        /// <returns>The updated <see cref="C06_CountryDto"/>.</returns>
        C06_CountryDto Update(C06_CountryDto c06_Country);

        /// <summary>
        /// Deletes the C06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        void Delete(int country_ID);
    }
}
