using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B08_Region type
    /// </summary>
    public partial interface IB08_RegionDal
    {
        /// <summary>
        /// Inserts a new B08_Region object in the database.
        /// </summary>
        /// <param name="b08_Region">The B08 Region DTO.</param>
        /// <returns>The new <see cref="B08_RegionDto"/>.</returns>
        B08_RegionDto Insert(B08_RegionDto b08_Region);

        /// <summary>
        /// Updates in the database all changes made to the B08_Region object.
        /// </summary>
        /// <param name="b08_Region">The B08 Region DTO.</param>
        /// <returns>The updated <see cref="B08_RegionDto"/>.</returns>
        B08_RegionDto Update(B08_RegionDto b08_Region);

        /// <summary>
        /// Deletes the B08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        void Delete(int region_ID);
    }
}
