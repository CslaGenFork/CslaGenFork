/****** Object:  StoredProcedure [AddA07Level1111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddA07Level1111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddA07Level1111ReChild]
GO

CREATE PROCEDURE [AddA07Level1111ReChild]
    @Level_1_1_1_ID int,
    @Level_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1_ReChild */
        INSERT INTO [Level_1_1_1_1_ReChild]
        (
            [CLarentID2],
            [Level_1_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_1_ID,
            @Level_1_1_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateA07Level1111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateA07Level1111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateA07Level1111ReChild]
GO

CREATE PROCEDURE [UpdateA07Level1111ReChild]
    @Level_1_1_1_ID int,
    @Level_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CLarentID2] FROM [Level_1_1_1_1_ReChild]
            WHERE
                [CLarentID2] = @Level_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''A07Level1111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1_ReChild */
        UPDATE [Level_1_1_1_1_ReChild]
        SET
            [Level_1_1_1_1_Child_Name] = @Level_1_1_1_1_Child_Name
        WHERE
            [CLarentID2] = @Level_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteA07Level1111ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteA07Level1111ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteA07Level1111ReChild]
GO

CREATE PROCEDURE [DeleteA07Level1111ReChild]
    @Level_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CLarentID2] FROM [Level_1_1_1_1_ReChild]
            WHERE
                [CLarentID2] = @Level_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''A07Level1111ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A07Level1111ReChild object from Level_1_1_1_1_ReChild */
        DELETE
        FROM [Level_1_1_1_1_ReChild]
        WHERE
            [CLarentID2] = @Level_1_1_1_ID

    END
GO
