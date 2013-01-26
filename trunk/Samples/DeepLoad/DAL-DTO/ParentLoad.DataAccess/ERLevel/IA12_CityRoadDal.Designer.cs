using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for A12_CityRoad type
    /// </summary>
    public partial interface IA12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new A12_CityRoad object in the database.
        /// </summary>
        /// <param name="a12_CityRoad">The A12 City Road DTO.</param>
        /// <returns>The new <see cref="A12_CityRoadDto"/>.</returns>
        A12_CityRoadDto Insert(A12_CityRoadDto a12_CityRoad);

        /// <summary>
        /// Updates in the database all changes made to the A12_CityRoad object.
        /// </summary>
        /// <param name="a12_CityRoad">The A12 City Road DTO.</param>
        /// <returns>The updated <see cref="A12_CityRoadDto"/>.</returns>
        A12_CityRoadDto Update(A12_CityRoadDto a12_CityRoad);

        /// <summary>
        /// Deletes the A12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        void Delete(int cityRoad_ID);
    }
}
