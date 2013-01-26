using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B05_SubContinent_Child type
    /// </summary>
    public partial interface IB05_SubContinent_ChildDal
    {
        /// <summary>
        /// Inserts a new B05_SubContinent_Child object in the database.
        /// </summary>
        /// <param name="b05_SubContinent_Child">The B05 Sub Continent Child DTO.</param>
        /// <returns>The new <see cref="B05_SubContinent_ChildDto"/>.</returns>
        B05_SubContinent_ChildDto Insert(B05_SubContinent_ChildDto b05_SubContinent_Child);

        /// <summary>
        /// Updates in the database all changes made to the B05_SubContinent_Child object.
        /// </summary>
        /// <param name="b05_SubContinent_Child">The B05 Sub Continent Child DTO.</param>
        /// <returns>The updated <see cref="B05_SubContinent_ChildDto"/>.</returns>
        B05_SubContinent_ChildDto Update(B05_SubContinent_ChildDto b05_SubContinent_Child);

        /// <summary>
        /// Deletes the B05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
