/****** Object:  StoredProcedure [GetD01_ContinentColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD01_ContinentColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD01_ContinentColl]
GO

CREATE PROCEDURE [GetD01_ContinentColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D02_Continent from table */
        SELECT
            [1_Continents].[Continent_ID],
            [1_Continents].[Continent_Name]
        FROM [1_Continents]

    END
GO

