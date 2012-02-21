/****** Object:  StoredProcedure [GetG11_CityRoadColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG11_CityRoadColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG11_CityRoadColl]
GO

CREATE PROCEDURE [GetG11_CityRoadColl]
    @Parent_City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G12_CityRoad from table */
        SELECT
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[Parent_City_ID] = @Parent_City_ID AND
            [6_CityRoads].[IsActive] = 'true'

    END
GO

