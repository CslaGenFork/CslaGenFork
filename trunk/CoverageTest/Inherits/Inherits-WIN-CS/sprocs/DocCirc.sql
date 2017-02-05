/****** Object:  StoredProcedure [AddDocCirc] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddDocCirc]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddDocCirc]
GO

CREATE PROCEDURE [AddDocCirc]
    @CircID int OUTPUT,
    @DocID int,
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
            [DocID],
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
            @DocID,
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

/****** Object:  StoredProcedure [UpdateDocCirc] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDocCirc]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateDocCirc]
GO

CREATE PROCEDURE [UpdateDocCirc]
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
            RAISERROR ('''DocCirc'' object not found. It was probably removed by another user.', 16, 1)
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
            RAISERROR ('''DocCirc'' object was modified by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteDocCirc] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteDocCirc]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteDocCirc]
GO

CREATE PROCEDURE [DeleteDocCirc]
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
            RAISERROR ('''DocCirc'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark DocCirc object as not active */
        UPDATE [Circ]
        SET    [IsActive] = 'false'
        WHERE
            [Circ].[CircID] = @CircID

    END
GO
