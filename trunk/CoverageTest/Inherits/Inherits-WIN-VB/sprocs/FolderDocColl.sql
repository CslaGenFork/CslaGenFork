/****** Object:  StoredProcedure [GetFolderDocColl] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetFolderDocColl]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetFolderDocColl]
GO

CREATE PROCEDURE [GetFolderDocColl]
    @FolderID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get FolderDoc from table */
        SELECT
            [DocsFolders].[DocID],
            [Docs].[DocRef],
            [Docs].[DocDate],
            [Docs].[Subject],
            [DocsFolders].[CreateDate],
            [DocsFolders].[CreateUserID],
            [DocsFolders].[ChangeDate],
            [DocsFolders].[ChangeUserID],
            [DocsFolders].[RowVersion]
        FROM [DocsFolders]
            INNER JOIN [Docs] ON [DocsFolders].[DocID] = [Docs].[DocID]
        WHERE
            [DocsFolders].[FolderID] = @FolderID AND
            [DocsFolders].[IsActive] = 'true'

    END
GO

