/****** Object:  StoredProcedure [GetD03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD03Level11Child]
GO

CREATE PROCEDURE [GetD03Level11Child]
    @CParentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D03Level11Child from table */
        SELECT
            [Level_1_1_Child].[Level_1_1_Child_Name]
        FROM [Level_1_1_Child]
        WHERE
            [Level_1_1_Child].[CParentID1] = @CParentID1

    END
GO

/****** Object:  StoredProcedure [AddD03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD03Level11Child]
GO

CREATE PROCEDURE [AddD03Level11Child]
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

/****** Object:  StoredProcedure [UpdateD03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD03Level11Child]
GO

CREATE PROCEDURE [UpdateD03Level11Child]
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
            RAISERROR ('''D03Level11Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteD03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD03Level11Child]
GO

CREATE PROCEDURE [DeleteD03Level11Child]
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
            RAISERROR ('''D03Level11Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D03Level11Child object from Level_1_1_Child */
        DELETE
        FROM [Level_1_1_Child]
        WHERE
            [Level_1_1_Child].[CParentID1] = @Level_1_ID

    END
GO
