/****** Object:  StoredProcedure [AddF11Level111111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF11Level111111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF11Level111111Child]
GO

CREATE PROCEDURE [AddF11Level111111Child]
    @Level_1_1_1_1_1_ID int,
    @Level_1_1_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_1_1_1_Child */
        INSERT INTO [Level_1_1_1_1_1_1_Child]
        (
            [CQarentID1],
            [Level_1_1_1_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_1_1_1_ID,
            @Level_1_1_1_1_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateF11Level111111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF11Level111111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF11Level111111Child]
GO

CREATE PROCEDURE [UpdateF11Level111111Child]
    @Level_1_1_1_1_1_ID int,
    @Level_1_1_1_1_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CQarentID1] FROM [Level_1_1_1_1_1_1_Child]
            WHERE
                [CQarentID1] = @Level_1_1_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F11Level111111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_1_1_1_Child */
        UPDATE [Level_1_1_1_1_1_1_Child]
        SET
            [Level_1_1_1_1_1_1_Child_Name] = @Level_1_1_1_1_1_1_Child_Name
        WHERE
            [CQarentID1] = @Level_1_1_1_1_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteF11Level111111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF11Level111111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF11Level111111Child]
GO

CREATE PROCEDURE [DeleteF11Level111111Child]
    @Level_1_1_1_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CQarentID1] FROM [Level_1_1_1_1_1_1_Child]
            WHERE
                [CQarentID1] = @Level_1_1_1_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F11Level111111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F11Level111111Child object as not active */
        UPDATE [Level_1_1_1_1_1_1_Child]
        SET    [IsActive] = 'false'
        WHERE
            [Level_1_1_1_1_1_1_Child].[CQarentID1] = @Level_1_1_1_1_1_ID

    END
GO
