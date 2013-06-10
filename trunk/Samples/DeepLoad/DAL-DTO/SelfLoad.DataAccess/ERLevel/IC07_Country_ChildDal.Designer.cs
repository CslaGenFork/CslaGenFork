using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C07_Country_Child type
    /// </summary>
    public partial interface IC07_Country_ChildDal
    {
        /// <summary>
        /// Loads a C07_Country_Child object from the database.
        /// </summary>
        /// <param name="country_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="C07_Country_ChildDto"/> object.</returns>
        C07_Country_ChildDto Fetch(int country_ID1);

        /// <summary>
        /// Inserts a new C07_Country_Child object in the database.
        /// </summary>
        /// <param name="c07_Country_Child">The C07 Country Child DTO.</param>
        /// <returns>The new <see cref="C07_Country_ChildDto"/>.</returns>
        C07_Country_ChildDto Insert(C07_Country_ChildDto c07_Country_Child);

        /// <summary>
        /// Updates in the database all changes made to the C07_Country_Child object.
        /// </summary>
        /// <param name="c07_Country_Child">The C07 Country Child DTO.</param>
        /// <returns>The updated <see cref="C07_Country_ChildDto"/>.</returns>
        C07_Country_ChildDto Update(C07_Country_ChildDto c07_Country_Child);

        /// <summary>
        /// Deletes the C07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        void Delete(int country_ID1);
    }
}
