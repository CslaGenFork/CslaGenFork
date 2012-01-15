/****** Object:  StoredProcedure [GetC03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC03Level11Child]
GO

CREATE PROCEDURE [GetC03Level11Child]
    @CParentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C03Level11Child from table */
        SELECT
            [Level_1_1_Child].[Level_1_1_Child_Name]
        FROM [Level_1_1_Child]
        WHERE
            [Level_1_1_Child].[CParentID1] = @CParentID1

    END
GO

/****** Object:  StoredProcedure [AddC03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC03Level11Child]
GO

CREATE PROCEDURE [AddC03Level11Child]
    @Level_1_ID int,
    @Level_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_Child */
        INSERT INTO [Level_1_1_Child]
        (
            [CParentID1],
            [Level_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_ID,
            @Level_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateC03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC03Level11Child]
GO

CREATE PROCEDURE [UpdateC03Level11Child]
    @Level_1_ID int,
    @Level_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CParentID1] FROM [Level_1_1_Child]
            WHERE
                [CParentID1] = @Level_1_ID
        )
        BEGIN
            RAISERROR ('''C03Level11Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_Child */
        UPDATE [Level_1_1_Child]
        SET
            [Level_1_1_Child_Name] = @Level_1_1_Child_Name
        WHERE
            [CParentID1] = @Level_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteC03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC03Level11Child]
GO

CREATE PROCEDURE [DeleteC03Level11Child]
    @Level_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CParentID1] FROM [Level_1_1_Child]
            WHERE
                [CParentID1] = @Level_1_ID
        )
        BEGIN
            RAISERROR ('''C03Level11Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C03Level11Child object from Level_1_1_Child */
        DELETE
        FROM [Level_1_1_Child]
        WHERE
            [CParentID1] = @Level_1_ID

    END
GO
