using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E07_Country_Child type
    /// </summary>
    public partial interface IE07_Country_ChildDal
    {
        /// <summary>
        /// Inserts a new E07_Country_Child object in the database.
        /// </summary>
        /// <param name="e07_Country_Child">The E07 Country Child DTO.</param>
        /// <returns>The new <see cref="E07_Country_ChildDto"/>.</returns>
        E07_Country_ChildDto Insert(E07_Country_ChildDto e07_Country_Child);

        /// <summary>
        /// Updates in the database all changes made to the E07_Country_Child object.
        /// </summary>
        /// <param name="e07_Country_Child">The E07 Country Child DTO.</param>
        /// <returns>The updated <see cref="E07_Country_ChildDto"/>.</returns>
        E07_Country_ChildDto Update(E07_Country_ChildDto e07_Country_Child);

        /// <summary>
        /// Deletes the E07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        void Delete(int country_ID1);
    }
}
