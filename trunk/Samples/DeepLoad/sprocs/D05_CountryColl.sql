/****** Object:  StoredProcedure [GetD05_CountryColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD05_CountryColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD05_CountryColl]
GO

CREATE PROCEDURE [GetD05_CountryColl]
    @Parent_SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D06_Country from table */
        SELECT
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name]
        FROM [3_Countries]
        WHERE
            [3_Countries].[Parent_SubContinent_ID] = @Parent_SubContinent_ID

    END
GO

