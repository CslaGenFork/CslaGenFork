using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B07_Country_ReChild type
    /// </summary>
    public partial interface IB07_Country_ReChildDal
    {
        /// <summary>
        /// Inserts a new B07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="b07_Country_ReChild">The B07 Country Re Child DTO.</param>
        /// <returns>The new <see cref="B07_Country_ReChildDto"/>.</returns>
        B07_Country_ReChildDto Insert(B07_Country_ReChildDto b07_Country_ReChild);

        /// <summary>
        /// Updates in the database all changes made to the B07_Country_ReChild object.
        /// </summary>
        /// <param name="b07_Country_ReChild">The B07 Country Re Child DTO.</param>
        /// <returns>The updated <see cref="B07_Country_ReChildDto"/>.</returns>
        B07_Country_ReChildDto Update(B07_Country_ReChildDto b07_Country_ReChild);

        /// <summary>
        /// Deletes the B07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        void Delete(int country_ID2);
    }
}
