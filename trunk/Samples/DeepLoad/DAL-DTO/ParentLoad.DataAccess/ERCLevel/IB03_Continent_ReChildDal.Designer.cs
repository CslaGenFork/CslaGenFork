using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B03_Continent_ReChild type
    /// </summary>
    public partial interface IB03_Continent_ReChildDal
    {
        /// <summary>
        /// Inserts a new B03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="b03_Continent_ReChild">The B03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="B03_Continent_ReChildDto"/>.</returns>
        B03_Continent_ReChildDto Insert(B03_Continent_ReChildDto b03_Continent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the B03_Continent_ReChild object.
        /// </summary>
        /// <param name="b03_Continent_ReChild">The B03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="B03_Continent_ReChildDto"/>.</returns>
        B03_Continent_ReChildDto Update(B03_Continent_ReChildDto b03_Continent_ReChild);

        /// <summary>
        /// Deletes the B03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID2">The parent Continent ID2.</param>
        void Delete(int continent_ID2);
    }
}
