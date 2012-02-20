/****** Object:  StoredProcedure [GetG11Level111111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG11Level111111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG11Level111111Child]
GO

CREATE PROCEDURE [GetG11Level111111Child]
    @CQarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G11Level111111Child from table */
        SELECT
            [Level_1_1_1_1_1_1_Child].[Level_1_1_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_1_1_Child]
        WHERE
            [Level_1_1_1_1_1_1_Child].[CQarentID1] = @CQarentID1 AND
            [Level_1_1_1_1_1_1_Child].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddG11Level111111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddG11Level111111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddG11Level111111Child]
GO

CREATE PROCEDURE [AddG11Level111111Child]
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

/****** Object:  StoredProcedure [UpdateG11Level111111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateG11Level111111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateG11Level111111Child]
GO

CREATE PROCEDURE [UpdateG11Level111111Child]
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
                [CQarentID1] = @Level_1_1_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G11Level111111Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteG11Level111111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteG11Level111111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteG11Level111111Child]
GO

CREATE PROCEDURE [DeleteG11Level111111Child]
    @Level_1_1_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CQarentID1] FROM [Level_1_1_1_1_1_1_Child]
            WHERE
                [CQarentID1] = @Level_1_1_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G11Level111111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G11Level111111Child object as not active */
        UPDATE [Level_1_1_1_1_1_1_Child]
        SET    [IsActive] = 'false'
        WHERE
            [Level_1_1_1_1_1_1_Child].[CQarentID1] = @Level_1_1_1_1_1_ID

    END
GO
