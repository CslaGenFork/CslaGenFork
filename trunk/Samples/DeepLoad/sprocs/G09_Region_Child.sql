/****** Object:  StoredProcedure [GetG09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG09_Region_Child]
GO

CREATE PROCEDURE [GetG09_Region_Child]
    @Region_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID1 AND
            [4_Regions_Child].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddG09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddG09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddG09_Region_Child]
GO

CREATE PROCEDURE [AddG09_Region_Child]
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

/****** Object:  StoredProcedure [UpdateG09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateG09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateG09_Region_Child]
GO

CREATE PROCEDURE [UpdateG09_Region_Child]
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
            RAISERROR ('''G09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteG09_Region_Child] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteG09_Region_Child]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteG09_Region_Child]
GO

CREATE PROCEDURE [DeleteG09_Region_Child]
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
            RAISERROR ('''G09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G09_Region_Child object as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID1

    END
GO
