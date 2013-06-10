using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F07_Country_ReChild type
    /// </summary>
    public partial interface IF07_Country_ReChildDal
    {
        /// <summary>
        /// Inserts a new F07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="f07_Country_ReChild">The F07 Country Re Child DTO.</param>
        /// <returns>The new <see cref="F07_Country_ReChildDto"/>.</returns>
        F07_Country_ReChildDto Insert(F07_Country_ReChildDto f07_Country_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the F07_Country_ReChild object.
        /// </summary>
        /// <param name="f07_Country_ReChild">The F07 Country Re Child DTO.</param>
        /// <returns>The updated <see cref="F07_Country_ReChildDto"/>.</returns>
        F07_Country_ReChildDto Update(F07_Country_ReChildDto f07_Country_ReChild);

        /// <summary>
        /// Deletes the F07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        void Delete(int country_ID2);
    }
}
