using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H09_Region_ReChild type
    /// </summary>
    public partial interface IH09_Region_ReChildDal
    {
        /// <summary>
        /// Loads a H09_Region_ReChild object from the database.
        /// </summary>
        /// <param name="region_ID2">The Region ID2.</param>
        /// <returns>A data reader to the H09_Region_ReChild.</returns>
        IDataReader Fetch(int region_ID2);

        /// <summary>
        /// Inserts a new H09_Region_ReChild object in the database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        void Insert(int region_ID2, string region_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the H09_Region_ReChild object.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        void Update(int region_ID2, string region_Child_Name);

        /// <summary>
        /// Deletes the H09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID2">The parent Region ID2.</param>
        void Delete(int region_ID2);
    }
}
