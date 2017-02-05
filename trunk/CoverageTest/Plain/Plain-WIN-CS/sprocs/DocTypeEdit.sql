/****** Object:  StoredProcedure [AddDocTypeEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddDocTypeEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddDocTypeEdit]
GO

CREATE PROCEDURE [AddDocTypeEdit]
    @DocTypeID int OUTPUT,
    @DocTypeName varchar(255),
    @CreateDate datetime2,
    @CreateUserID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into DocTypes */
        INSERT INTO [DocTypes]
        (
            [DocTypeName],
            [CreateDate],
            [CreateUserID],
            [ChangeDate],
            [ChangeUserID]
        )
        VALUES
        (
            @DocTypeName,
            @CreateDate,
            @CreateUserID,
            @ChangeDate,
            @ChangeUserID
        )

        /* Return new primary key */
        SET @DocTypeID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [DocTypes]
        WHERE
            [DocTypeID] = @DocTypeID

    END
GO

/****** Object:  StoredProcedure [UpdateDocTypeEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDocTypeEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateDocTypeEdit]
GO

CREATE PROCEDURE [UpdateDocTypeEdit]
    @DocTypeID int,
    @DocTypeName varchar(255),
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
            SELECT [DocTypeID] FROM [DocTypes]
            WHERE
                [DocTypeID] = @DocTypeID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''DocTypeEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [DocTypeID] FROM [DocTypes]
            WHERE
                [DocTypeID] = @DocTypeID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''DocTypeEdit'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in DocTypes */
        UPDATE [DocTypes]
        SET
            [DocTypeName] = @DocTypeName,
            [ChangeDate] = @ChangeDate,
            [ChangeUserID] = @ChangeUserID
        WHERE
            [DocTypeID] = @DocTypeID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [DocTypes]
        WHERE
            [DocTypeID] = @DocTypeID

    END
GO

/****** Object:  StoredProcedure [DeleteDocTypeEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteDocTypeEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteDocTypeEdit]
GO

CREATE PROCEDURE [DeleteDocTypeEdit]
    @DocTypeID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [DocTypeID] FROM [DocTypes]
            WHERE
                [DocTypeID] = @DocTypeID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''DocTypeEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark DocTypeEdit object as not active */
        UPDATE [DocTypes]
        SET    [IsActive] = 'false'
        WHERE
            [DocTypes].[DocTypeID] = @DocTypeID

    END
GO
