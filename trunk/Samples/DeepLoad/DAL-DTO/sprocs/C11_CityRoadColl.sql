/****** Object:  StoredProcedure [GetC11_CityRoadColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC11_CityRoadColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC11_CityRoadColl]
GO

CREATE PROCEDURE [GetC11_CityRoadColl]
    @Parent_City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C12_CityRoad from table */
        SELECT
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[Parent_City_ID] = @Parent_City_ID

    END
GO

