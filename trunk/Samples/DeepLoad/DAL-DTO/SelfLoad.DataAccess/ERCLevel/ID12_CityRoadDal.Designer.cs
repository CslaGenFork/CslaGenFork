using System;
using System.Collections.Generic;
using Csla;

namespace SelfLoad.DataAccess.ERCLevel
{
    /// <summary>
    /// DAL Interface for D12_CityRoad type
    /// </summary>
    public partial interface ID12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new D12_CityRoad object in the database.
        /// </summary>
        /// <param name="d12_CityRoad">The D12 City Road DTO.</param>
        /// <returns>The new <see cref="D12_CityRoadDto"/>.</returns>
        D12_CityRoadDto Insert(D12_CityRoadDto d12_CityRoad);

        /// <summary>
        /// Updates in the database all changes made to the D12_CityRoad object.
        /// </summary>
        /// <param name="d12_CityRoad">The D12 City Road DTO.</param>
        /// <returns>The updated <see cref="D12_CityRoadDto"/>.</returns>
        D12_CityRoadDto Update(D12_CityRoadDto d12_CityRoad);

        /// <summary>
        /// Deletes the D12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        void Delete(int cityRoad_ID);
    }
}
