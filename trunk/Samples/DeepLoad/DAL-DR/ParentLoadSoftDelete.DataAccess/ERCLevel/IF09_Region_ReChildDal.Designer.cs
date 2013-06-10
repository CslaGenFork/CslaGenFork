using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F09_Region_ReChild type
    /// </summary>
    public partial interface IF09_Region_ReChildDal
    {
        /// <summary>
        /// Inserts a new F09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        void Insert(int region_ID2, string region_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the F09_Region_ReChild object.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        void Update(int region_ID2, string region_Child_Name);

        /// <summary>
        /// Deletes the F09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        void Delete(int region_ID2);
    }
}
