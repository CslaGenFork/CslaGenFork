/****** Object:  StoredProcedure [GetF01_ContinentColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetF01_ContinentColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetF01_ContinentColl]
GO

CREATE PROCEDURE [GetF01_ContinentColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get F02_Continent from table */
        SELECT
            [1_Continents].[Continent_ID],
            [1_Continents].[Continent_Name]
        FROM [1_Continents]
        WHERE
            [1_Continents].[IsActive] = 'true'

        /* Get F03_Continent_Child from table */
        SELECT
            [1_Continents_Child].[Continent_ID1],
            [1_Continents_Child].[Continent_Child_Name]
        FROM [1_Continents_Child]
        WHERE
            [1_Continents_Child].[IsActive] = 'true'

        /* Get F03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_ID2],
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[IsActive] = 'true'

        /* Get F04_SubContinent from table */
        SELECT
            [2_SubContinents].[Parent_Continent_ID],
            [2_SubContinents].[SubContinent_ID],
            [2_SubContinents].[SubContinent_Name]
        FROM [2_SubContinents]
        WHERE
            [2_SubContinents].[IsActive] = 'true'

        /* Get F05_SubContinent_Child from table */
        SELECT
            [2_SubContinents_Child].[SubContinent_ID1],
            [2_SubContinents_Child].[SubContinent_Child_Name]
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[IsActive] = 'true'

        /* Get F05_SubContinent_ReChild from table */
        SELECT
            [2_SubContinents_ReChild].[SubContinent_ID2],
            [2_SubContinents_ReChild].[SubContinent_Child_Name]
        FROM [2_SubContinents_ReChild]
        WHERE
            [2_SubContinents_ReChild].[IsActive] = 'true'

        /* Get F06_Country from table */
        SELECT
            [3_Countries].[Parent_SubContinent_ID],
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name]
        FROM [3_Countries]
        WHERE
            [3_Countries].[IsActive] = 'true'

        /* Get F07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_ID1],
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[IsActive] = 'true'

        /* Get F07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_ID2],
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[IsActive] = 'true'

        /* Get F08_Region from table */
        SELECT
            [4_Regions].[Parent_Country_ID],
            [4_Regions].[Region_ID],
            [4_Regions].[Region_Name]
        FROM [4_Regions]
        WHERE
            [4_Regions].[IsActive] = 'true'

        /* Get F09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_ID1],
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[IsActive] = 'true'

        /* Get F09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_ID2],
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[IsActive] = 'true'

        /* Get F10_City from table */
        SELECT
            [5_Cities].[Parent_Region_ID],
            [5_Cities].[City_ID],
            [5_Cities].[City_Name]
        FROM [5_Cities]
        WHERE
            [5_Cities].[IsActive] = 'true'

        /* Get F11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_ID1],
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[IsActive] = 'true'

        /* Get F11_City_ReChild from table */
        SELECT
            [5_Cities_ReChild].[City_ID2],
            [5_Cities_ReChild].[City_Child_Name]
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[IsActive] = 'true'

        /* Get F12_CityRoad from table */
        SELECT
            [6_CityRoads].[Parent_City_ID],
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[IsActive] = 'true'

    END
GO

