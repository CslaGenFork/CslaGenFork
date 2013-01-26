using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C07_Country_ReChild type
    /// </summary>
    public partial interface IC07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a C07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="C07_Country_ReChildDto"/> object.</returns>
        C07_Country_ReChildDto Fetch(int country_ID2);

        /// <summary>
        /// Inserts a new C07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="c07_Country_ReChild">The C07 Country Re Child DTO.</param>
        /// <returns>The new <see cref="C07_Country_ReChildDto"/>.</returns>
        C07_Country_ReChildDto Insert(C07_Country_ReChildDto c07_Country_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the C07_Country_ReChild object.
        /// </summary>
        /// <param name="c07_Country_ReChild">The C07 Country Re Child DTO.</param>
        /// <returns>The updated <see cref="C07_Country_ReChildDto"/>.</returns>
        C07_Country_ReChildDto Update(C07_Country_ReChildDto c07_Country_ReChild);

        /// <summary>
        /// Deletes the C07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        void Delete(int country_ID);
    }
}
