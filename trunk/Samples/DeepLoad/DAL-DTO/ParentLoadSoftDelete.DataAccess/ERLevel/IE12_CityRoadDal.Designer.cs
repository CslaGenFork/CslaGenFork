using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E12_CityRoad type
    /// </summary>
    public partial interface IE12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new E12_CityRoad object in the database.
        /// </summary>
        /// <param name="e12_CityRoad">The E12 City Road DTO.</param>
        /// <returns>The new <see cref="E12_CityRoadDto"/>.</returns>
        E12_CityRoadDto Insert(E12_CityRoadDto e12_CityRoad);

        /// <summary>
        /// Updates in the database all changes made to the E12_CityRoad object.
        /// </summary>
        /// <param name="e12_CityRoad">The E12 City Road DTO.</param>
        /// <returns>The updated <see cref="E12_CityRoadDto"/>.</returns>
        E12_CityRoadDto Update(E12_CityRoadDto e12_CityRoad);

        /// <summary>
        /// Deletes the E12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        void Delete(int cityRoad_ID);
    }
}
