/****** Object:  StoredProcedure [GetG03Level11ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG03Level11ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG03Level11ReChild]
GO

CREATE PROCEDURE [GetG03Level11ReChild]
    @CParentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G03Level11ReChild from table */
        SELECT
            [Level_1_1_ReChild].[Level_1_1_Child_Name]
        FROM [Level_1_1_ReChild]
        WHERE
            [Level_1_1_ReChild].[CParentID2] = @CParentID2 AND
            [Level_1_1_ReChild].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddG03Level11ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddG03Level11ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddG03Level11ReChild]
GO

CREATE PROCEDURE [AddG03Level11ReChild]
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

/****** Object:  StoredProcedure [UpdateG03Level11ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateG03Level11ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateG03Level11ReChild]
GO

CREATE PROCEDURE [UpdateG03Level11ReChild]
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
                [CParentID2] = @Level_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G03Level11ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteG03Level11ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteG03Level11ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteG03Level11ReChild]
GO

CREATE PROCEDURE [DeleteG03Level11ReChild]
    @Level_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CParentID2] FROM [Level_1_1_ReChild]
            WHERE
                [CParentID2] = @Level_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G03Level11ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G03Level11ReChild object as not active */
        UPDATE [Level_1_1_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [CParentID2] = @Level_1_ID

    END
GO
