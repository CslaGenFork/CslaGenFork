using System;
using System.Data;
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
        /// <param name="region_ID">The parent Region ID.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        
        void Insert(int region_ID, string region_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the B09_Region_ReChild object.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        /// <param name="region_Child_Name">The Region Child Name.</param>
        
        void Update(int region_ID, string region_Child_Name);

        /// <summary>
        /// Deletes the B09_Region_ReChild object from database.
        /// </summary>
        /// <param name="region_ID">The parent Region ID.</param>
        void Delete(int region_ID);
    }
}
