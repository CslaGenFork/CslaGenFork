/****** Object:  StoredProcedure [GetDocTypeEditColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocTypeEditColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocTypeEditColl]
GO

CREATE PROCEDURE [GetDocTypeEditColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocTypeEdit from table */
        SELECT
            [DocTypes].[DocTypeID],
            [DocTypes].[DocTypeName]
        FROM [DocTypes]
        WHERE
            [DocTypes].[IsActive] = 'true'

    END
GO

