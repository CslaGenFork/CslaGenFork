using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A07_Country_Child type
    /// </summary>
    public partial interface IA07_Country_ChildDal
    {
        /// <summary>
        /// Inserts a new A07_Country_Child object in the database.
        /// </summary>
        /// <param name="a07_Country_Child">The A07 Country Child DTO.</param>
        /// <returns>The new <see cref="A07_Country_ChildDto"/>.</returns>
        A07_Country_ChildDto Insert(A07_Country_ChildDto a07_Country_Child);

        /// <summary>
        /// Updates in the database all changes made to the A07_Country_Child object.
        /// </summary>
        /// <param name="a07_Country_Child">The A07 Country Child DTO.</param>
        /// <returns>The updated <see cref="A07_Country_ChildDto"/>.</returns>
        A07_Country_ChildDto Update(A07_Country_ChildDto a07_Country_Child);

        /// <summary>
        /// Deletes the A07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        void Delete(int country_ID1);
    }
}
