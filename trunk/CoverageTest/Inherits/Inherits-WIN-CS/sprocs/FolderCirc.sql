/****** Object:  StoredProcedure [AddFolderCirc] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddFolderCirc]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddFolderCirc]
GO

CREATE PROCEDURE [AddFolderCirc]
    @CircID int OUTPUT,
    @FolderID int,
    @NeedsReply bit,
    @NeedsReplyDecision bit,
    @CircTypeTag varchar(20),
    @Notes varchar(MAX),
    @TagNotesCert varchar(MAX),
    @SenderEntityID int,
    @SentDateTime datetime2,
    @DaysToReply smallint,
    @DaysToLive smallint,
    @CreateDate datetime2,
    @CreateUserID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Circ */
        INSERT INTO [Circ]
        (
            [FolderID],
            [NeedsReply],
            [NeedsReplyDecision],
            [CircTypeTag],
            [Notes],
            [TagNotesCert],
            [SenderEntityID],
            [SentDateTime],
            [DaysToReply],
            [DaysToLive],
            [CreateDate],
            [CreateUserID],
            [ChangeDate],
            [ChangeUserID]
        )
        VALUES
        (
            @FolderID,
            @NeedsReply,
            @NeedsReplyDecision,
            @CircTypeTag,
            @Notes,
            @TagNotesCert,
            @SenderEntityID,
            @SentDateTime,
            @DaysToReply,
            @DaysToLive,
            @CreateDate,
            @CreateUserID,
            @ChangeDate,
            @ChangeUserID
        )

        /* Return new primary key */
        SET @CircID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Circ]
        WHERE
            [CircID] = @CircID

    END
GO

/****** Object:  StoredProcedure [UpdateFolderCirc] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateFolderCirc]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateFolderCirc]
GO

CREATE PROCEDURE [UpdateFolderCirc]
    @CircID int,
    @NeedsReply bit,
    @NeedsReplyDecision bit,
    @CircTypeTag varchar(20),
    @Notes varchar(MAX),
    @TagNotesCert varchar(MAX),
    @SenderEntityID int,
    @SentDateTime datetime2,
    @DaysToReply smallint,
    @DaysToLive smallint,
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
            SELECT [CircID] FROM [Circ]
            WHERE
                [CircID] = @CircID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''FolderCirc'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [CircID] FROM [Circ]
            WHERE
                [CircID] = @CircID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''FolderCirc'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in Circ */
        UPDATE [Circ]
        SET
            [NeedsReply] = @NeedsReply,
            [NeedsReplyDecision] = @NeedsReplyDecision,
            [CircTypeTag] = @CircTypeTag,
            [Notes] = @Notes,
            [TagNotesCert] = @TagNotesCert,
            [SenderEntityID] = @SenderEntityID,
            [SentDateTime] = @SentDateTime,
            [DaysToReply] = @DaysToReply,
            [DaysToLive] = @DaysToLive,
            [ChangeDate] = @ChangeDate,
            [ChangeUserID] = @ChangeUserID
        WHERE
            [CircID] = @CircID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Circ]
        WHERE
            [CircID] = @CircID

    END
GO

/****** Object:  StoredProcedure [DeleteFolderCirc] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteFolderCirc]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteFolderCirc]
GO

CREATE PROCEDURE [DeleteFolderCirc]
    @CircID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CircID] FROM [Circ]
            WHERE
                [CircID] = @CircID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''FolderCirc'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark FolderCirc object as not active */
        UPDATE [Circ]
        SET    [IsActive] = 'false'
        WHERE
            [Circ].[CircID] = @CircID

    END
GO
