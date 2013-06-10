using System;
using System.Data;
using Csla;

namespace SelfLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for H07_Country_Child type
    /// </summary>
    public partial interface IH07_Country_ChildDal
    {
        /// <summary>
        /// Loads a H07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The Country ID1.</param>
        /// <returns>A data reader to the H07_Country_Child.</returns>
        IDataReader Fetch(int country_ID1);

        /// <summary>
        /// Inserts a new H07_Country_Child object in the database.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        void Insert(int country_ID1, string country_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the H07_Country_Child object.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        void Update(int country_ID1, string country_Child_Name);

        /// <summary>
        /// Deletes the H07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        void Delete(int country_ID1);
    }
}
