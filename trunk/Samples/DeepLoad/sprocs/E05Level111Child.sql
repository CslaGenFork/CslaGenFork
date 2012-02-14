/****** Object:  StoredProcedure [AddE05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddE05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddE05Level111Child]
GO

CREATE PROCEDURE [AddE05Level111Child]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Level_1_1_1_Child */
        INSERT INTO [Level_1_1_1_Child]
        (
            [CMarentID1],
            [Level_1_1_1_Child_Name]
        )
        VALUES
        (
            @Level_1_1_ID,
            @Level_1_1_1_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Level_1_1_1_Child]
        WHERE
            [CMarentID1] = @Level_1_1_ID

    END
GO

/****** Object:  StoredProcedure [UpdateE05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateE05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateE05Level111Child]
GO

CREATE PROCEDURE [UpdateE05Level111Child]
    @Level_1_1_ID int,
    @Level_1_1_1_Child_Name varchar(50),
    @CMarentID1 int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CMarentID1], [CMarentID1] FROM [Level_1_1_1_Child]
            WHERE
                [CMarentID1] = @Level_1_1_ID AND
                [CMarentID1] = @CMarentID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E05Level111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [CMarentID1], [CMarentID1] FROM [Level_1_1_1_Child]
            WHERE
                [CMarentID1] = @Level_1_1_ID AND
                [CMarentID1] = @CMarentID1 AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''E05Level111Child'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in Level_1_1_1_Child */
        UPDATE [Level_1_1_1_Child]
        SET
            [Level_1_1_1_Child_Name] = @Level_1_1_1_Child_Name
        WHERE
            [CMarentID1] = @Level_1_1_ID AND
            [CMarentID1] = @CMarentID1 AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [Level_1_1_1_Child]
        WHERE
            [CMarentID1] = @Level_1_1_ID AND
            [CMarentID1] = @CMarentID1

    END
GO

/****** Object:  StoredProcedure [DeleteE05Level111Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteE05Level111Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteE05Level111Child]
GO

CREATE PROCEDURE [DeleteE05Level111Child]
    @Level_1_1_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [CMarentID1] FROM [Level_1_1_1_Child]
            WHERE
                [CMarentID1] = @Level_1_1_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E05Level111Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E05Level111Child object as not active */
        UPDATE [Level_1_1_1_Child]
        SET    [IsActive] = 'false'
        WHERE
            [Level_1_1_1_Child].[CMarentID1] = @Level_1_1_ID

    END
GO
