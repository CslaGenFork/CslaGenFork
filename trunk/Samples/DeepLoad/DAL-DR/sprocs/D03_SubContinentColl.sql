/****** Object:  StoredProcedure [GetD03_SubContinentColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD03_SubContinentColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD03_SubContinentColl]
GO

CREATE PROCEDURE [GetD03_SubContinentColl]
    @Parent_Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D04_SubContinent from table */
        SELECT
            [2_SubContinents].[SubContinent_ID],
            [2_SubContinents].[SubContinent_Name]
        FROM [2_SubContinents]
        WHERE
            [2_SubContinents].[Parent_Continent_ID] = @Parent_Continent_ID

    END
GO

