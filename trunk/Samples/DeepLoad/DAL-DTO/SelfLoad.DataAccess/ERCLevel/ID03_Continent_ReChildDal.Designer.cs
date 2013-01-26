using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D03_Continent_ReChild type
    /// </summary>
    public partial interface ID03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a D03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="D03_Continent_ReChildDto"/> object.</returns>
        D03_Continent_ReChildDto Fetch(int continent_ID2);

        /// <summary>
        /// Inserts a new D03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="d03_Continent_ReChild">The D03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="D03_Continent_ReChildDto"/>.</returns>
        D03_Continent_ReChildDto Insert(D03_Continent_ReChildDto d03_Continent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the D03_Continent_ReChild object.
        /// </summary>
        /// <param name="d03_Continent_ReChild">The D03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="D03_Continent_ReChildDto"/>.</returns>
        D03_Continent_ReChildDto Update(D03_Continent_ReChildDto d03_Continent_ReChild);

        /// <summary>
        /// Deletes the D03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        void Delete(int continent_ID);
    }
}
