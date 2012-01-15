/****** Object:  StoredProcedure [GetH07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH07Level1111Child]
GO

CREATE PROCEDURE [GetH07Level1111Child]
    @CLarentID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H07Level1111Child from table */
        SELECT
            [Level_1_1_1_1_Child].[Level_1_1_1_1_Child_Name]
        FROM [Level_1_1_1_1_Child]
        WHERE
            [Level_1_1_1_1_Child].[CLarentID1] = @CLarentID1 AND
            [Level_1_1_1_1_Child].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH07Level1111Child]
GO

CREATE PROCEDURE [AddH07Level1111Child]
    @Level_1_1_1_ID int,
    @Level_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1_Child */
        INSERT INTO [Level_1_1_1_1_Child]
        (
            [CLarentID1],
            [Level_1_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_1_ID,
            @Level_1_1_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateH07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH07Level1111Child]
GO

CREATE PROCEDURE [UpdateH07Level1111Child]
    @Level_1_1_1_ID int,
    @Level_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CLarentID1] FROM [Level_1_1_1_1_Child]
            WHERE
                [CLarentID1] = @Level_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H07Level1111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1_Child */
        UPDATE [Level_1_1_1_1_Child]
        SET
            [Level_1_1_1_1_Child_Name] = @Level_1_1_1_1_Child_Name
        WHERE
            [CLarentID1] = @Level_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteH07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH07Level1111Child]
GO

CREATE PROCEDURE [DeleteH07Level1111Child]
    @Level_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CLarentID1] FROM [Level_1_1_1_1_Child]
            WHERE
                [CLarentID1] = @Level_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H07Level1111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H07Level1111Child object as not active */
        UPDATE [Level_1_1_1_1_Child]
        SET    [IsActive] = 'false'
        WHERE
            [CLarentID1] = @Level_1_1_1_ID

    END
GO
