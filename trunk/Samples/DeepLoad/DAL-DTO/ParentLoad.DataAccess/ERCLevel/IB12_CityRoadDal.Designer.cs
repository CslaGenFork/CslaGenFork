using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for B12_CityRoad type
    /// </summary>
    public partial interface IB12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new B12_CityRoad object in the database.
        /// </summary>
        /// <param name="b12_CityRoad">The B12 City Road DTO.</param>
        /// <returns>The new <see cref="B12_CityRoadDto"/>.</returns>
        B12_CityRoadDto Insert(B12_CityRoadDto b12_CityRoad);

        /// <summary>
        /// Updates in the database all changes made to the B12_CityRoad object.
        /// </summary>
        /// <param name="b12_CityRoad">The B12 City Road DTO.</param>
        /// <returns>The updated <see cref="B12_CityRoadDto"/>.</returns>
        B12_CityRoadDto Update(B12_CityRoadDto b12_CityRoad);

        /// <summary>
        /// Deletes the B12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        void Delete(int cityRoad_ID);
    }
}
