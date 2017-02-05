/****** Object:  StoredProcedure [GetUser] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetUser]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetUser]
GO

CREATE PROCEDURE [GetUser]
    @UserID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get User from table */
        SELECT
            [Users].[UserID],
            [Users].[Name],
            [Users].[Login],
            [Users].[Email],
            [Users].[IsActive],
            [Users].[CreateDate],
            [Users].[CreateUserID],
            [Users].[ChangeDate],
            [Users].[ChangeUserID],
            [Users].[RowVersion]
        FROM [Users]
        WHERE
            [Users].[UserID] = @UserID

    END
GO

/****** Object:  StoredProcedure [AddUser] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddUser]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddUser]
GO

CREATE PROCEDURE [AddUser]
    @UserID int OUTPUT,
    @Name varchar(50),
    @Login varchar(30),
    @Email varchar(50),
    @IsActive bit,
    @CreateDate datetime2,
    @CreateUserID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Users */
        INSERT INTO [Users]
        (
            [Name],
            [Login],
            [Email],
            [IsActive],
            [CreateDate],
            [CreateUserID],
            [ChangeDate],
            [ChangeUserID]
        )
        VALUES
        (
            @Name,
            @Login,
            @Email,
            @IsActive,
            @CreateDate,
            @CreateUserID,
            @ChangeDate,
            @ChangeUserID
        )

        /* Return new primary key */
        SET @UserID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Users]
        WHERE
            [UserID] = @UserID

    END
GO

/****** Object:  StoredProcedure [UpdateUser] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateUser]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateUser]
GO

CREATE PROCEDURE [UpdateUser]
    @UserID int,
    @Name varchar(50),
    @Login varchar(30),
    @Email varchar(50),
    @IsActive bit,
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
            SELECT [UserID] FROM [Users]
            WHERE
                [UserID] = @UserID
        )
        BEGIN
            RAISERROR ('''User'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [UserID] FROM [Users]
            WHERE
                [UserID] = @UserID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''User'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in Users */
        UPDATE [Users]
        SET
            [Name] = @Name,
            [Login] = @Login,
            [Email] = @Email,
            [IsActive] = @IsActive,
            [ChangeDate] = @ChangeDate,
            [ChangeUserID] = @ChangeUserID
        WHERE
            [UserID] = @UserID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Users]
        WHERE
            [UserID] = @UserID

    END
GO

/****** Object:  StoredProcedure [DeleteUser] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteUser]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteUser]
GO

CREATE PROCEDURE [DeleteUser]
    @UserID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [UserID] FROM [Users]
            WHERE
                [UserID] = @UserID
            /* Ignore filter option is on */
        )
        BEGIN
            RAISERROR ('''User'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark User object as not active */
        UPDATE [Users]
        SET    [IsActive] = 'false'
        WHERE
            [Users].[UserID] = @UserID

    END
GO
