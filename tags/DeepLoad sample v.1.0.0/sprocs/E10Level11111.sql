/****** Object:  StoredProcedure [AddE10Level11111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddE10Level11111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddE10Level11111]
GO

CREATE PROCEDURE [AddE10Level11111]
    @Level_1_1_1_1_1_ID int OUTPUT,
    @Level_1_1_1_1_ID int,
    @Level_1_1_1_1_1_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1_1 */
        INSERT INTO [Level_1_1_1_1_1]
        (
            [NarentID1],
            [Level_1_1_1_1_1_Name]
        )
        VALUES
        (
            @Level_1_1_1_1_ID,
            @Level_1_1_1_1_1_Name
        )

        /* Return new primary key */
        SET @Level_1_1_1_1_1_ID = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateE10Level11111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateE10Level11111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateE10Level11111]
GO

CREATE PROCEDURE [UpdateE10Level11111]
    @Level_1_1_1_1_1_ID int,
    @Level_1_1_1_1_1_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_1_1_1_1_ID] FROM [Level_1_1_1_1_1]
            WHERE
                [Level_1_1_1_1_1_ID] = @Level_1_1_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E10Level11111'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1_1 */
        UPDATE [Level_1_1_1_1_1]
        SET
            [Level_1_1_1_1_1_Name] = @Level_1_1_1_1_1_Name
        WHERE
            [Level_1_1_1_1_1_ID] = @Level_1_1_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteE10Level11111] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteE10Level11111]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteE10Level11111]
GO

CREATE PROCEDURE [DeleteE10Level11111]
    @Level_1_1_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Level_1_1_1_1_1_ID] FROM [Level_1_1_1_1_1]
            WHERE
                [Level_1_1_1_1_1_ID] = @Level_1_1_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E10Level11111'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child E12Level111111 as not active */
        UPDATE [Level_1_1_1_1_1_1]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1_1]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1].[QarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
        WHERE
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID] = @Level_1_1_1_1_1_ID

        /* Mark child E11Level111111ReChild as not active */
        UPDATE [Level_1_1_1_1_1_1_ReChild]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1_1_ReChild]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_ReChild].[CQarentID2] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
        WHERE
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID] = @Level_1_1_1_1_1_ID

        /* Mark child E11Level111111Child as not active */
        UPDATE [Level_1_1_1_1_1_1_Child]
        SET    [IsActive] = 'false'
        FROM [Level_1_1_1_1_1_1_Child]
            INNER JOIN [Level_1_1_1_1_1] ON [Level_1_1_1_1_1_1_Child].[CQarentID1] = [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID]
        WHERE
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID] = @Level_1_1_1_1_1_ID

        /* Mark E10Level11111 object as not active */
        UPDATE [Level_1_1_1_1_1]
        SET    [IsActive] = 'false'
        WHERE
            [Level_1_1_1_1_1].[Level_1_1_1_1_1_ID] = @Level_1_1_1_1_1_ID

    END
GO
