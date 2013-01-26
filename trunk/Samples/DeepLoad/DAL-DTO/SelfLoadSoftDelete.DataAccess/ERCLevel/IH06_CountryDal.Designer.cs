using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H06_Country type
    /// </summary>
    public partial interface IH06_CountryDal
    {
        /// <summary>
        /// Inserts a new H06_Country object in the database.
        /// </summary>
        /// <param name="h06_Country">The H06 Country DTO.</param>
        /// <returns>The new <see cref="H06_CountryDto"/>.</returns>
        H06_CountryDto Insert(H06_CountryDto h06_Country);

        /// <summary>
        /// Updates in the database all changes made to the H06_Country object.
        /// </summary>
        /// <param name="h06_Country">The H06 Country DTO.</param>
        /// <returns>The updated <see cref="H06_CountryDto"/>.</returns>
        H06_CountryDto Update(H06_CountryDto h06_Country);

        /// <summary>
        /// Deletes the H06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        void Delete(int country_ID);
    }
}
