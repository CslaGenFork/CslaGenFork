using System;
using System.Data;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B05_SubContinent_ReChild type
    /// </summary>
    public partial interface IB05_SubContinent_ReChildDal
    {
        /// <summary>
        /// Inserts a new B05_SubContinent_ReChild object in the database.
        /// </summary>
        /// <param name="subContinent_ID2">The parent Sub Continent ID2.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        void Insert(int subContinent_ID2, string subContinent_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the B05_SubContinent_ReChild object.
        /// </summary>
        /// <param name="subContinent_ID2">The parent Sub Continent ID2.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        void Update(int subContinent_ID2, string subContinent_Child_Name);

        /// <summary>
        /// Deletes the B05_SubContinent_ReChild object from database.
        /// </summary>
        /// <param name="subContinent_ID2">The parent Sub Continent ID2.</param>
        void Delete(int subContinent_ID2);
    }
}
