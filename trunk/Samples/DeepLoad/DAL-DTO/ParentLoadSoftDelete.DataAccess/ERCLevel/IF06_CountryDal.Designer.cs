using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F06_Country type
    /// </summary>
    public partial interface IF06_CountryDal
    {
        /// <summary>
        /// Inserts a new F06_Country object in the database.
        /// </summary>
        /// <param name="f06_Country">The F06 Country DTO.</param>
        /// <returns>The new <see cref="F06_CountryDto"/>.</returns>
        F06_CountryDto Insert(F06_CountryDto f06_Country);

        /// <summary>
        /// Updates in the database all changes made to the F06_Country object.
        /// </summary>
        /// <param name="f06_Country">The F06 Country DTO.</param>
        /// <returns>The updated <see cref="F06_CountryDto"/>.</returns>
        F06_CountryDto Update(F06_CountryDto f06_Country);

        /// <summary>
        /// Deletes the F06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        void Delete(int country_ID);
    }
}
