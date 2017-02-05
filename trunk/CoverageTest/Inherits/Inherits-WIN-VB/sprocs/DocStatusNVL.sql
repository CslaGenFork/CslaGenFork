/****** Object:  StoredProcedure [GetDocStatusNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocStatusNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocStatusNVL]
GO

CREATE PROCEDURE [GetDocStatusNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocStatusNVL from table */
        SELECT
            [DocStatus].[DocStatusID],
            [DocStatus].[DocStatusName]
        FROM [DocStatus]
        WHERE
            [DocStatus].[IsActive] = 'true'

    END
GO

