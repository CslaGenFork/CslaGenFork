/****** Object:  StoredProcedure [GetFolderStatusNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetFolderStatusNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetFolderStatusNVL]
GO

CREATE PROCEDURE [GetFolderStatusNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get FolderStatusNVL from table */
        SELECT
            [FolderStatus].[FolderStatusID],
            [FolderStatus].[FolderStatusName]
        FROM [FolderStatus]
        WHERE
            [FolderStatus].[IsActive] = 'true'

    END
GO

