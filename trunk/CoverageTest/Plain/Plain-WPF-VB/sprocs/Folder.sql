/****** Object:  StoredProcedure [GetFolder] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetFolder]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetFolder]
GO

CREATE PROCEDURE [GetFolder]
    @FolderID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get Folder from table */
        SELECT
            [Folders].[FolderID],
            [Folders].[FolderTypeID],
            [Folders].[FolderRef],
            [Folders].[Year],
            [Folders].[Subject],
            [Folders].[FolderStatusID],
            [Folders].[CreateDate],
            [Folders].[CreateUserID],
            [Folders].[ChangeDate],
            [Folders].[ChangeUserID],
            [Folders].[RowVersion]
        FROM [Folders]
        WHERE
            [Folders].[FolderID] = @FolderID AND
            [Folders].[IsActive] = 'true'

        /* Get FolderCirc from table */
        SELECT
            [Circ].[CircID],
            [Circ].[NeedsReply],
            [Circ].[NeedsReplyDecision],
            [Circ].[CircTypeTag],
            [Circ].[Notes],
            [Circ].[TagNotesCert],
            [Circ].[SenderEntityID],
            [Circ].[SentDateTime],
            [Circ].[DaysToReply],
            [Circ].[DaysToLive],
            [Circ].[CreateDate],
            [Circ].[CreateUserID],
            [Circ].[ChangeDate],
            [Circ].[ChangeUserID],
            [Circ].[RowVersion]
        FROM [Circ]
            INNER JOIN [Folders] ON [Circ].[FolderID] = [Folders].[FolderID]
        WHERE
            [Folders].[FolderID] = @FolderID AND
            [Circ].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddFolder] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddFolder]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddFolder]
GO

CREATE PROCEDURE [AddFolder]
    @FolderID int OUTPUT,
    @FolderTypeID int,
    @FolderRef varchar(25),
    @Year int,
    @Subject varchar(255),
    @FolderStatusID int,
    @CreateDate datetime2,
    @CreateUserID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Folders */
        INSERT INTO [Folders]
        (
            [FolderTypeID],
            [FolderRef],
            [Year],
            [Subject],
            [FolderStatusID],
            [CreateDate],
            [CreateUserID],
            [ChangeDate],
            [ChangeUserID]
        )
        VALUES
        (
            @FolderTypeID,
            @FolderRef,
            @Year,
            @Subject,
            @FolderStatusID,
            @CreateDate,
            @CreateUserID,
            @ChangeDate,
            @ChangeUserID
        )

        /* Return new primary key */
        SET @FolderID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Folders]
        WHERE
            [FolderID] = @FolderID

    END
GO

/****** Object:  StoredProcedure [UpdateFolder] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateFolder]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateFolder]
GO

CREATE PROCEDURE [UpdateFolder]
    @FolderID int,
    @FolderTypeID int,
    @FolderRef varchar(25),
    @Year int,
    @Subject varchar(255),
    @FolderStatusID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [FolderID] FROM [Folders]
            WHERE
                [FolderID] = @FolderID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''Folder'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [FolderID] FROM [Folders]
            WHERE
                [FolderID] = @FolderID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''Folder'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in Folders */
        UPDATE [Folders]
        SET
            [FolderTypeID] = @FolderTypeID,
            [FolderRef] = @FolderRef,
            [Year] = @Year,
            [Subject] = @Subject,
            [FolderStatusID] = @FolderStatusID,
            [ChangeDate] = @ChangeDate,
            [ChangeUserID] = @ChangeUserID
        WHERE
            [FolderID] = @FolderID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Folders]
        WHERE
            [FolderID] = @FolderID

    END
GO

/****** Object:  StoredProcedure [DeleteFolder] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteFolder]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteFolder]
GO

CREATE PROCEDURE [DeleteFolder]
    @FolderID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [FolderID] FROM [Folders]
            WHERE
                [FolderID] = @FolderID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''Folder'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child FolderCirc as not active */
        UPDATE [Circ]
        SET    [IsActive] = 'false'
        FROM [Circ]
            INNER JOIN [Folders] ON [Circ].[FolderID] = [Folders].[FolderID]
        WHERE
            [Folders].[FolderID] = @FolderID

        /* Mark child FolderDoc as not active */
        UPDATE [DocsFolders]
        SET    [IsActive] = 'false'
        FROM [DocsFolders]
            INNER JOIN [Folders] ON [DocsFolders].[FolderID] = [Folders].[FolderID]
        WHERE
            [Folders].[FolderID] = @FolderID

        /* Mark Folder object as not active */
        UPDATE [Folders]
        SET    [IsActive] = 'false'
        WHERE
            [Folders].[FolderID] = @FolderID

    END
GO
