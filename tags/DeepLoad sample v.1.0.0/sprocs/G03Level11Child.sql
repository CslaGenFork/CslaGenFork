/****** Object:  StoredProcedure [GetG03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG03Level11Child]
GO

CREATE PROCEDURE [GetG03Level11Child]
    @CParentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G03Level11Child from table */
        SELECT
            [Level_1_1_Child].[Level_1_1_Child_Name]
        FROM [Level_1_1_Child]
        WHERE
            [Level_1_1_Child].[CParentID1] = @CParentID1 AND
            [Level_1_1_Child].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddG03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddG03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddG03Level11Child]
GO

CREATE PROCEDURE [AddG03Level11Child]
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

/****** Object:  StoredProcedure [UpdateG03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateG03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateG03Level11Child]
GO

CREATE PROCEDURE [UpdateG03Level11Child]
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
                [CParentID1] = @Level_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G03Level11Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteG03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteG03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteG03Level11Child]
GO

CREATE PROCEDURE [DeleteG03Level11Child]
    @Level_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CParentID1] FROM [Level_1_1_Child]
            WHERE
                [CParentID1] = @Level_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G03Level11Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G03Level11Child object as not active */
        UPDATE [Level_1_1_Child]
        SET    [IsActive] = 'false'
        WHERE
            [Level_1_1_Child].[CParentID1] = @Level_1_ID

    END
GO
