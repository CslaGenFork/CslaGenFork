/****** Object:  StoredProcedure [GetFolderType] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetFolderType]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetFolderType]
GO

CREATE PROCEDURE [GetFolderType]
    @FolderTypeID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get FolderType from table */
        SELECT
            [FolderTypes].[FolderTypeID],
            [FolderTypes].[FolderTypeName],
            [FolderTypes].[CreateDate],
            [FolderTypes].[CreateUserID],
            [FolderTypes].[ChangeDate],
            [FolderTypes].[ChangeUserID],
            [FolderTypes].[RowVersion]
        FROM [FolderTypes]
        WHERE
            [FolderTypes].[FolderTypeID] = @FolderTypeID AND
            [FolderTypes].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddFolderType] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddFolderType]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddFolderType]
GO

CREATE PROCEDURE [AddFolderType]
    @FolderTypeID int OUTPUT,
    @FolderTypeName varchar(255),
    @CreateDate datetime2,
    @CreateUserID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into FolderTypes */
        INSERT INTO [FolderTypes]
        (
            [FolderTypeName],
            [CreateDate],
            [CreateUserID],
            [ChangeDate],
            [ChangeUserID]
        )
        VALUES
        (
            @FolderTypeName,
            @CreateDate,
            @CreateUserID,
            @ChangeDate,
            @ChangeUserID
        )

        /* Return new primary key */
        SET @FolderTypeID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [FolderTypes]
        WHERE
            [FolderTypeID] = @FolderTypeID

    END
GO

/****** Object:  StoredProcedure [UpdateFolderType] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateFolderType]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateFolderType]
GO

CREATE PROCEDURE [UpdateFolderType]
    @FolderTypeID int,
    @FolderTypeName varchar(255),
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
            SELECT [FolderTypeID] FROM [FolderTypes]
            WHERE
                [FolderTypeID] = @FolderTypeID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''FolderType'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [FolderTypeID] FROM [FolderTypes]
            WHERE
                [FolderTypeID] = @FolderTypeID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''FolderType'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in FolderTypes */
        UPDATE [FolderTypes]
        SET
            [FolderTypeName] = @FolderTypeName,
            [ChangeDate] = @ChangeDate,
            [ChangeUserID] = @ChangeUserID
        WHERE
            [FolderTypeID] = @FolderTypeID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [FolderTypes]
        WHERE
            [FolderTypeID] = @FolderTypeID

    END
GO

/****** Object:  StoredProcedure [DeleteFolderType] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteFolderType]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteFolderType]
GO

CREATE PROCEDURE [DeleteFolderType]
    @FolderTypeID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [FolderTypeID] FROM [FolderTypes]
            WHERE
                [FolderTypeID] = @FolderTypeID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''FolderType'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark FolderType object as not active */
        UPDATE [FolderTypes]
        SET    [IsActive] = 'false'
        WHERE
            [FolderTypes].[FolderTypeID] = @FolderTypeID

    END
GO
