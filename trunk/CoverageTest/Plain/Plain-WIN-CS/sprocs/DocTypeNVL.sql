/****** Object:  StoredProcedure [GetDocTypeNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocTypeNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocTypeNVL]
GO

CREATE PROCEDURE [GetDocTypeNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocTypeNVL from table */
        SELECT
            [DocTypes].[DocTypeID],
            [DocTypes].[DocTypeName]
        FROM [DocTypes]
        WHERE
            [DocTypes].[IsActive] = 'true'

    END
GO

