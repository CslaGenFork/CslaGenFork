/****** Object:  StoredProcedure [AddB12Level111111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB12Level111111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB12Level111111]
GO

CREATE PROCEDURE [AddB12Level111111]
    @Level_1_1_1_1_1_1_ID int OUTPUT,
    @Level_1_1_1_1_1_ID int,
    @Level_1_1_1_1_1_1_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1_1_1 */
        INSERT INTO [Level_1_1_1_1_1_1]
        (
            [QarentID1],
            [Level_1_1_1_1_1_1_Name]
        )
        VALUES
        (
            @Level_1_1_1_1_1_ID,
            @Level_1_1_1_1_1_1_Name
        )

        /* Return new primary key */
        SET @Level_1_1_1_1_1_1_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateB12Level111111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB12Level111111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB12Level111111]
GO

CREATE PROCEDURE [UpdateB12Level111111]
    @Level_1_1_1_1_1_1_ID int,
    @Level_1_1_1_1_1_1_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_1_1_1_1_1_ID] FROM [Level_1_1_1_1_1_1]
            WHERE
                [Level_1_1_1_1_1_1_ID] = @Level_1_1_1_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''B12Level111111'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1_1_1 */
        UPDATE [Level_1_1_1_1_1_1]
        SET
            [Level_1_1_1_1_1_1_Name] = @Level_1_1_1_1_1_1_Name
        WHERE
            [Level_1_1_1_1_1_1_ID] = @Level_1_1_1_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteB12Level111111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB12Level111111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB12Level111111]
GO

CREATE PROCEDURE [DeleteB12Level111111]
    @Level_1_1_1_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_1_1_1_1_1_ID] FROM [Level_1_1_1_1_1_1]
            WHERE
                [Level_1_1_1_1_1_1_ID] = @Level_1_1_1_1_1_1_ID
        )
        BEGIN
            RAISERROR ('''B12Level111111'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B12Level111111 object from Level_1_1_1_1_1_1 */
        DELETE
        FROM [Level_1_1_1_1_1_1]
        WHERE
            [Level_1_1_1_1_1_1_ID] = @Level_1_1_1_1_1_1_ID

    END
GO
