/****** Object:  StoredProcedure [AddB09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddB09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddB09_Region_ReChild]
GO

CREATE PROCEDURE [AddB09_Region_ReChild]
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

/****** Object:  StoredProcedure [UpdateB09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateB09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateB09_Region_ReChild]
GO

CREATE PROCEDURE [UpdateB09_Region_ReChild]
    @Region_ID2 int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID2
        )
        BEGIN
            RAISERROR ('''B09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
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

/****** Object:  StoredProcedure [DeleteB09_Region_ReChild] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteB09_Region_ReChild]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteB09_Region_ReChild]
GO

CREATE PROCEDURE [DeleteB09_Region_ReChild]
    @Region_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID2
        )
        BEGIN
            RAISERROR ('''B09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B09_Region_ReChild object from 4_Regions_ReChild */
        DELETE
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID2

    END
GO
