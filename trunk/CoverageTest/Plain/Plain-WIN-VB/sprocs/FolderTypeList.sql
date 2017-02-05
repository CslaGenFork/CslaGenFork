/****** Object:  StoredProcedure [GetFolderTypeList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetFolderTypeList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetFolderTypeList]
GO

CREATE PROCEDURE [GetFolderTypeList]
    @FolderTypeName varchar(255) = NULL
AS
    BEGIN

        SET NOCOUNT ON

        /* Search Variables */
        IF (@FolderTypeName <> '')
            SET @FolderTypeName = @FolderTypeName + '%'
        ELSE
            SET @FolderTypeName = '%'

        /* Get FolderTypeInfo from table */
        SELECT
            [FolderTypes].[FolderTypeID],
            [FolderTypes].[FolderTypeName],
            [FolderTypes].[IsActive]
        FROM [FolderTypes]
        WHERE
            ISNULL([FolderTypes].[FolderTypeName], '') LIKE @FolderTypeName

    END
GO

