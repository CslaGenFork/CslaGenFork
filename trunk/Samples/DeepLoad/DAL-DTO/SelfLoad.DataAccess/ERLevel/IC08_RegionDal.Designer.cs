using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C08_Region type
    /// </summary>
    public partial interface IC08_RegionDal
    {
        /// <summary>
        /// Inserts a new C08_Region object in the database.
        /// </summary>
        /// <param name="c08_Region">The C08 Region DTO.</param>
        /// <returns>The new <see cref="C08_RegionDto"/>.</returns>
        C08_RegionDto Insert(C08_RegionDto c08_Region);

        /// <summary>
        /// Updates in the database all changes made to the C08_Region object.
        /// </summary>
        /// <param name="c08_Region">The C08 Region DTO.</param>
        /// <returns>The updated <see cref="C08_RegionDto"/>.</returns>
        C08_RegionDto Update(C08_RegionDto c08_Region);

        /// <summary>
        /// Deletes the C08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        void Delete(int region_ID);
    }
}
