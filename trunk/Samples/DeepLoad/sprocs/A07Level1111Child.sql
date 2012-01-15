/****** Object:  StoredProcedure [AddA07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddA07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddA07Level1111Child]
GO

CREATE PROCEDURE [AddA07Level1111Child]
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

/****** Object:  StoredProcedure [UpdateA07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateA07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateA07Level1111Child]
GO

CREATE PROCEDURE [UpdateA07Level1111Child]
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
                [CLarentID1] = @Level_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''A07Level1111Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteA07Level1111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteA07Level1111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteA07Level1111Child]
GO

CREATE PROCEDURE [DeleteA07Level1111Child]
    @Level_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CLarentID1] FROM [Level_1_1_1_1_Child]
            WHERE
                [CLarentID1] = @Level_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''A07Level1111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A07Level1111Child object from Level_1_1_1_1_Child */
        DELETE
        FROM [Level_1_1_1_1_Child]
        WHERE
            [CLarentID1] = @Level_1_1_1_ID

    END
GO
