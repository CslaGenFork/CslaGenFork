using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A03_Continent_ReChild type
    /// </summary>
    public partial interface IA03_Continent_ReChildDal
    {
        /// <summary>
        /// Inserts a new A03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="a03_Continent_ReChild">The A03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="A03_Continent_ReChildDto"/>.</returns>
        A03_Continent_ReChildDto Insert(A03_Continent_ReChildDto a03_Continent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the A03_Continent_ReChild object.
        /// </summary>
        /// <param name="a03_Continent_ReChild">The A03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="A03_Continent_ReChildDto"/>.</returns>
        A03_Continent_ReChildDto Update(A03_Continent_ReChildDto a03_Continent_ReChild);

        /// <summary>
        /// Deletes the A03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID2">The parent Continent ID2.</param>
        void Delete(int continent_ID2);
    }
}
