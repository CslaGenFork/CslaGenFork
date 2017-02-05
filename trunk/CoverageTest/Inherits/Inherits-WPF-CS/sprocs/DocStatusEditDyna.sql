/****** Object:  StoredProcedure [AddDocStatusEditDyna] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddDocStatusEditDyna]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddDocStatusEditDyna]
GO

CREATE PROCEDURE [AddDocStatusEditDyna]
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

/****** Object:  StoredProcedure [UpdateDocStatusEditDyna] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDocStatusEditDyna]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateDocStatusEditDyna]
GO

CREATE PROCEDURE [UpdateDocStatusEditDyna]
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
            RAISERROR ('''DocStatusEditDyna'' object not found. It was probably removed by another user.', 16, 1)
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
            RAISERROR ('''DocStatusEditDyna'' object was modified by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteDocStatusEditDyna] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteDocStatusEditDyna]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteDocStatusEditDyna]
GO

CREATE PROCEDURE [DeleteDocStatusEditDyna]
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
            RAISERROR ('''DocStatusEditDyna'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark DocStatusEditDyna object as not active */
        UPDATE [DocStatus]
        SET    [IsActive] = 'false'
        WHERE
            [DocStatus].[DocStatusID] = @DocStatusID

    END
GO
