/****** Object:  StoredProcedure [GetC05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC05Level111Child]
GO

CREATE PROCEDURE [GetC05Level111Child]
    @CMarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C05Level111Child from table */
        SELECT
            [Level_1_1_1_Child].[Level_1_1_1_Child_Name],
            [Level_1_1_1_Child].[CMarentID1],
            [Level_1_1_1_Child].[RowVersion]
        FROM [Level_1_1_1_Child]
        WHERE
            [Level_1_1_1_Child].[CMarentID1] = @CMarentID1

    END
GO

/****** Object:  StoredProcedure [AddC05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC05Level111Child]
GO

CREATE PROCEDURE [AddC05Level111Child]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_Child */
        INSERT INTO [Level_1_1_1_Child]
        (
            [CMarentID1],
            [Level_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_ID,
            @Level_1_1_1_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Level_1_1_1_Child]
        WHERE
            [CMarentID1] = @Level_1_1_ID

    END
GO

/****** Object:  StoredProcedure [UpdateC05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC05Level111Child]
GO

CREATE PROCEDURE [UpdateC05Level111Child]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50),
    @CMarentID1 int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CMarentID1], [CMarentID1] FROM [Level_1_1_1_Child]
            WHERE
                [CMarentID1] = @Level_1_1_ID AND
                [CMarentID1] = @CMarentID1
        )
        BEGIN
            RAISERROR ('''C05Level111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [CMarentID1], [CMarentID1] FROM [Level_1_1_1_Child]
            WHERE
                [CMarentID1] = @Level_1_1_ID AND
                [CMarentID1] = @CMarentID1 AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''C05Level111Child'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_Child */
        UPDATE [Level_1_1_1_Child]
        SET
            [Level_1_1_1_Child_Name] = @Level_1_1_1_Child_Name
        WHERE
            [CMarentID1] = @Level_1_1_ID AND
            [CMarentID1] = @CMarentID1 AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Level_1_1_1_Child]
        WHERE
            [CMarentID1] = @Level_1_1_ID AND
            [CMarentID1] = @CMarentID1

    END
GO

/****** Object:  StoredProcedure [DeleteC05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC05Level111Child]
GO

CREATE PROCEDURE [DeleteC05Level111Child]
    @Level_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CMarentID1] FROM [Level_1_1_1_Child]
            WHERE
                [CMarentID1] = @Level_1_1_ID
        )
        BEGIN
            RAISERROR ('''C05Level111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C05Level111Child object from Level_1_1_1_Child */
        DELETE
        FROM [Level_1_1_1_Child]
        WHERE
            [Level_1_1_1_Child].[CMarentID1] = @Level_1_1_ID

    END
GO
