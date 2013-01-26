using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D07_Country_ReChild type
    /// </summary>
    public partial interface ID07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a D07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="D07_Country_ReChildDto"/> object.</returns>
        D07_Country_ReChildDto Fetch(int country_ID2);

        /// <summary>
        /// Inserts a new D07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="d07_Country_ReChild">The D07 Country Re Child DTO.</param>
        /// <returns>The new <see cref="D07_Country_ReChildDto"/>.</returns>
        D07_Country_ReChildDto Insert(D07_Country_ReChildDto d07_Country_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the D07_Country_ReChild object.
        /// </summary>
        /// <param name="d07_Country_ReChild">The D07 Country Re Child DTO.</param>
        /// <returns>The updated <see cref="D07_Country_ReChildDto"/>.</returns>
        D07_Country_ReChildDto Update(D07_Country_ReChildDto d07_Country_ReChild);

        /// <summary>
        /// Deletes the D07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        void Delete(int country_ID);
    }
}
