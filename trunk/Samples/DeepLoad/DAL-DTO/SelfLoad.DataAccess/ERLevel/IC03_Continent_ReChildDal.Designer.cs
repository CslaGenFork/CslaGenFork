using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C03_Continent_ReChild type
    /// </summary>
    public partial interface IC03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a C03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="C03_Continent_ReChildDto"/> object.</returns>
        C03_Continent_ReChildDto Fetch(int continent_ID2);

        /// <summary>
        /// Inserts a new C03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="c03_Continent_ReChild">The C03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="C03_Continent_ReChildDto"/>.</returns>
        C03_Continent_ReChildDto Insert(C03_Continent_ReChildDto c03_Continent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the C03_Continent_ReChild object.
        /// </summary>
        /// <param name="c03_Continent_ReChild">The C03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="C03_Continent_ReChildDto"/>.</returns>
        C03_Continent_ReChildDto Update(C03_Continent_ReChildDto c03_Continent_ReChild);

        /// <summary>
        /// Deletes the C03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        void Delete(int continent_ID);
    }
}
