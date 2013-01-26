using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H08_Region type
    /// </summary>
    public partial interface IH08_RegionDal
    {
        /// <summary>
        /// Inserts a new H08_Region object in the database.
        /// </summary>
        /// <param name="h08_Region">The H08 Region DTO.</param>
        /// <returns>The new <see cref="H08_RegionDto"/>.</returns>
        H08_RegionDto Insert(H08_RegionDto h08_Region);

        /// <summary>
        /// Updates in the database all changes made to the H08_Region object.
        /// </summary>
        /// <param name="h08_Region">The H08 Region DTO.</param>
        /// <returns>The updated <see cref="H08_RegionDto"/>.</returns>
        H08_RegionDto Update(H08_RegionDto h08_Region);

        /// <summary>
        /// Deletes the H08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        void Delete(int region_ID);
    }
}
