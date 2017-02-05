/****** Object:  StoredProcedure [GetDocType] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocType]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocType]
GO

CREATE PROCEDURE [GetDocType]
    @DocTypeID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocType from table */
        SELECT
            [DocTypes].[DocTypeID],
            [DocTypes].[DocTypeName],
            [DocTypes].[CreateDate],
            [DocTypes].[CreateUserID],
            [DocTypes].[ChangeDate],
            [DocTypes].[ChangeUserID],
            [DocTypes].[RowVersion]
        FROM [DocTypes]
        WHERE
            [DocTypes].[DocTypeID] = @DocTypeID AND
            [DocTypes].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddDocType] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddDocType]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddDocType]
GO

CREATE PROCEDURE [AddDocType]
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

/****** Object:  StoredProcedure [UpdateDocType] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDocType]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateDocType]
GO

CREATE PROCEDURE [UpdateDocType]
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
            RAISERROR ('''DocType'' object not found. It was probably removed by another user.', 16, 1)
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
            RAISERROR ('''DocType'' object was modified by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteDocType] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteDocType]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteDocType]
GO

CREATE PROCEDURE [DeleteDocType]
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
            RAISERROR ('''DocType'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark DocType object as not active */
        UPDATE [DocTypes]
        SET    [IsActive] = 'false'
        WHERE
            [DocTypes].[DocTypeID] = @DocTypeID

    END
GO
