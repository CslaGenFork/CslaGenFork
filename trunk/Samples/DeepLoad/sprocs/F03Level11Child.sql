/****** Object:  StoredProcedure [AddF03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddF03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddF03Level11Child]
GO

CREATE PROCEDURE [AddF03Level11Child]
    @Level_1_ID int,
    @Level_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_Child */
        INSERT INTO [Level_1_1_Child]
        (
            [CParentID1],
            [Level_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_ID,
            @Level_1_1_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateF03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateF03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateF03Level11Child]
GO

CREATE PROCEDURE [UpdateF03Level11Child]
    @Level_1_ID int,
    @Level_1_1_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CParentID1] FROM [Level_1_1_Child]
            WHERE
                [CParentID1] = @Level_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F03Level11Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_Child */
        UPDATE [Level_1_1_Child]
        SET
            [Level_1_1_Child_Name] = @Level_1_1_Child_Name
        WHERE
            [CParentID1] = @Level_1_ID

    END
GO

/****** Object:  StoredProcedure [DeleteF03Level11Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteF03Level11Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteF03Level11Child]
GO

CREATE PROCEDURE [DeleteF03Level11Child]
    @Level_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CParentID1] FROM [Level_1_1_Child]
            WHERE
                [CParentID1] = @Level_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F03Level11Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F03Level11Child object as not active */
        UPDATE [Level_1_1_Child]
        SET    [IsActive] = 'false'
        WHERE
            [CParentID1] = @Level_1_ID

    END
GO
