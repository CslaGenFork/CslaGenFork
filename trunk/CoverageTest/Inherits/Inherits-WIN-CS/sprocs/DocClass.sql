/****** Object:  StoredProcedure [GetDocClass] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocClass]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocClass]
GO

CREATE PROCEDURE [GetDocClass]
    @DocClassID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocClass from table */
        SELECT
            [DocClasses].[DocClassID],
            [DocClasses].[DocClassName],
            [DocClasses].[CreateDate],
            [DocClasses].[CreateUserID],
            [DocClasses].[ChangeDate],
            [DocClasses].[ChangeUserID],
            [DocClasses].[RowVersion]
        FROM [DocClasses]
        WHERE
            [DocClasses].[DocClassID] = @DocClassID AND
            [DocClasses].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddDocClass] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddDocClass]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddDocClass]
GO

CREATE PROCEDURE [AddDocClass]
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

/****** Object:  StoredProcedure [UpdateDocClass] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDocClass]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateDocClass]
GO

CREATE PROCEDURE [UpdateDocClass]
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
            RAISERROR ('''DocClass'' object not found. It was probably removed by another user.', 16, 1)
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
            RAISERROR ('''DocClass'' object was modified by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteDocClass] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteDocClass]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteDocClass]
GO

CREATE PROCEDURE [DeleteDocClass]
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
            RAISERROR ('''DocClass'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark DocClass object as not active */
        UPDATE [DocClasses]
        SET    [IsActive] = 'false'
        WHERE
            [DocClasses].[DocClassID] = @DocClassID

    END
GO
