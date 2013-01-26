using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for C12_CityRoad type
    /// </summary>
    public partial interface IC12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new C12_CityRoad object in the database.
        /// </summary>
        /// <param name="c12_CityRoad">The C12 City Road DTO.</param>
        /// <returns>The new <see cref="C12_CityRoadDto"/>.</returns>
        C12_CityRoadDto Insert(C12_CityRoadDto c12_CityRoad);

        /// <summary>
        /// Updates in the database all changes made to the C12_CityRoad object.
        /// </summary>
        /// <param name="c12_CityRoad">The C12 City Road DTO.</param>
        /// <returns>The updated <see cref="C12_CityRoadDto"/>.</returns>
        C12_CityRoadDto Update(C12_CityRoadDto c12_CityRoad);

        /// <summary>
        /// Deletes the C12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        void Delete(int cityRoad_ID);
    }
}
