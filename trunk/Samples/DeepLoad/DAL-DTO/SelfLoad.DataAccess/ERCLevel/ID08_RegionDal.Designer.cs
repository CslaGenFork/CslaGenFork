using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D08_Region type
    /// </summary>
    public partial interface ID08_RegionDal
    {
        /// <summary>
        /// Inserts a new D08_Region object in the database.
        /// </summary>
        /// <param name="d08_Region">The D08 Region DTO.</param>
        /// <returns>The new <see cref="D08_RegionDto"/>.</returns>
        D08_RegionDto Insert(D08_RegionDto d08_Region);

        /// <summary>
        /// Updates in the database all changes made to the D08_Region object.
        /// </summary>
        /// <param name="d08_Region">The D08 Region DTO.</param>
        /// <returns>The updated <see cref="D08_RegionDto"/>.</returns>
        D08_RegionDto Update(D08_RegionDto d08_Region);

        /// <summary>
        /// Deletes the D08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        void Delete(int region_ID);
    }
}
