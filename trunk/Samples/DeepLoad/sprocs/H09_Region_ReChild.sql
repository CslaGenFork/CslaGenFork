/****** Object:  StoredProcedure [GetH09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetH09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetH09_Region_ReChild]
GO

CREATE PROCEDURE [GetH09_Region_ReChild]
    @Region_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID2 AND
            [4_Regions_ReChild].[IsActive] = 'true'

    END
GO

/****** Object:  StoredProcedure [AddH09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddH09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddH09_Region_ReChild]
GO

CREATE PROCEDURE [AddH09_Region_ReChild]
    @Region_ID2 int,
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
            @Region_ID2,
            @Region_Child_Name
        )

    END
GO

/****** Object:  StoredProcedure [UpdateH09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateH09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateH09_Region_ReChild]
GO

CREATE PROCEDURE [UpdateH09_Region_ReChild]
    @Region_ID2 int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_ReChild */
        UPDATE [4_Regions_ReChild]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID2] = @Region_ID2

    END
GO

/****** Object:  StoredProcedure [DeleteH09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteH09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteH09_Region_ReChild]
GO

CREATE PROCEDURE [DeleteH09_Region_ReChild]
    @Region_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existance */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID2 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H09_Region_ReChild object as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID2

    END
GO
