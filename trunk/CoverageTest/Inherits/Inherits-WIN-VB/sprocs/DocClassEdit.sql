/****** Object:  StoredProcedure [AddDocClassEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddDocClassEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddDocClassEdit]
GO

CREATE PROCEDURE [AddDocClassEdit]
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

/****** Object:  StoredProcedure [UpdateDocClassEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDocClassEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateDocClassEdit]
GO

CREATE PROCEDURE [UpdateDocClassEdit]
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
            RAISERROR ('''DocClassEdit'' object not found. It was probably removed by another user.', 16, 1)
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
            RAISERROR ('''DocClassEdit'' object was modified by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteDocClassEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteDocClassEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteDocClassEdit]
GO

CREATE PROCEDURE [DeleteDocClassEdit]
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
            RAISERROR ('''DocClassEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark DocClassEdit object as not active */
        UPDATE [DocClasses]
        SET    [IsActive] = 'false'
        WHERE
            [DocClasses].[DocClassID] = @DocClassID

    END
GO
