using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F08_Region type
    /// </summary>
    public partial interface IF08_RegionDal
    {
        /// <summary>
        /// Inserts a new F08_Region object in the database.
        /// </summary>
        /// <param name="f08_Region">The F08 Region DTO.</param>
        /// <returns>The new <see cref="F08_RegionDto"/>.</returns>
        F08_RegionDto Insert(F08_RegionDto f08_Region);

        /// <summary>
        /// Updates in the database all changes made to the F08_Region object.
        /// </summary>
        /// <param name="f08_Region">The F08 Region DTO.</param>
        /// <returns>The updated <see cref="F08_RegionDto"/>.</returns>
        F08_RegionDto Update(F08_RegionDto f08_Region);

        /// <summary>
        /// Deletes the F08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        void Delete(int region_ID);
    }
}
