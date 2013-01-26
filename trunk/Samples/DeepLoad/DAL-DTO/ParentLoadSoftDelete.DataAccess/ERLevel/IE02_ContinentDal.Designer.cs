using System;
using System.Collections.Generic;
using Csla;

namespace ParentLoadSoftDelete.DataAccess.ERLevel
{
    /// <summary>
    /// DAL Interface for E02_Continent type
    /// </summary>
    public partial interface IE02_ContinentDal
    {
        /// <summary>
        /// Gets the E03 Continent Single Object.
        /// </summary>
        /// <value>A <see cref="E03_Continent_ChildDto"/> object.</value>
        E03_Continent_ChildDto E03_Continent_Child { get; }

        /// <summary>
        /// Gets the E03 Continent ASingle Object.
        /// </summary>
        /// <value>A <see cref="E03_Continent_ReChildDto"/> object.</value>
        E03_Continent_ReChildDto E03_Continent_ReChild { get; }

        /// <summary>
        /// Gets the E03 SubContinent Objects.
        /// </summary>
        /// <value>A list of <see cref="E04_SubContinentDto"/>.</value>
        List<E04_SubContinentDto> E03_SubContinentColl { get; }

        /// <summary>
        /// Gets the E05 SubContinent Single Object.
        /// </summary>
        /// <value>A list of <see cref="E05_SubContinent_ChildDto"/>.</value>
        List<E05_SubContinent_ChildDto> E05_SubContinent_Child { get; }

        /// <summary>
        /// Gets the E05 SubContinent ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="E05_SubContinent_ReChildDto"/>.</value>
        List<E05_SubContinent_ReChildDto> E05_SubContinent_ReChild { get; }

        /// <summary>
        /// Gets the E05 Country Objects.
        /// </summary>
        /// <value>A list of <see cref="E06_CountryDto"/>.</value>
        List<E06_CountryDto> E05_CountryColl { get; }

        /// <summary>
        /// Gets the E07 Country Single Object.
        /// </summary>
        /// <value>A list of <see cref="E07_Country_ChildDto"/>.</value>
        List<E07_Country_ChildDto> E07_Country_Child { get; }

        /// <summary>
        /// Gets the E07 Country ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="E07_Country_ReChildDto"/>.</value>
        List<E07_Country_ReChildDto> E07_Country_ReChild { get; }

        /// <summary>
        /// Gets the E07 Region Objects.
        /// </summary>
        /// <value>A list of <see cref="E08_RegionDto"/>.</value>
        List<E08_RegionDto> E07_RegionColl { get; }

        /// <summary>
        /// Gets the E09 Region Single Object.
        /// </summary>
        /// <value>A list of <see cref="E09_Region_ChildDto"/>.</value>
        List<E09_Region_ChildDto> E09_Region_Child { get; }

        /// <summary>
        /// Gets the E09 Region ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="E09_Region_ReChildDto"/>.</value>
        List<E09_Region_ReChildDto> E09_Region_ReChild { get; }

        /// <summary>
        /// Gets the E09 City Objects.
        /// </summary>
        /// <value>A list of <see cref="E10_CityDto"/>.</value>
        List<E10_CityDto> E09_CityColl { get; }

        /// <summary>
        /// Gets the E11 City Single Object.
        /// </summary>
        /// <value>A list of <see cref="E11_City_ChildDto"/>.</value>
        List<E11_City_ChildDto> E11_City_Child { get; }

        /// <summary>
        /// Gets the E11 City ASingle Object.
        /// </summary>
        /// <value>A list of <see cref="E11_City_ReChildDto"/>.</value>
        List<E11_City_ReChildDto> E11_City_ReChild { get; }

        /// <summary>
        /// Gets the E11 CityRoad Objects.
        /// </summary>
        /// <value>A list of <see cref="E12_CityRoadDto"/>.</value>
        List<E12_CityRoadDto> E11_CityRoadColl { get; }

        /// <summary>
        /// Loads a E02_Continent object from the database.
        /// </summary>
        /// <param name="continent_ID">The fetch criteria.</param>
        /// <returns>A <see cref="E02_ContinentDto"/> object.</returns>
        E02_ContinentDto Fetch(int continent_ID);

        /// <summary>
        /// Inserts a new E02_Continent object in the database.
        /// </summary>
        /// <param name="e02_Continent">The E02 Continent DTO.</param>
        /// <returns>The new <see cref="E02_ContinentDto"/>.</returns>
        E02_ContinentDto Insert(E02_ContinentDto e02_Continent);

        /// <summary>
        /// Updates in the database all changes made to the E02_Continent object.
        /// </summary>
        /// <param name="e02_Continent">The E02 Continent DTO.</param>
        /// <returns>The updated <see cref="E02_ContinentDto"/>.</returns>
        E02_ContinentDto Update(E02_ContinentDto e02_Continent);

        /// <summary>
        /// Deletes the E02_Continent object from database.
        /// </summary>
        /// <param name="continent_ID">The delete criteria.</param>
        void Delete(int continent_ID);
    }
}
