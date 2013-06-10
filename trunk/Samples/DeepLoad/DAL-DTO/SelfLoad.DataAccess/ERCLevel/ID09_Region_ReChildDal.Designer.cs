using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D09_Region_ReChild type
    /// </summary>
    public partial interface ID09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a D09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="D09_Region_ReChildDto"/> object.</returns>
        D09_Region_ReChildDto Fetch(int region_ID2);

        /// <summary>
        /// Inserts a new D09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="d09_Region_ReChild">The D09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="D09_Region_ReChildDto"/>.</returns>
        D09_Region_ReChildDto Insert(D09_Region_ReChildDto d09_Region_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the D09_Region_ReChild object.
        /// </summary>
        /// <param name="d09_Region_ReChild">The D09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="D09_Region_ReChildDto"/>.</returns>
        D09_Region_ReChildDto Update(D09_Region_ReChildDto d09_Region_ReChild);

        /// <summary>
        /// Deletes the D09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        void Delete(int region_ID2);
    }
}
