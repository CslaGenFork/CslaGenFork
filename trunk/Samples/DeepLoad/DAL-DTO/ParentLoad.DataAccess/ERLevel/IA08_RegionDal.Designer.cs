using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A08_Region type
    /// </summary>
    public partial interface IA08_RegionDal
    {
        /// <summary>
        /// Inserts a new A08_Region object in the database.
        /// </summary>
        /// <param name="a08_Region">The A08 Region DTO.</param>
        /// <returns>The new <see cref="A08_RegionDto"/>.</returns>
        A08_RegionDto Insert(A08_RegionDto a08_Region);

        /// <summary>
        /// Updates in the database all changes made to the A08_Region object.
        /// </summary>
        /// <param name="a08_Region">The A08 Region DTO.</param>
        /// <returns>The updated <see cref="A08_RegionDto"/>.</returns>
        A08_RegionDto Update(A08_RegionDto a08_Region);

        /// <summary>
        /// Deletes the A08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        void Delete(int region_ID);
    }
}
