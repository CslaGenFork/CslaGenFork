/****** Object:  StoredProcedure [GetC09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetC09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetC09_Region_ReChild]
GO

CREATE PROCEDURE [GetC09_Region_ReChild]
    @Region_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID2

    END
GO

/****** Object:  StoredProcedure [AddC09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddC09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddC09_Region_ReChild]
GO

CREATE PROCEDURE [AddC09_Region_ReChild]
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

/****** Object:  StoredProcedure [UpdateC09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateC09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateC09_Region_ReChild]
GO

CREATE PROCEDURE [UpdateC09_Region_ReChild]
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
                [Region_ID2] = @Region_ID
        )
        BEGIN
            RAISERROR ('''C09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteC09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteC09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteC09_Region_ReChild]
GO

CREATE PROCEDURE [DeleteC09_Region_ReChild]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID
        )
        BEGIN
            RAISERROR ('''C09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C09_Region_ReChild object from 4_Regions_ReChild */
        DELETE
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID

    END
GO
