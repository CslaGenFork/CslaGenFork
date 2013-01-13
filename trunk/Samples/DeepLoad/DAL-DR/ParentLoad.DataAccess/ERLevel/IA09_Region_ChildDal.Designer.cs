using System;
using System.Data;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A09_Region_Child type
    /// </summary>
    public partial interface IA09_Region_ChildDal
    {
        /// <summary>
        /// Inserts a new A09_Region_Child object in the database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        void Insert(int region_ID, string region_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the A09_Region_Child object.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        void Update(int region_ID, string region_Child_Name);

        /// <summary>
        /// Deletes the A09_Region_Child object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        void Delete(int region_ID);
    }
}
