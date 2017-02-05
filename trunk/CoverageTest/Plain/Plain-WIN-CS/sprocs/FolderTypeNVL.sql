/****** Object:  StoredProcedure [GetFolderTypeNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetFolderTypeNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetFolderTypeNVL]
GO

CREATE PROCEDURE [GetFolderTypeNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get FolderTypeNVL from table */
        SELECT
            [FolderTypes].[FolderTypeID],
            [FolderTypes].[FolderTypeName]
        FROM [FolderTypes]
        WHERE
            [FolderTypes].[IsActive] = 'true'

    END
GO

