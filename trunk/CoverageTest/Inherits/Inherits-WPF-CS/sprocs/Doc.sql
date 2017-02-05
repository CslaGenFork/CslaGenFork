/****** Object:  StoredProcedure [GetDoc] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDoc]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDoc]
GO

CREATE PROCEDURE [GetDoc]
    @DocID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get Doc from table */
        SELECT
            [Docs].[DocID],
            [Docs].[DocClassID],
            [Docs].[DocTypeID],
            [Docs].[SenderEntityID] AS [SenderID],
            [Docs].[RecipientEntityID] AS [RecipientID],
            [Docs].[DocRef],
            [Docs].[DocDate],
            [Docs].[Subject],
            [Docs].[DocStatusID],
            [Docs].[CreateDate],
            [Docs].[CreateUserID],
            [Docs].[ChangeDate],
            [Docs].[ChangeUserID],
            [Docs].[RowVersion],
            [Docs].[Secret]
        FROM [Docs]
        WHERE
            [Docs].[DocID] = @DocID

        /* Get DocContent from table */
        SELECT
            [DocContents].[DocContentID],
            [DocContents].[Version],
            [DocContents].[FileSize],
            [DocContents].[FileType],
            [DocContents].[CheckInDate],
            [DocContents].[CheckInUserID],
            [DocContents].[CheckInComment],
            [DocContents].[CheckOutDate],
            [DocContents].[CheckOutUserID],
            [DocContents].[RowVersion]
        FROM [DocContents]
            INNER JOIN [Docs] ON [DocContents].[DocID] = [Docs].[DocID]
        WHERE
            [Docs].[DocID] = @DocID AND
            [DocContents].[IsActive] = 'true'

        /* Get DocFolder from table */
        SELECT
            [DocsFolders].[FolderID],
            [Folders].[FolderRef],
            [Folders].[Year],
            [Folders].[Subject],
            [DocsFolders].[CreateDate],
            [DocsFolders].[CreateUserID],
            [DocsFolders].[ChangeDate],
            [DocsFolders].[ChangeUserID],
            [DocsFolders].[RowVersion]
        FROM [DocsFolders]
            INNER JOIN [Docs] ON [DocsFolders].[DocID] = [Docs].[DocID]
            INNER JOIN [Folders] ON [DocsFolders].[FolderID] = [Folders].[FolderID]
        WHERE
            [Docs].[DocID] = @DocID AND
            [DocsFolders].[IsActive] = 'true'

        /* Get DocCirc from table */
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
            INNER JOIN [Docs] ON [Circ].[DocID] = [Docs].[DocID]
        WHERE
            [Docs].[DocID] = @DocID AND
            [Circ].[IsActive] = 'true'

        /* Get DocContentRO from table */
        SELECT
            [DocContents].[DocContentID],
            [DocContents].[Version],
            [DocContents].[FileSize],
            [DocContents].[FileType],
            [DocContents].[CheckInDate],
            [DocContents].[CheckInUserID],
            [DocContents].[CheckInComment],
            [DocContents].[CheckOutDate],
            [DocContents].[CheckOutUserID]
        FROM [DocContents]
            INNER JOIN [Docs] ON [DocContents].[DocID] = [Docs].[DocID]
        WHERE
            [Docs].[DocID] = @DocID AND
            [DocContents].[IsActive] = 'true'

        /* Get DocContentInfo from table */
        SELECT
            [DocContents].[DocContentID],
            [DocContents].[DocContentOrder],
            [DocContents].[Version],
            [DocContents].[FileSize],
            [DocContents].[FileType],
            [DocContents].[CheckInDate],
            [DocContents].[CheckInUserID],
            [DocContents].[CheckInComment],
            [DocContents].[CheckOutDate],
            [DocContents].[CheckOutUserID]
        FROM [DocContents]
            INNER JOIN [Docs] ON [DocContents].[DocID] = [Docs].[DocID]
        WHERE
            [Docs].[DocID] = @DocID AND
            [DocContents].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddDoc] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddDoc]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddDoc]
GO

CREATE PROCEDURE [AddDoc]
    @DocID int OUTPUT,
    @DocClassID int,
    @DocTypeID int,
    @SenderID int,
    @RecipientID int,
    @DocRef varchar(40),
    @DocDate date,
    @Subject varchar(255),
    @DocStatusID int,
    @CreateDate datetime2,
    @CreateUserID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @Secret varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Docs */
        INSERT INTO [Docs]
        (
            [DocClassID],
            [DocTypeID],
            [SenderEntityID],
            [RecipientEntityID],
            [DocRef],
            [DocDate],
            [Subject],
            [DocStatusID],
            [CreateDate],
            [CreateUserID],
            [ChangeDate],
            [ChangeUserID],
            [Secret]
        )
        VALUES
        (
            @DocClassID,
            @DocTypeID,
            @SenderID,
            @RecipientID,
            @DocRef,
            @DocDate,
            @Subject,
            @DocStatusID,
            @CreateDate,
            @CreateUserID,
            @ChangeDate,
            @ChangeUserID,
            @Secret
        )

        /* Return new primary key */
        SET @DocID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Docs]
        WHERE
            [DocID] = @DocID

    END
GO

/****** Object:  StoredProcedure [UpdateDoc] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDoc]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateDoc]
GO

CREATE PROCEDURE [UpdateDoc]
    @DocID int,
    @DocClassID int,
    @DocTypeID int,
    @SenderID int,
    @RecipientID int,
    @DocRef varchar(40),
    @DocDate date,
    @Subject varchar(255),
    @DocStatusID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT,
    @Secret varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [DocID] FROM [Docs]
            WHERE
                [DocID] = @DocID
        )
        BEGIN
            RAISERROR ('''Doc'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [DocID] FROM [Docs]
            WHERE
                [DocID] = @DocID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''Doc'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in Docs */
        UPDATE [Docs]
        SET
            [DocClassID] = @DocClassID,
            [DocTypeID] = @DocTypeID,
            [SenderEntityID] = @SenderID,
            [RecipientEntityID] = @RecipientID,
            [DocRef] = @DocRef,
            [DocDate] = @DocDate,
            [Subject] = @Subject,
            [DocStatusID] = @DocStatusID,
            [ChangeDate] = @ChangeDate,
            [ChangeUserID] = @ChangeUserID,
            [Secret] = @Secret
        WHERE
            [DocID] = @DocID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Docs]
        WHERE
            [DocID] = @DocID AND
            [Secret] = @Secret

    END
GO

