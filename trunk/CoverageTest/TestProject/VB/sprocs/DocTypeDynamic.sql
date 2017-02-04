/****** Object:  StoredProcedure [AddDocTypeDynamic] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddDocTypeDynamic]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddDocTypeDynamic]
GO

CREATE PROCEDURE [AddDocTypeDynamic]
    @DocTypeID int OUTPUT,
    @DocTypeName varchar(255)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into DocTypes */
        INSERT INTO [DocTypes]
        (
            [DocTypeName]
        )
        VALUES
        (
            @DocTypeName
        )

        /* Return new primary key */
        SET @DocTypeID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateDocTypeDynamic] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDocTypeDynamic]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateDocTypeDynamic]
GO

CREATE PROCEDURE [UpdateDocTypeDynamic]
    @DocTypeID int,
    @DocTypeName varchar(255)
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
            RAISERROR ('''DocTypeDynamic'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in DocTypes */
        UPDATE [DocTypes]
        SET
            [DocTypeName] = @DocTypeName
        WHERE
            [DocTypeID] = @DocTypeID

    END
GO

/****** Object:  StoredProcedure [DeleteDocTypeDynamic] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteDocTypeDynamic]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteDocTypeDynamic]
GO

CREATE PROCEDURE [DeleteDocTypeDynamic]
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
            RAISERROR ('''DocTypeDynamic'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark DocTypeDynamic object as not active */
        UPDATE [DocTypes]
        SET    [IsActive] = 'false'
        WHERE
            [DocTypes].[DocTypeID] = @DocTypeID

    END
GO
