/****** Object:  StoredProcedure [GetG09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetG09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetG09_Region_ReChild]
GO

CREATE PROCEDURE [GetG09_Region_ReChild]
    @Region_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID2 AND
            [4_Regions_ReChild].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddG09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddG09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddG09_Region_ReChild]
GO

CREATE PROCEDURE [AddG09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_ReChild */
        INSERT INTO [4_Regions_ReChild]
        (
            [Region_ID2],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateG09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateG09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateG09_Region_ReChild]
GO

CREATE PROCEDURE [UpdateG09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_ReChild */
        UPDATE [4_Regions_ReChild]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID2] = @Region_ID

    END
GO

/****** Object:  StoredProcedure [DeleteG09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteG09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteG09_Region_ReChild]
GO

CREATE PROCEDURE [DeleteG09_Region_ReChild]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G09_Region_ReChild object as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID

    END
GO
