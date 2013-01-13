using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C07_Country_ReChild type
    /// </summary>
    public partial interface IC07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a C07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The Country ID2.</param>
        /// <returns>A data reader to the C07_Country_ReChild.</returns>
        IDataReader Fetch(int country_ID2);

        /// <summary>
        /// Inserts a new C07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        void Insert(int country_ID, string country_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the C07_Country_ReChild object.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        void Update(int country_ID, string country_Child_Name);

        /// <summary>
        /// Deletes the C07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        void Delete(int country_ID);
    }
}
