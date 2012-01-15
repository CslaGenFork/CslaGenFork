/****** Object:  StoredProcedure [GetD11Level111111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD11Level111111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD11Level111111Child]
GO

CREATE PROCEDURE [GetD11Level111111Child]
    @CQarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D11Level111111Child from table */
        SELECT
            [Level_1_1_1_1_1_1_Child].[Level_1_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_1_Child]
        WHERE
            [Level_1_1_1_1_1_1_Child].[CQarentID1] = @CQarentID1

    END
GO

/****** Object:  StoredProcedure [AddD11Level111111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD11Level111111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD11Level111111Child]
GO

CREATE PROCEDURE [AddD11Level111111Child]
    @Level_1_1_1_1_1_ID int,
    @Level_1_1_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1_1_1_Child */
        INSERT INTO [Level_1_1_1_1_1_1_Child]
        (
            [CQarentID1],
            [Level_1_1_1_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_1_1_1_ID,
            @Level_1_1_1_1_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateD11Level111111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD11Level111111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD11Level111111Child]
GO

CREATE PROCEDURE [UpdateD11Level111111Child]
    @Level_1_1_1_1_1_ID int,
    @Level_1_1_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CQarentID1] FROM [Level_1_1_1_1_1_1_Child]
            WHERE
                [CQarentID1] = @Level_1_1_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''D11Level111111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1_1_1_Child */
        UPDATE [Level_1_1_1_1_1_1_Child]
        SET
            [Level_1_1_1_1_1_1_Child_Name] = @Level_1_1_1_1_1_1_Child_Name
        WHERE
            [CQarentID1] = @Level_1_1_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteD11Level111111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD11Level111111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD11Level111111Child]
GO

CREATE PROCEDURE [DeleteD11Level111111Child]
    @Level_1_1_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CQarentID1] FROM [Level_1_1_1_1_1_1_Child]
            WHERE
                [CQarentID1] = @Level_1_1_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''D11Level111111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D11Level111111Child object from Level_1_1_1_1_1_1_Child */
        DELETE
        FROM [Level_1_1_1_1_1_1_Child]
        WHERE
            [CQarentID1] = @Level_1_1_1_1_1_ID

    END
GO
