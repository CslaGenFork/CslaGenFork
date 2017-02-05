/****** Object:  StoredProcedure [GetFolderList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetFolderList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetFolderList]
GO

CREATE PROCEDURE [GetFolderList]
    @FolderTypeID int = NULL,
    @FolderRef varchar(25) = NULL,
    @Year int = NULL,
    @Subject varchar(255) = NULL,
    @FolderStatusID int = NULL,
    @CreateDate datetime2 = NULL,
    @CreateUserID int = NULL,
    @ChangeDate datetime2 = NULL,
    @ChangeUserID int = NULL
AS
    BEGIN

        SET NOCOUNT ON

        /* Search Variables */
        IF (@FolderRef <> '')
            SET @FolderRef = @FolderRef + '%'
        ELSE
            SET @FolderRef = '%'
        IF (@Subject <> '')
            SET @Subject = @Subject + '%'
        ELSE
            SET @Subject = '%'

        /* Get FolderInfo from table */
        SELECT
            [Folders].[FolderID],
            [Folders].[FolderTypeID],
            [Folders].[FolderRef],
            [Folders].[Year],
            [Folders].[Subject],
            [Folders].[FolderStatusID]
        FROM [Folders]
        WHERE
            [Folders].[FolderTypeID] = ISNULL(@FolderTypeID, [Folders].[FolderTypeID]) AND
            ISNULL([Folders].[FolderRef], '') LIKE @FolderRef AND
            [Folders].[Year] = ISNULL(@Year, [Folders].[Year]) AND
            ISNULL([Folders].[Subject], '') LIKE @Subject AND
            [Folders].[FolderStatusID] = ISNULL(@FolderStatusID, [Folders].[FolderStatusID]) AND
            [Folders].[CreateDate] = ISNULL(@CreateDate, [Folders].[CreateDate]) AND
            [Folders].[CreateUserID] = ISNULL(@CreateUserID, [Folders].[CreateUserID]) AND
            [Folders].[ChangeDate] = ISNULL(@ChangeDate, [Folders].[ChangeDate]) AND
            [Folders].[ChangeUserID] = ISNULL(@ChangeUserID, [Folders].[ChangeUserID]) AND
            [Folders].[IsActive] = 'true'

    END
GO

