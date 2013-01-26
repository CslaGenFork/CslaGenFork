using System;
using System.Collections.Generic;
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
        /// <param name="country_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="H07_Country_ChildDto"/> object.</returns>
        H07_Country_ChildDto Fetch(int country_ID1);

        /// <summary>
        /// Inserts a new H07_Country_Child object in the database.
        /// </summary>
        /// <param name="h07_Country_Child">The H07 Country Child DTO.</param>
        /// <returns>The new <see cref="H07_Country_ChildDto"/>.</returns>
        H07_Country_ChildDto Insert(H07_Country_ChildDto h07_Country_Child);

        /// <summary>
        /// Updates in the database all changes made to the H07_Country_Child object.
        /// </summary>
        /// <param name="h07_Country_Child">The H07 Country Child DTO.</param>
        /// <returns>The updated <see cref="H07_Country_ChildDto"/>.</returns>
        H07_Country_ChildDto Update(H07_Country_ChildDto h07_Country_Child);

        /// <summary>
        /// Deletes the H07_Country_Child object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        void Delete(int country_ID);
    }
}
