using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D09_Region_Child type
    /// </summary>
    public partial interface ID09_Region_ChildDal
    {
        /// <summary>
        /// Loads a D09_Region_Child object from the database.
        /// </summary>
        /// <param name="region_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="D09_Region_ChildDto"/> object.</returns>
        D09_Region_ChildDto Fetch(int region_ID1);

        /// <summary>
        /// Inserts a new D09_Region_Child object in the database.
        /// </summary>
        /// <param name="d09_Region_Child">The D09 Region Child DTO.</param>
        /// <returns>The new <see cref="D09_Region_ChildDto"/>.</returns>
        D09_Region_ChildDto Insert(D09_Region_ChildDto d09_Region_Child);

        /// <summary>
        /// Updates in the database all changes made to the D09_Region_Child object.
        /// </summary>
        /// <param name="d09_Region_Child">The D09 Region Child DTO.</param>
        /// <returns>The updated <see cref="D09_Region_ChildDto"/>.</returns>
        D09_Region_ChildDto Update(D09_Region_ChildDto d09_Region_Child);

        /// <summary>
        /// Deletes the D09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        void Delete(int region_ID1);
    }
}
