using System;
using System.Collections.Generic;
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
        /// <param name="country_ID2">The fetch criteria.</param>
        /// <returns>A <see cref="H07_Country_ReChildDto"/> object.</returns>
        H07_Country_ReChildDto Fetch(int country_ID2);

        /// <summary>
        /// Inserts a new H07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="h07_Country_ReChild">The H07 Country Re Child DTO.</param>
        /// <returns>The new <see cref="H07_Country_ReChildDto"/>.</returns>
        H07_Country_ReChildDto Insert(H07_Country_ReChildDto h07_Country_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the H07_Country_ReChild object.
        /// </summary>
        /// <param name="h07_Country_ReChild">The H07 Country Re Child DTO.</param>
        /// <returns>The updated <see cref="H07_Country_ReChildDto"/>.</returns>
        H07_Country_ReChildDto Update(H07_Country_ReChildDto h07_Country_ReChild);

        /// <summary>
        /// Deletes the H07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID">The parent Country ID.</param>
        void Delete(int country_ID);
    }
}
