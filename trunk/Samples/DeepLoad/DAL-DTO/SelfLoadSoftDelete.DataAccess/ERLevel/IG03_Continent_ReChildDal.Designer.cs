using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G03_Continent_ReChild type
    /// </summary>
    public partial interface IG03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a G03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="G03_Continent_ReChildDto"/> object.</returns>
        G03_Continent_ReChildDto Fetch(int continent_ID2);

        /// <summary>
        /// Inserts a new G03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="g03_Continent_ReChild">The G03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="G03_Continent_ReChildDto"/>.</returns>
        G03_Continent_ReChildDto Insert(G03_Continent_ReChildDto g03_Continent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the G03_Continent_ReChild object.
        /// </summary>
        /// <param name="g03_Continent_ReChild">The G03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="G03_Continent_ReChildDto"/>.</returns>
        G03_Continent_ReChildDto Update(G03_Continent_ReChildDto g03_Continent_ReChild);

        /// <summary>
        /// Deletes the G03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        void Delete(int continent_ID);
    }
}
