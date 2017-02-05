/****** Object:  StoredProcedure [AddDocClassEditDyna] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddDocClassEditDyna]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddDocClassEditDyna]
GO

CREATE PROCEDURE [AddDocClassEditDyna]
    @DocClassID int OUTPUT,
    @DocClassName varchar(20),
    @CreateDate datetime2,
    @CreateUserID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into DocClasses */
        INSERT INTO [DocClasses]
        (
            [DocClassName],
            [CreateDate],
            [CreateUserID],
            [ChangeDate],
            [ChangeUserID]
        )
        VALUES
        (
            @DocClassName,
            @CreateDate,
            @CreateUserID,
            @ChangeDate,
            @ChangeUserID
        )

        /* Return new primary key */
        SET @DocClassID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [DocClasses]
        WHERE
            [DocClassID] = @DocClassID

    END
GO

/****** Object:  StoredProcedure [UpdateDocClassEditDyna] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDocClassEditDyna]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateDocClassEditDyna]
GO

CREATE PROCEDURE [UpdateDocClassEditDyna]
    @DocClassID int,
    @DocClassName varchar(20),
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
            SELECT [DocClassID] FROM [DocClasses]
            WHERE
                [DocClassID] = @DocClassID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''DocClassEditDyna'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [DocClassID] FROM [DocClasses]
            WHERE
                [DocClassID] = @DocClassID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''DocClassEditDyna'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in DocClasses */
        UPDATE [DocClasses]
        SET
            [DocClassName] = @DocClassName,
            [ChangeDate] = @ChangeDate,
            [ChangeUserID] = @ChangeUserID
        WHERE
            [DocClassID] = @DocClassID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [DocClasses]
        WHERE
            [DocClassID] = @DocClassID

    END
GO

/****** Object:  StoredProcedure [DeleteDocClassEditDyna] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteDocClassEditDyna]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteDocClassEditDyna]
GO

CREATE PROCEDURE [DeleteDocClassEditDyna]
    @DocClassID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [DocClassID] FROM [DocClasses]
            WHERE
                [DocClassID] = @DocClassID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''DocClassEditDyna'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark DocClassEditDyna object as not active */
        UPDATE [DocClasses]
        SET    [IsActive] = 'false'
        WHERE
            [DocClasses].[DocClassID] = @DocClassID

    END
GO
