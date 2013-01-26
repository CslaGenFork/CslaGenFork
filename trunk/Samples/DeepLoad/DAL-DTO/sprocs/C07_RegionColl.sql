/****** Object:  StoredProcedure [GetC07_RegionColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC07_RegionColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC07_RegionColl]
GO

CREATE PROCEDURE [GetC07_RegionColl]
    @Parent_Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C08_Region from table */
        SELECT
            [4_Regions].[Region_ID],
            [4_Regions].[Region_Name]
        FROM [4_Regions]
        WHERE
            [4_Regions].[Parent_Country_ID] = @Parent_Country_ID

    END
GO

