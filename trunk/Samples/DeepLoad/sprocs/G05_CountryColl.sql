/****** Object:  StoredProcedure [GetG05_CountryColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG05_CountryColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG05_CountryColl]
GO

CREATE PROCEDURE [GetG05_CountryColl]
    @Parent_SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G06_Country from table */
        SELECT
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name],
            [3_Countries].[Parent_SubContinent_ID],
            [3_Countries].[RowVersion]
        FROM [3_Countries]
        WHERE
            [3_Countries].[Parent_SubContinent_ID] = @Parent_SubContinent_ID AND
            [3_Countries].[IsActive] = 'true'

    END
GO

