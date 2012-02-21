/****** Object:  StoredProcedure [GetC09_CityColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC09_CityColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC09_CityColl]
GO

CREATE PROCEDURE [GetC09_CityColl]
    @Parent_Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C10_City from table */
        SELECT
            [5_Cities].[City_ID],
            [5_Cities].[City_Name]
        FROM [5_Cities]
        WHERE
            [5_Cities].[Parent_Region_ID] = @Parent_Region_ID

    END
GO

