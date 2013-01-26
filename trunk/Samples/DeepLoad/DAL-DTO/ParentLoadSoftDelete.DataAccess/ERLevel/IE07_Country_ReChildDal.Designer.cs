using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E07_Country_ReChild type
    /// </summary>
    public partial interface IE07_Country_ReChildDal
    {
        /// <summary>
        /// Inserts a new E07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="e07_Country_ReChild">The E07 Country Re Child DTO.</param>
        /// <returns>The new <see cref="E07_Country_ReChildDto"/>.</returns>
        E07_Country_ReChildDto Insert(E07_Country_ReChildDto e07_Country_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the E07_Country_ReChild object.
        /// </summary>
        /// <param name="e07_Country_ReChild">The E07 Country Re Child DTO.</param>
        /// <returns>The updated <see cref="E07_Country_ReChildDto"/>.</returns>
        E07_Country_ReChildDto Update(E07_Country_ReChildDto e07_Country_ReChild);

        /// <summary>
        /// Deletes the E07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        void Delete(int country_ID);
    }
}
