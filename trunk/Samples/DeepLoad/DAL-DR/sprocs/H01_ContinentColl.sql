/****** Object:  StoredProcedure [GetH01_ContinentColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH01_ContinentColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH01_ContinentColl]
GO

CREATE PROCEDURE [GetH01_ContinentColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H02_Continent from table */
        SELECT
            [1_Continents].[Continent_ID],
            [1_Continents].[Continent_Name]
        FROM [1_Continents]
        WHERE
            [1_Continents].[IsActive] = 'true'

    END
GO

