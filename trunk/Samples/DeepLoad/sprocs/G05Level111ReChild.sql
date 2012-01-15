/****** Object:  StoredProcedure [GetG05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG05Level111ReChild]
GO

CREATE PROCEDURE [GetG05Level111ReChild]
    @CMarentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G05Level111ReChild from table */
        SELECT
            [Level_1_1_1_ReChild].[Level_1_1_1_Child_Name],
            [Level_1_1_1_ReChild].[RowVersion]
        FROM [Level_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_ReChild].[CMarentID2] = @CMarentID2 AND
            [Level_1_1_1_ReChild].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddG05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddG05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddG05Level111ReChild]
GO

CREATE PROCEDURE [AddG05Level111ReChild]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
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

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Level_1_1_1_ReChild]
        WHERE
            [CMarentID2] = @Level_1_1_ID

    END
GO

/****** Object:  StoredProcedure [UpdateG05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateG05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateG05Level111ReChild]
GO

CREATE PROCEDURE [UpdateG05Level111ReChild]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50),
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CMarentID2] FROM [Level_1_1_1_ReChild]
            WHERE
                [CMarentID2] = @Level_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G05Level111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [CMarentID2] FROM [Level_1_1_1_ReChild]
            WHERE
                [CMarentID2] = @Level_1_1_ID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''G05Level111ReChild'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_ReChild */
        UPDATE [Level_1_1_1_ReChild]
        SET
            [Level_1_1_1_Child_Name] = @Level_1_1_1_Child_Name
        WHERE
            [CMarentID2] = @Level_1_1_ID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Level_1_1_1_ReChild]
        WHERE
            [CMarentID2] = @Level_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteG05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteG05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteG05Level111ReChild]
GO

CREATE PROCEDURE [DeleteG05Level111ReChild]
    @Level_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CMarentID2] FROM [Level_1_1_1_ReChild]
            WHERE
                [CMarentID2] = @Level_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G05Level111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G05Level111ReChild object as not active */
        UPDATE [Level_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [CMarentID2] = @Level_1_1_ID

    END
GO
