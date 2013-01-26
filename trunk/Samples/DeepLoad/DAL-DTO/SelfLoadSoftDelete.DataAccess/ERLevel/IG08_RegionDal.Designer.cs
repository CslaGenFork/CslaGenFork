using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for G08_Region type
    /// </summary>
    public partial interface IG08_RegionDal
    {
        /// <summary>
        /// Inserts a new G08_Region object in the database.
        /// </summary>
        /// <param name="g08_Region">The G08 Region DTO.</param>
        /// <returns>The new <see cref="G08_RegionDto"/>.</returns>
        G08_RegionDto Insert(G08_RegionDto g08_Region);

        /// <summary>
        /// Updates in the database all changes made to the G08_Region object.
        /// </summary>
        /// <param name="g08_Region">The G08 Region DTO.</param>
        /// <returns>The updated <see cref="G08_RegionDto"/>.</returns>
        G08_RegionDto Update(G08_RegionDto g08_Region);

        /// <summary>
        /// Deletes the G08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        void Delete(int region_ID);
    }
}
