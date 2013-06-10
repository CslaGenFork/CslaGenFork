using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E03_Continent_ReChild type
    /// </summary>
    public partial interface IE03_Continent_ReChildDal
    {
        /// <summary>
        /// Inserts a new E03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="e03_Continent_ReChild">The E03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="E03_Continent_ReChildDto"/>.</returns>
        E03_Continent_ReChildDto Insert(E03_Continent_ReChildDto e03_Continent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the E03_Continent_ReChild object.
        /// </summary>
        /// <param name="e03_Continent_ReChild">The E03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="E03_Continent_ReChildDto"/>.</returns>
        E03_Continent_ReChildDto Update(E03_Continent_ReChildDto e03_Continent_ReChild);

        /// <summary>
        /// Deletes the E03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID2">The parent Continent ID2.</param>
        void Delete(int continent_ID2);
    }
}
