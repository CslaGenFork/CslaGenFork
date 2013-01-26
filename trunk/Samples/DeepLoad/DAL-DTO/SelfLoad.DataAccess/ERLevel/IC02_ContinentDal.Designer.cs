using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C02_Continent type
    /// </summary>
    public partial interface IC02_ContinentDal
    {
        /// <summary>
        /// Loads a C02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The fetch criteria.</param>
        /// <returns>A <see cref="C02_ContinentDto"/> object.</returns>
        C02_ContinentDto Fetch(int continent_ID);

        /// <summary>
        /// Inserts a new C02_Continent object in the database.
        /// </summary>
        /// <param name="c02_Continent">The C02 Continent DTO.</param>
        /// <returns>The new <see cref="C02_ContinentDto"/>.</returns>
        C02_ContinentDto Insert(C02_ContinentDto c02_Continent);

        /// <summary>
        /// Updates in the database all changes made to the C02_Continent object.
        /// </summary>
        /// <param name="c02_Continent">The C02 Continent DTO.</param>
        /// <returns>The updated <see cref="C02_ContinentDto"/>.</returns>
        C02_ContinentDto Update(C02_ContinentDto c02_Continent);

        /// <summary>
        /// Deletes the C02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The delete criteria.</param>
        void Delete(int continent_ID);
    }
}
