using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C05_SubContinent_Child type
    /// </summary>
    public partial interface IC05_SubContinent_ChildDal
    {
        /// <summary>
        /// Loads a C05_SubContinent_Child object from the database.
        /// </summary>
        /// <param name="parentSubContinent_ID1">The fetch criteria.</param>
        /// <returns>A <see cref="C05_SubContinent_ChildDto"/> object.</returns>
        C05_SubContinent_ChildDto Fetch(int parentSubContinent_ID1);

        /// <summary>
        /// Inserts a new C05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="c05_SubContinent_Child">The C05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="C05_SubContinent_ChildDto"/>.</returns>
        C05_SubContinent_ChildDto Insert(C05_SubContinent_ChildDto c05_SubContinent_Child);

        /// <summary>
        /// Updates in the database all changes made to the C05_SubContinent_Child object.
        /// </summary>
        /// <param name="c05_SubContinent_Child">The C05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="C05_SubContinent_ChildDto"/>.</returns>
        C05_SubContinent_ChildDto Update(C05_SubContinent_ChildDto c05_SubContinent_Child);

        /// <summary>
        /// Deletes the C05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID1">The parent Sub Continent ID1.</param>
        void Delete(int subContinent_ID1);
    }
}
