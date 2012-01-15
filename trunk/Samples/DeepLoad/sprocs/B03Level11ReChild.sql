/****** Object:  StoredProcedure [AddB03Level11ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB03Level11ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB03Level11ReChild]
GO

CREATE PROCEDURE [AddB03Level11ReChild]
    @Level_1_ID int,
    @Level_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_ReChild */
        INSERT INTO [Level_1_1_ReChild]
        (
            [CParentID2],
            [Level_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_ID,
            @Level_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateB03Level11ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB03Level11ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB03Level11ReChild]
GO

CREATE PROCEDURE [UpdateB03Level11ReChild]
    @Level_1_ID int,
    @Level_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CParentID2] FROM [Level_1_1_ReChild]
            WHERE
                [CParentID2] = @Level_1_ID
        )
        BEGIN
            RAISERROR ('''B03Level11ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_ReChild */
        UPDATE [Level_1_1_ReChild]
        SET
            [Level_1_1_Child_Name] = @Level_1_1_Child_Name
        WHERE
            [CParentID2] = @Level_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteB03Level11ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB03Level11ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB03Level11ReChild]
GO

CREATE PROCEDURE [DeleteB03Level11ReChild]
    @Level_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CParentID2] FROM [Level_1_1_ReChild]
            WHERE
                [CParentID2] = @Level_1_ID
        )
        BEGIN
            RAISERROR ('''B03Level11ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B03Level11ReChild object from Level_1_1_ReChild */
        DELETE
        FROM [Level_1_1_ReChild]
        WHERE
            [CParentID2] = @Level_1_ID

    END
GO
