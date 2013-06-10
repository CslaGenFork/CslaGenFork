using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D07_Country_Child type
    /// </summary>
    public partial interface ID07_Country_ChildDal
    {
        /// <summary>
        /// Loads a D07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="D07_Country_ChildDto"/> object.</returns>
        D07_Country_ChildDto Fetch(int country_ID1);

        /// <summary>
        /// Inserts a new D07_Country_Child object in the database.
        /// </summary>
        /// <param name="d07_Country_Child">The D07 Country Child DTO.</param>
        /// <returns>The new <see cref="D07_Country_ChildDto"/>.</returns>
        D07_Country_ChildDto Insert(D07_Country_ChildDto d07_Country_Child);

        /// <summary>
        /// Updates in the database all changes made to the D07_Country_Child object.
        /// </summary>
        /// <param name="d07_Country_Child">The D07 Country Child DTO.</param>
        /// <returns>The updated <see cref="D07_Country_ChildDto"/>.</returns>
        D07_Country_ChildDto Update(D07_Country_ChildDto d07_Country_Child);

        /// <summary>
        /// Deletes the D07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        void Delete(int country_ID1);
    }
}
