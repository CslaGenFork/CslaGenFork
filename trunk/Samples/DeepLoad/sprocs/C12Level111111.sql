/****** Object:  StoredProcedure [AddC12Level111111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC12Level111111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC12Level111111]
GO

CREATE PROCEDURE [AddC12Level111111]
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

/****** Object:  StoredProcedure [UpdateC12Level111111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC12Level111111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC12Level111111]
GO

CREATE PROCEDURE [UpdateC12Level111111]
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
            RAISERROR ('''C12Level111111'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteC12Level111111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC12Level111111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC12Level111111]
GO

CREATE PROCEDURE [DeleteC12Level111111]
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
            RAISERROR ('''C12Level111111'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C12Level111111 object from Level_1_1_1_1_1_1 */
        DELETE
        FROM [Level_1_1_1_1_1_1]
        WHERE
            [Level_1_1_1_1_1_1_ID] = @Level_1_1_1_1_1_1_ID

    END
GO
