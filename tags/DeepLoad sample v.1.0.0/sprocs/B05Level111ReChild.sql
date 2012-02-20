/****** Object:  StoredProcedure [AddB05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB05Level111ReChild]
GO

CREATE PROCEDURE [AddB05Level111ReChild]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50)
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

    END
GO

/****** Object:  StoredProcedure [UpdateB05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB05Level111ReChild]
GO

CREATE PROCEDURE [UpdateB05Level111ReChild]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50)
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
            RAISERROR ('''B05Level111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_ReChild */
        UPDATE [Level_1_1_1_ReChild]
        SET
            [Level_1_1_1_Child_Name] = @Level_1_1_1_Child_Name
        WHERE
            [CMarentID2] = @Level_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteB05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB05Level111ReChild]
GO

CREATE PROCEDURE [DeleteB05Level111ReChild]
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
            RAISERROR ('''B05Level111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B05Level111ReChild object from Level_1_1_1_ReChild */
        DELETE
        FROM [Level_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_ReChild].[CMarentID2] = @Level_1_1_ID

    END
GO
