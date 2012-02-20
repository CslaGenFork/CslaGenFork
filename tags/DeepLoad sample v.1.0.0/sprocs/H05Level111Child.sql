/****** Object:  StoredProcedure [GetH05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH05Level111Child]
GO

CREATE PROCEDURE [GetH05Level111Child]
    @CMarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H05Level111Child from table */
        SELECT
            [Level_1_1_1_Child].[Level_1_1_1_Child_Name]
        FROM [Level_1_1_1_Child]
        WHERE
            [Level_1_1_1_Child].[CMarentID1] = @CMarentID1 AND
            [Level_1_1_1_Child].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH05Level111Child]
GO

CREATE PROCEDURE [AddH05Level111Child]
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

/****** Object:  StoredProcedure [UpdateH05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH05Level111Child]
GO

CREATE PROCEDURE [UpdateH05Level111Child]
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
                [CMarentID1] = @Level_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H05Level111Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteH05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH05Level111Child]
GO

CREATE PROCEDURE [DeleteH05Level111Child]
    @Level_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CMarentID1] FROM [Level_1_1_1_Child]
            WHERE
                [CMarentID1] = @Level_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H05Level111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H05Level111Child object as not active */
        UPDATE [Level_1_1_1_Child]
        SET    [IsActive] = 'false'
        WHERE
            [Level_1_1_1_Child].[CMarentID1] = @Level_1_1_ID

    END
GO
