using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B06_Country type
    /// </summary>
    public partial interface IB06_CountryDal
    {
        /// <summary>
        /// Inserts a new B06_Country object in the database.
        /// </summary>
        /// <param name="b06_Country">The B06 Country DTO.</param>
        /// <returns>The new <see cref="B06_CountryDto"/>.</returns>
        B06_CountryDto Insert(B06_CountryDto b06_Country);

        /// <summary>
        /// Updates in the database all changes made to the B06_Country object.
        /// </summary>
        /// <param name="b06_Country">The B06 Country DTO.</param>
        /// <returns>The updated <see cref="B06_CountryDto"/>.</returns>
        B06_CountryDto Update(B06_CountryDto b06_Country);

        /// <summary>
        /// Deletes the B06_Country object from database.
        /// </summary>
        /// <param name="country_ID">The Country ID.</param>
        void Delete(int country_ID);
    }
}
