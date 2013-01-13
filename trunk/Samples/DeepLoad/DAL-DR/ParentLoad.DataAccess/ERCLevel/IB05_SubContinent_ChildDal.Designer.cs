using System;
using System.Data;
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
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        void Insert(int subContinent_ID, string subContinent_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the B05_SubContinent_Child object.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        /// <param name="subContinent_Child_Name">The Sub Continent Child Name.</param>
        void Update(int subContinent_ID, string subContinent_Child_Name);

        /// <summary>
        /// Deletes the B05_SubContinent_Child object from database.
        /// </summary>
        /// <param name="subContinent_ID">The parent Sub Continent ID.</param>
        void Delete(int subContinent_ID);
    }
}
