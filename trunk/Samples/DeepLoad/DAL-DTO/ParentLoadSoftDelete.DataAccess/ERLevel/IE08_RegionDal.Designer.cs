using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E08_Region type
    /// </summary>
    public partial interface IE08_RegionDal
    {
        /// <summary>
        /// Inserts a new E08_Region object in the database.
        /// </summary>
        /// <param name="e08_Region">The E08 Region DTO.</param>
        /// <returns>The new <see cref="E08_RegionDto"/>.</returns>
        E08_RegionDto Insert(E08_RegionDto e08_Region);

        /// <summary>
        /// Updates in the database all changes made to the E08_Region object.
        /// </summary>
        /// <param name="e08_Region">The E08 Region DTO.</param>
        /// <returns>The updated <see cref="E08_RegionDto"/>.</returns>
        E08_RegionDto Update(E08_RegionDto e08_Region);

        /// <summary>
        /// Deletes the E08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        void Delete(int region_ID);
    }
}
