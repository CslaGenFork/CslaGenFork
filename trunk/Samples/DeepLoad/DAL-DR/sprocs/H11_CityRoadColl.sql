/****** Object:  StoredProcedure [GetH11_CityRoadColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH11_CityRoadColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH11_CityRoadColl]
GO

CREATE PROCEDURE [GetH11_CityRoadColl]
    @Parent_City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H12_CityRoad from table */
        SELECT
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[Parent_City_ID] = @Parent_City_ID AND
            [6_CityRoads].[IsActive] = 'true'

    END
GO

