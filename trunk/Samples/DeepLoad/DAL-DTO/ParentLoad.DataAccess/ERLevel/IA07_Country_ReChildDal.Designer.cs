using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A07_Country_ReChild type
    /// </summary>
    public partial interface IA07_Country_ReChildDal
    {
        /// <summary>
        /// Inserts a new A07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="a07_Country_ReChild">The A07 Country Re Child DTO.</param>
        /// <returns>The new <see cref="A07_Country_ReChildDto"/>.</returns>
        A07_Country_ReChildDto Insert(A07_Country_ReChildDto a07_Country_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the A07_Country_ReChild object.
        /// </summary>
        /// <param name="a07_Country_ReChild">The A07 Country Re Child DTO.</param>
        /// <returns>The updated <see cref="A07_Country_ReChildDto"/>.</returns>
        A07_Country_ReChildDto Update(A07_Country_ReChildDto a07_Country_ReChild);

        /// <summary>
        /// Deletes the A07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        void Delete(int country_ID2);
    }
}
