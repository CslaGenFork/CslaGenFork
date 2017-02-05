/****** Object:  StoredProcedure [AddCircTypeTagEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddCircTypeTagEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddCircTypeTagEdit]
GO

CREATE PROCEDURE [AddCircTypeTagEdit]
    @CircTypeID int OUTPUT,
    @CircTypeTag varchar(20),
    @CreateDate datetime2,
    @CreateUserID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into CircTypeTags */
        INSERT INTO [CircTypeTags]
        (
            [CircTypeTag],
            [CreateDate],
            [CreateUserID],
            [ChangeDate],
            [ChangeUserID]
        )
        VALUES
        (
            @CircTypeTag,
            @CreateDate,
            @CreateUserID,
            @ChangeDate,
            @ChangeUserID
        )

        /* Return new primary key */
        SET @CircTypeID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [CircTypeTags]
        WHERE
            [CircTypeID] = @CircTypeID

    END
GO

/****** Object:  StoredProcedure [UpdateCircTypeTagEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateCircTypeTagEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateCircTypeTagEdit]
GO

CREATE PROCEDURE [UpdateCircTypeTagEdit]
    @CircTypeID int,
    @CircTypeTag varchar(20),
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
            SELECT [CircTypeID] FROM [CircTypeTags]
            WHERE
                [CircTypeID] = @CircTypeID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''CircTypeTagEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [CircTypeID] FROM [CircTypeTags]
            WHERE
                [CircTypeID] = @CircTypeID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''CircTypeTagEdit'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in CircTypeTags */
        UPDATE [CircTypeTags]
        SET
            [CircTypeTag] = @CircTypeTag,
            [ChangeDate] = @ChangeDate,
            [ChangeUserID] = @ChangeUserID
        WHERE
            [CircTypeID] = @CircTypeID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [CircTypeTags]
        WHERE
            [CircTypeID] = @CircTypeID

    END
GO

/****** Object:  StoredProcedure [DeleteCircTypeTagEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteCircTypeTagEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteCircTypeTagEdit]
GO

CREATE PROCEDURE [DeleteCircTypeTagEdit]
    @CircTypeID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CircTypeID] FROM [CircTypeTags]
            WHERE
                [CircTypeID] = @CircTypeID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''CircTypeTagEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark CircTypeTagEdit object as not active */
        UPDATE [CircTypeTags]
        SET    [IsActive] = 'false'
        WHERE
            [CircTypeTags].[CircTypeID] = @CircTypeID

    END
GO
