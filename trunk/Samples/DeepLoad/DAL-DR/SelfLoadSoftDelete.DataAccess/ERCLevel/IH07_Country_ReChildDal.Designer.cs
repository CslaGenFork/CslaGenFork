using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H07_Country_ReChild type
    /// </summary>
    public partial interface IH07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a H07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The Country ID2.</param>
        /// <returns>A data reader to the H07_Country_ReChild.</returns>
        IDataReader Fetch(int country_ID2);

        /// <summary>
        /// Inserts a new H07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        void Insert(int country_ID, string country_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the H07_Country_ReChild object.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        void Update(int country_ID, string country_Child_Name);

        /// <summary>
        /// Deletes the H07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        void Delete(int country_ID);
    }
}
