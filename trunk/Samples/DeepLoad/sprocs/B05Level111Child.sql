/****** Object:  StoredProcedure [AddB05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB05Level111Child]
GO

CREATE PROCEDURE [AddB05Level111Child]
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

/****** Object:  StoredProcedure [UpdateB05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB05Level111Child]
GO

CREATE PROCEDURE [UpdateB05Level111Child]
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
            RAISERROR ('''B05Level111Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteB05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB05Level111Child]
GO

CREATE PROCEDURE [DeleteB05Level111Child]
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
            RAISERROR ('''B05Level111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B05Level111Child object from Level_1_1_1_Child */
        DELETE
        FROM [Level_1_1_1_Child]
        WHERE
            [CMarentID1] = @Level_1_1_ID

    END
GO
