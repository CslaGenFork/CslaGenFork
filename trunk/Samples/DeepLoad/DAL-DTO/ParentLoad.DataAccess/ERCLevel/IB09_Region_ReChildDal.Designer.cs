using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B09_Region_ReChild type
    /// </summary>
    public partial interface IB09_Region_ReChildDal
    {
        /// <summary>
        /// Inserts a new B09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="b09_Region_ReChild">The B09 Region Re Child DTO.</param>
        /// <returns>The new <see cref="B09_Region_ReChildDto"/>.</returns>
        B09_Region_ReChildDto Insert(B09_Region_ReChildDto b09_Region_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the B09_Region_ReChild object.
        /// </summary>
        /// <param name="b09_Region_ReChild">The B09 Region Re Child DTO.</param>
        /// <returns>The updated <see cref="B09_Region_ReChildDto"/>.</returns>
        B09_Region_ReChildDto Update(B09_Region_ReChildDto b09_Region_ReChild);

        /// <summary>
        /// Deletes the B09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        void Delete(int region_ID);
    }
}
