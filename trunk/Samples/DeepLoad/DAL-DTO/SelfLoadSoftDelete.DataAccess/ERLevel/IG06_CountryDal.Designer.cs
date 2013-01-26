using System;
using System.Collections.Generic;
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
        /// <param name="g06_Country">The G06 Country DTO.</param>
        /// <returns>The new <see cref="G06_CountryDto"/>.</returns>
        G06_CountryDto Insert(G06_CountryDto g06_Country);

        /// <summary>
        /// Updates in the database all changes made to the G06_Country object.
        /// </summary>
        /// <param name="g06_Country">The G06 Country DTO.</param>
        /// <returns>The updated <see cref="G06_CountryDto"/>.</returns>
        G06_CountryDto Update(G06_CountryDto g06_Country);

        /// <summary>
        /// Deletes the G06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        void Delete(int country_ID);
    }
}
