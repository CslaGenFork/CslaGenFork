/****** Object:  StoredProcedure [GetDocTypeList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocTypeList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocTypeList]
GO

CREATE PROCEDURE [GetDocTypeList]
    @DocTypeName varchar(255) = NULL
AS
    BEGIN

        SET NOCOUNT ON

        /* Search Variables */
        IF (@DocTypeName <> '')
            SET @DocTypeName = @DocTypeName + '%'
        ELSE
            SET @DocTypeName = '%'

        /* Get DocTypeInfo from table */
        SELECT
            [DocTypes].[DocTypeID],
            [DocTypes].[DocTypeName],
            [DocTypes].[IsActive]
        FROM [DocTypes]
        WHERE
            ISNULL([DocTypes].[DocTypeName], '') LIKE @DocTypeName

    END
GO

