using System;
using System.Data;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E07_Country_ReChild type
    /// </summary>
    public partial interface IE07_Country_ReChildDal
    {
        /// <summary>
        /// Inserts a new E07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        void Insert(int country_ID2, string country_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the E07_Country_ReChild object.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        void Update(int country_ID2, string country_Child_Name);

        /// <summary>
        /// Deletes the E07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        void Delete(int country_ID2);
    }
}
