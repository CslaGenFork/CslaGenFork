/****** Object:  StoredProcedure [GetD05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD05Level111Child]
GO

CREATE PROCEDURE [GetD05Level111Child]
    @CMarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D05Level111Child from table */
        SELECT
            [Level_1_1_1_Child].[Level_1_1_1_Child_Name]
        FROM [Level_1_1_1_Child]
        WHERE
            [Level_1_1_1_Child].[CMarentID1] = @CMarentID1

    END
GO

/****** Object:  StoredProcedure [AddD05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD05Level111Child]
GO

CREATE PROCEDURE [AddD05Level111Child]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50)
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

    END
GO

/****** Object:  StoredProcedure [UpdateD05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD05Level111Child]
GO

CREATE PROCEDURE [UpdateD05Level111Child]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50)
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
            RAISERROR ('''D05Level111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_Child */
        UPDATE [Level_1_1_1_Child]
        SET
            [Level_1_1_1_Child_Name] = @Level_1_1_1_Child_Name
        WHERE
            [CMarentID1] = @Level_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteD05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD05Level111Child]
GO

CREATE PROCEDURE [DeleteD05Level111Child]
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
            RAISERROR ('''D05Level111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D05Level111Child object from Level_1_1_1_Child */
        DELETE
        FROM [Level_1_1_1_Child]
        WHERE
            [Level_1_1_1_Child].[CMarentID1] = @Level_1_1_ID

    END
GO
