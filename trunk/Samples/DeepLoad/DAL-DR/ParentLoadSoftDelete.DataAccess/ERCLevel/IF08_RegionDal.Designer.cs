using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F08_Region type
    /// </summary>
    public partial interface IF08_RegionDal
    {
        /// <summary>
        /// Inserts a new F08_Region object in the database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="region_ID">The Region ID.</param>
        /// <param name="region_Name">The Region Name.</param>
        void Insert(int country_ID, out int region_ID, string region_Name);

        /// <summary>
        /// Updates in the database all changes made to the F08_Region object.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        /// <param name="region_Name">The Region Name.</param>
        void Update(int region_ID, string region_Name);

        /// <summary>
        /// Deletes the F08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        void Delete(int region_ID);
    }
}
