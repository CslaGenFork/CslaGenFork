/****** Object:  StoredProcedure [GetDocClassNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocClassNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocClassNVL]
GO

CREATE PROCEDURE [GetDocClassNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocClassNVL from table */
        SELECT
            [DocClasses].[DocClassID],
            [DocClasses].[DocClassName]
        FROM [DocClasses]
        WHERE
            [DocClasses].[IsActive] = 'true'

    END
GO

