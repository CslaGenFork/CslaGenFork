/****** Object:  StoredProcedure [GetB01_ContinentColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetB01_ContinentColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetB01_ContinentColl]
GO

CREATE PROCEDURE [GetB01_ContinentColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get B02_Continent from table */
        SELECT
            [1_Continents].[Continent_ID],
            [1_Continents].[Continent_Name]
        FROM [1_Continents]

        /* Get B03_Continent_Child from table */
        SELECT
            [1_Continents_Child].[Continent_ID1],
            [1_Continents_Child].[Continent_Child_Name]
        FROM [1_Continents_Child]

        /* Get B03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_ID2],
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]

        /* Get B04_SubContinent from table */
        SELECT
            [2_SubContinents].[Parent_Continent_ID],
            [2_SubContinents].[SubContinent_ID],
            [2_SubContinents].[SubContinent_Name]
        FROM [2_SubContinents]

        /* Get B05_SubContinent_Child from table */
        SELECT
            [2_SubContinents_Child].[SubContinent_ID1],
            [2_SubContinents_Child].[SubContinent_Child_Name]
        FROM [2_SubContinents_Child]

        /* Get B05_SubContinent_ReChild from table */
        SELECT
            [2_SubContinents_ReChild].[SubContinent_ID2],
            [2_SubContinents_ReChild].[SubContinent_Child_Name]
        FROM [2_SubContinents_ReChild]

        /* Get B06_Country from table */
        SELECT
            [3_Countries].[Parent_SubContinent_ID],
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name]
        FROM [3_Countries]

        /* Get B07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_ID1],
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]

        /* Get B07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_ID2],
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]

        /* Get B08_Region from table */
        SELECT
            [4_Regions].[Parent_Country_ID],
            [4_Regions].[Region_ID],
            [4_Regions].[Region_Name]
        FROM [4_Regions]

        /* Get B09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_ID1],
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]

        /* Get B09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_ID2],
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]

        /* Get B10_City from table */
        SELECT
            [5_Cities].[Parent_Region_ID],
            [5_Cities].[City_ID],
            [5_Cities].[City_Name]
        FROM [5_Cities]

        /* Get B11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_ID1],
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]

        /* Get B11_City_ReChild from table */
        SELECT
            [5_Cities_ReChild].[City_ID2],
            [5_Cities_ReChild].[City_Child_Name]
        FROM [5_Cities_ReChild]

        /* Get B12_CityRoad from table */
        SELECT
            [6_CityRoads].[Parent_City_ID],
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]

    END
GO

