/****** Object:  StoredProcedure [AddF12Level111111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF12Level111111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF12Level111111]
GO

CREATE PROCEDURE [AddF12Level111111]
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

/****** Object:  StoredProcedure [UpdateF12Level111111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF12Level111111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF12Level111111]
GO

CREATE PROCEDURE [UpdateF12Level111111]
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
                [Level_1_1_1_1_1_1_ID] = @Level_1_1_1_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F12Level111111'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteF12Level111111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF12Level111111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF12Level111111]
GO

CREATE PROCEDURE [DeleteF12Level111111]
    @Level_1_1_1_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_1_1_1_1_1_ID] FROM [Level_1_1_1_1_1_1]
            WHERE
                [Level_1_1_1_1_1_1_ID] = @Level_1_1_1_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F12Level111111'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F12Level111111 object as not active */
        UPDATE [Level_1_1_1_1_1_1]
        SET    [IsActive] = 'false'
        WHERE
            [Level_1_1_1_1_1_1].[Level_1_1_1_1_1_1_ID] = @Level_1_1_1_1_1_1_ID

    END
GO
