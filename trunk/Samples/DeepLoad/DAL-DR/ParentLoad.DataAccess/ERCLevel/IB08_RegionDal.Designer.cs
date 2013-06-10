using System;
using System.Data;
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
        /// <param name="parent_Country_ID">The parent Parent Country ID.</param>
        /// <param name="region_ID">The Region ID.</param>
        /// <param name="region_Name">The Region Name.</param>
        void Insert(int parent_Country_ID, out int region_ID, string region_Name);

        /// <summary>
        /// Updates in the database all changes made to the B08_Region object.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        /// <param name="region_Name">The Region Name.</param>
        void Update(int region_ID, string region_Name);

        /// <summary>
        /// Deletes the B08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        void Delete(int region_ID);
    }
}
