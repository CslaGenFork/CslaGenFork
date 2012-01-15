/****** Object:  StoredProcedure [GetH05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH05Level111ReChild]
GO

CREATE PROCEDURE [GetH05Level111ReChild]
    @CMarentID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H05Level111ReChild from table */
        SELECT
            [Level_1_1_1_ReChild].[Level_1_1_1_Child_Name]
        FROM [Level_1_1_1_ReChild]
        WHERE
            [Level_1_1_1_ReChild].[CMarentID2] = @CMarentID2 AND
            [Level_1_1_1_ReChild].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH05Level111ReChild]
GO

CREATE PROCEDURE [AddH05Level111ReChild]
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

/****** Object:  StoredProcedure [UpdateH05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH05Level111ReChild]
GO

CREATE PROCEDURE [UpdateH05Level111ReChild]
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
                [CMarentID2] = @Level_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H05Level111ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteH05Level111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH05Level111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH05Level111ReChild]
GO

CREATE PROCEDURE [DeleteH05Level111ReChild]
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
            RAISERROR ('''H05Level111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H05Level111ReChild object as not active */
        UPDATE [Level_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [CMarentID2] = @Level_1_1_ID

    END
GO
