using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B09_Region_Child type
    /// </summary>
    public partial interface IB09_Region_ChildDal
    {
        /// <summary>
        /// Inserts a new B09_Region_Child object in the database.
        /// </summary>
        /// <param name="b09_Region_Child">The B09 Region Child DTO.</param>
        /// <returns>The new <see cref="B09_Region_ChildDto"/>.</returns>
        B09_Region_ChildDto Insert(B09_Region_ChildDto b09_Region_Child);

        /// <summary>
        /// Updates in the database all changes made to the B09_Region_Child object.
        /// </summary>
        /// <param name="b09_Region_Child">The B09 Region Child DTO.</param>
        /// <returns>The updated <see cref="B09_Region_ChildDto"/>.</returns>
        B09_Region_ChildDto Update(B09_Region_ChildDto b09_Region_Child);

        /// <summary>
        /// Deletes the B09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        void Delete(int region_ID1);
    }
}
