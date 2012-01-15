/****** Object:  StoredProcedure [GetD03Level11ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetD03Level11ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetD03Level11ReChild]
GO

CREATE PROCEDURE [GetD03Level11ReChild]
    @CParentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D03Level11ReChild from table */
        SELECT
            [Level_1_1_ReChild].[Level_1_1_Child_Name]
        FROM [Level_1_1_ReChild]
        WHERE
            [Level_1_1_ReChild].[CParentID2] = @CParentID2

    END
GO

/****** Object:  StoredProcedure [AddD03Level11ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddD03Level11ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddD03Level11ReChild]
GO

CREATE PROCEDURE [AddD03Level11ReChild]
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

/****** Object:  StoredProcedure [UpdateD03Level11ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateD03Level11ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateD03Level11ReChild]
GO

CREATE PROCEDURE [UpdateD03Level11ReChild]
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
            RAISERROR ('''D03Level11ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteD03Level11ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteD03Level11ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteD03Level11ReChild]
GO

CREATE PROCEDURE [DeleteD03Level11ReChild]
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
            RAISERROR ('''D03Level11ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D03Level11ReChild object from Level_1_1_ReChild */
        DELETE
        FROM [Level_1_1_ReChild]
        WHERE
            [CParentID2] = @Level_1_ID

    END
GO
