/****** Object:  StoredProcedure [GetRole] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetRole]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetRole]
GO

CREATE PROCEDURE [GetRole]
    @RoleID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get Role from table */
        SELECT
            [Roles].[RoleID],
            [Roles].[RoleName],
            [Roles].[IsActive],
            [Roles].[CreateDate],
            [Roles].[CreateUserID],
            [Roles].[ChangeDate],
            [Roles].[ChangeUserID],
            [Roles].[RowVersion]
        FROM [Roles]
        WHERE
            [Roles].[RoleID] = @RoleID

    END
GO

/****** Object:  StoredProcedure [AddRole] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddRole]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddRole]
GO

CREATE PROCEDURE [AddRole]
    @RoleID int OUTPUT,
    @RoleName varchar(20),
    @IsActive bit,
    @CreateDate datetime2,
    @CreateUserID int,
    @ChangeDate datetime2,
    @ChangeUserID int,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Roles */
        INSERT INTO [Roles]
        (
            [RoleName],
            [IsActive],
            [CreateDate],
            [CreateUserID],
            [ChangeDate],
            [ChangeUserID]
        )
        VALUES
        (
            @RoleName,
            @IsActive,
            @CreateDate,
            @CreateUserID,
            @ChangeDate,
            @ChangeUserID
        )

        /* Return new primary key */
        SET @RoleID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Roles]
        WHERE
            [RoleID] = @RoleID

    END
GO

/****** Object:  StoredProcedure [UpdateRole] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateRole]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateRole]
GO

CREATE PROCEDURE [UpdateRole]
    @RoleID int,
    @RoleName varchar(20),
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
            SELECT [RoleID] FROM [Roles]
            WHERE
                [RoleID] = @RoleID
        )
        BEGIN
            RAISERROR ('''Role'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [RoleID] FROM [Roles]
            WHERE
                [RoleID] = @RoleID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''Role'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in Roles */
        UPDATE [Roles]
        SET
            [RoleName] = @RoleName,
            [IsActive] = @IsActive,
            [ChangeDate] = @ChangeDate,
            [ChangeUserID] = @ChangeUserID
        WHERE
            [RoleID] = @RoleID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Roles]
        WHERE
            [RoleID] = @RoleID

    END
GO

/****** Object:  StoredProcedure [DeleteRole] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteRole]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteRole]
GO

CREATE PROCEDURE [DeleteRole]
    @RoleID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [RoleID] FROM [Roles]
            WHERE
                [RoleID] = @RoleID
            /* Ignore filter option is on */
        )
        BEGIN
            RAISERROR ('''Role'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark Role object as not active */
        UPDATE [Roles]
        SET    [IsActive] = 'false'
        WHERE
            [Roles].[RoleID] = @RoleID

    END
GO
