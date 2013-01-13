using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C09_Region_ReChild type
    /// </summary>
    public partial interface IC09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a C09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The Region ID2.</param>
        /// <returns>A data reader to the C09_Region_ReChild.</returns>
        IDataReader Fetch(int region_ID2);

        /// <summary>
        /// Inserts a new C09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        void Insert(int region_ID, string region_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the C09_Region_ReChild object.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        void Update(int region_ID, string region_Child_Name);

        /// <summary>
        /// Deletes the C09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        void Delete(int region_ID);
    }
}
