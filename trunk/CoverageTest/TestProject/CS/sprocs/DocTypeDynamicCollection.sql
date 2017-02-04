/****** Object:  StoredProcedure [GetDocTypeDynamicCollection] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocTypeDynamicCollection]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocTypeDynamicCollection]
GO

CREATE PROCEDURE [GetDocTypeDynamicCollection]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocTypeDynamic from table */
        SELECT
            [DocTypes].[DocTypeID],
            [DocTypes].[DocTypeName]
        FROM [DocTypes]
        WHERE
            [DocTypes].[IsActive] = 'true'

    END
GO

