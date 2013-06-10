using System;
using System.Data;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B07_Country_Child type
    /// </summary>
    public partial interface IB07_Country_ChildDal
    {
        /// <summary>
        /// Inserts a new B07_Country_Child object in the database.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        void Insert(int country_ID1, string country_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the B07_Country_Child object.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        void Update(int country_ID1, string country_Child_Name);

        /// <summary>
        /// Deletes the B07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        void Delete(int country_ID1);
    }
}
