using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E09_Region_Child type
    /// </summary>
    public partial interface IE09_Region_ChildDal
    {
        /// <summary>
        /// Inserts a new E09_Region_Child object in the database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        void Insert(int region_ID1, string region_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the E09_Region_Child object.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        void Update(int region_ID1, string region_Child_Name);

        /// <summary>
        /// Deletes the E09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID1">The parent Region ID1.</param>
        void Delete(int region_ID1);
    }
}
