using System;
using System.Collections.Generic;
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
        /// <param name="b07_Country_Child">The B07 Country Child DTO.</param>
        /// <returns>The new <see cref="B07_Country_ChildDto"/>.</returns>
        B07_Country_ChildDto Insert(B07_Country_ChildDto b07_Country_Child);

        /// <summary>
        /// Updates in the database all changes made to the B07_Country_Child object.
        /// </summary>
        /// <param name="b07_Country_Child">The B07 Country Child DTO.</param>
        /// <returns>The updated <see cref="B07_Country_ChildDto"/>.</returns>
        B07_Country_ChildDto Update(B07_Country_ChildDto b07_Country_Child);

        /// <summary>
        /// Deletes the B07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        void Delete(int country_ID);
    }
}
