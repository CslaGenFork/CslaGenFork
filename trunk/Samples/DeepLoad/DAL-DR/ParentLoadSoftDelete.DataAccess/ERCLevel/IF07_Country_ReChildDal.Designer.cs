using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F07_Country_ReChild type
    /// </summary>
    public partial interface IF07_Country_ReChildDal
    {
        /// <summary>
        /// Inserts a new F07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        void Insert(int country_ID, string country_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the F07_Country_ReChild object.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        void Update(int country_ID, string country_Child_Name);

        /// <summary>
        /// Deletes the F07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        void Delete(int country_ID);
    }
}
