using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H03_Continent_ReChild type
    /// </summary>
    public partial interface IH03_Continent_ReChildDal
    {
        /// <summary>
        /// Loads a H03_Continent_ReChild object from the database.
        /// </summary>
        /// <param name="continent_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="H03_Continent_ReChildDto"/> object.</returns>
        H03_Continent_ReChildDto Fetch(int continent_ID2);

        /// <summary>
        /// Inserts a new H03_Continent_ReChild object in the database.
        /// </summary>
        /// <param name="h03_Continent_ReChild">The H03 Continent Re Child DTO.</param>
        /// <returns>The new <see cref="H03_Continent_ReChildDto"/>.</returns>
        H03_Continent_ReChildDto Insert(H03_Continent_ReChildDto h03_Continent_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the H03_Continent_ReChild object.
        /// </summary>
        /// <param name="h03_Continent_ReChild">The H03 Continent Re Child DTO.</param>
        /// <returns>The updated <see cref="H03_Continent_ReChildDto"/>.</returns>
        H03_Continent_ReChildDto Update(H03_Continent_ReChildDto h03_Continent_ReChild);

        /// <summary>
        /// Deletes the H03_Continent_ReChild object from database.
        /// </summary>
        /// <param name="continent_ID">The parent Continent ID.</param>
        void Delete(int continent_ID);
    }
}
