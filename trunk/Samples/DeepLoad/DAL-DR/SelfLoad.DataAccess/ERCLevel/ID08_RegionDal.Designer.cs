using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D08_Region type
    /// </summary>
    public partial interface ID08_RegionDal
    {
        /// <summary>
        /// Inserts a new D08_Region object in the database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="region_ID">The Region ID.</param>
        /// <param name="region_Name">The Region Name.</param>
        void Insert(int country_ID, out int region_ID, string region_Name);

        /// <summary>
        /// Updates in the database all changes made to the D08_Region object.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        /// <param name="region_Name">The Region Name.</param>
        void Update(int region_ID, string region_Name);

        /// <summary>
        /// Deletes the D08_Region object from database.
        /// </summary>
        /// <param name="region_ID">The Region ID.</param>
        void Delete(int region_ID);
    }
}
