using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for F07_Country_Child type
    /// </summary>
    public partial interface IF07_Country_ChildDal
    {
        /// <summary>
        /// Inserts a new F07_Country_Child object in the database.
        /// </summary>
        /// <param name="f07_Country_Child">The F07 Country Child DTO.</param>
        /// <returns>The new <see cref="F07_Country_ChildDto"/>.</returns>
        F07_Country_ChildDto Insert(F07_Country_ChildDto f07_Country_Child);

        /// <summary>
        /// Updates in the database all changes made to the F07_Country_Child object.
        /// </summary>
        /// <param name="f07_Country_Child">The F07 Country Child DTO.</param>
        /// <returns>The updated <see cref="F07_Country_ChildDto"/>.</returns>
        F07_Country_ChildDto Update(F07_Country_ChildDto f07_Country_Child);

        /// <summary>
        /// Deletes the F07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID1">The parent Country ID1.</param>
        void Delete(int country_ID1);
    }
}
