using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F03_Continent_ReChild type
    /// </summary>
    public partial interface IF03_Continent_ReChildDal
    {
        /// <summary>
        /// Inserts a new F03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="f03_Continent_ReChild">The F03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="F03_Continent_ReChildDto"/>.</returns>
        F03_Continent_ReChildDto Insert(F03_Continent_ReChildDto f03_Continent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the F03_Continent_ReChild object.
        /// </summary>
        /// <param name="f03_Continent_ReChild">The F03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="F03_Continent_ReChildDto"/>.</returns>
        F03_Continent_ReChildDto Update(F03_Continent_ReChildDto f03_Continent_ReChild);

        /// <summary>
        /// Deletes the F03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID2">The parent Continent ID2.</param>
        void Delete(int continent_ID2);
    }
}
