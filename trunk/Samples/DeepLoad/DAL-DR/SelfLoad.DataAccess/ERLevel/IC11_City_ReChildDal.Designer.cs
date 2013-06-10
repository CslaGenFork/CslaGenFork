using System;
using System.Data;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C11_City_ReChild type
    /// </summary>
    public partial interface IC11_City_ReChildDal
    {
        /// <summary>
        /// Loads a C11_City_ReChild object from the database.
        /// </summary>
        /// <param name="city_ID2">The City ID2.</param>
        /// <returns>A data reader to the C11_City_ReChild.</returns>
        IDataReader Fetch(int city_ID2);

        /// <summary>
        /// Inserts a new C11_City_ReChild object in the database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        void Insert(int city_ID2, string city_Child_Name);

        /// <summary>
        /// Updates in the database all changes made to the C11_City_ReChild object.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        /// <param name="city_Child_Name">The City Child Name.</param>
        void Update(int city_ID2, string city_Child_Name);

        /// <summary>
        /// Deletes the C11_City_ReChild object from database.
        /// </summary>
        /// <param name="city_ID2">The parent City ID2.</param>
        void Delete(int city_ID2);
    }
}
