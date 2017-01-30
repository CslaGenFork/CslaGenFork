/****** Object:  StoredProcedure [AddE09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddE09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddE09_Region_Child]
GO

CREATE PROCEDURE [AddE09_Region_Child]
    @Region_ID1 int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_Child */
        INSERT INTO [4_Regions_Child]
        (
            [Region_ID1],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID1,
            @Region_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateE09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateE09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateE09_Region_Child]
GO

CREATE PROCEDURE [UpdateE09_Region_Child]
    @Region_ID1 int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_Child */
        UPDATE [4_Regions_Child]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID1] = @Region_ID1

    END
GO

/****** Object:  StoredProcedure [DeleteE09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteE09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteE09_Region_Child]
GO

CREATE PROCEDURE [DeleteE09_Region_Child]
    @Region_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E09_Region_Child object as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID1

    END
GO
