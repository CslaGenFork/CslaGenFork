/****** Object:  StoredProcedure [GetC05_CountryColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC05_CountryColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC05_CountryColl]
GO

CREATE PROCEDURE [GetC05_CountryColl]
    @Parent_SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C06_Country from table */
        SELECT
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name],
            [3_Countries].[Parent_SubContinent_ID],
            [3_Countries].[RowVersion]
        FROM [3_Countries]
        WHERE
            [3_Countries].[Parent_SubContinent_ID] = @Parent_SubContinent_ID

    END
GO

