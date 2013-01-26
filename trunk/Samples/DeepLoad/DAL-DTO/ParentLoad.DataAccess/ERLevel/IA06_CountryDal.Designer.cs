using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A06_Country type
    /// </summary>
    public partial interface IA06_CountryDal
    {
        /// <summary>
        /// Inserts a new A06_Country object in the database.
        /// </summary>
        /// <param name="a06_Country">The A06 Country DTO.</param>
        /// <returns>The new <see cref="A06_CountryDto"/>.</returns>
        A06_CountryDto Insert(A06_CountryDto a06_Country);

        /// <summary>
        /// Updates in the database all changes made to the A06_Country object.
        /// </summary>
        /// <param name="a06_Country">The A06 Country DTO.</param>
        /// <returns>The updated <see cref="A06_CountryDto"/>.</returns>
        A06_CountryDto Update(A06_CountryDto a06_Country);

        /// <summary>
        /// Deletes the A06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        void Delete(int country_ID);
    }
}
