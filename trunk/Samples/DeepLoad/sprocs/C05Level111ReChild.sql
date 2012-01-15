/****** Object:  StoredProcedure [GetC05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC05Level111ReChild]
GO

CREATE PROCEDURE [GetC05Level111ReChild]
    @CMarentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C05Level111ReChild from table */
        SELECT
            [Level_1_1_1_ReChild].[Level_1_1_1_Child_Name],
            [Level_1_1_1_ReChild].[RowVersion]
        FROM [Level_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_ReChild].[CMarentID2] = @CMarentID2

    END
GO

/****** Object:  StoredProcedure [AddC05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC05Level111ReChild]
GO

CREATE PROCEDURE [AddC05Level111ReChild]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_ReChild */
        INSERT INTO [Level_1_1_1_ReChild]
        (
            [CMarentID2],
            [Level_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_ID,
            @Level_1_1_1_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Level_1_1_1_ReChild]
        WHERE
            [CMarentID2] = @Level_1_1_ID

    END
GO

/****** Object:  StoredProcedure [UpdateC05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC05Level111ReChild]
GO

CREATE PROCEDURE [UpdateC05Level111ReChild]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50),
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CMarentID2] FROM [Level_1_1_1_ReChild]
            WHERE
                [CMarentID2] = @Level_1_1_ID
        )
        BEGIN
            RAISERROR ('''C05Level111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [CMarentID2] FROM [Level_1_1_1_ReChild]
            WHERE
                [CMarentID2] = @Level_1_1_ID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''C05Level111ReChild'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_ReChild */
        UPDATE [Level_1_1_1_ReChild]
        SET
            [Level_1_1_1_Child_Name] = @Level_1_1_1_Child_Name
        WHERE
            [CMarentID2] = @Level_1_1_ID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Level_1_1_1_ReChild]
        WHERE
            [CMarentID2] = @Level_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteC05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC05Level111ReChild]
GO

CREATE PROCEDURE [DeleteC05Level111ReChild]
    @Level_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CMarentID2] FROM [Level_1_1_1_ReChild]
            WHERE
                [CMarentID2] = @Level_1_1_ID
        )
        BEGIN
            RAISERROR ('''C05Level111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C05Level111ReChild object from Level_1_1_1_ReChild */
        DELETE
        FROM [Level_1_1_1_ReChild]
        WHERE
            [CMarentID2] = @Level_1_1_ID

    END
GO
