/****** Object:  StoredProcedure [AddDocStatus] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddDocStatus]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddDocStatus]
GO

CREATE PROCEDURE [AddDocStatus]
    @DocStatusID int OUTPUT,
    @DocStatusName varchar(25),
    @CreateDate datetime2,
    @CreateUserID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into DocStatus */
        INSERT INTO [DocStatus]
        (
            [DocStatusName],
            [CreateDate],
            [CreateUserID],
            [ChangeDate],
            [ChangeUserID]
        )
        VALUES
        (
            @DocStatusName,
            @CreateDate,
            @CreateUserID,
            @ChangeDate,
            @ChangeUserID
        )

        /* Return new primary key */
        SET @DocStatusID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [DocStatus]
        WHERE
            [DocStatusID] = @DocStatusID

    END
GO

/****** Object:  StoredProcedure [UpdateDocStatus] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDocStatus]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateDocStatus]
GO

CREATE PROCEDURE [UpdateDocStatus]
    @DocStatusID int,
    @DocStatusName varchar(25),
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
            SELECT [DocStatusID] FROM [DocStatus]
            WHERE
                [DocStatusID] = @DocStatusID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''DocStatus'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [DocStatusID] FROM [DocStatus]
            WHERE
                [DocStatusID] = @DocStatusID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''DocStatus'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in DocStatus */
        UPDATE [DocStatus]
        SET
            [DocStatusName] = @DocStatusName,
            [ChangeDate] = @ChangeDate,
            [ChangeUserID] = @ChangeUserID
        WHERE
            [DocStatusID] = @DocStatusID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [DocStatus]
        WHERE
            [DocStatusID] = @DocStatusID

    END
GO

/****** Object:  StoredProcedure [DeleteDocStatus] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteDocStatus]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteDocStatus]
GO

CREATE PROCEDURE [DeleteDocStatus]
    @DocStatusID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [DocStatusID] FROM [DocStatus]
            WHERE
                [DocStatusID] = @DocStatusID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''DocStatus'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark DocStatus object as not active */
        UPDATE [DocStatus]
        SET    [IsActive] = 'false'
        WHERE
            [DocStatus].[DocStatusID] = @DocStatusID

    END
GO
